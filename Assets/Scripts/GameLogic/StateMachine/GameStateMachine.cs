using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameUtil;

namespace Assets.Scripts.GameLogic.StateMachine
{
    public class GameStateMachine : IMonopolyCore
    {
        private StateOnStart _stateOnStart;

        public GameStateMachine()
        {
            Board = new Board();

            InitializeStates();

            Database = new VirtualDatabase();

            CurrentState = _stateOnStart;
        }

        private void InitializeStates()
        {
            _stateOnStart = new StateOnStart(this);
            StateOnPreparation = new StateOnPreparation(this);
            StateOnPlayerTurn = new StateOnPlayerTurn(this);
            StateOnBoardSlotAction = new StateOnBoardSlotAction(this);
            StateOnClientPreparation = new StateOnClientPreparation(this);
            StateOnGameOver = new StateOnGameOver(this);
        }

        public void ExecuteGameLogic()
        {
            CurrentState.ExecuteGameLogic();
        }

        #region Machine commands

        public void ChangeState(State state)
        {
            CurrentState = state;
        }

        public void ChangeToStateOnPlayerTurn()
        {
            StateOnPlayerTurn.PlayerOnTurn = PlayerOnTurn;
            StateOnPlayerTurn.PlayerTurn = new PlayerTurn();
            StateOnPlayerTurn.PlayerTurn.Player = PlayerOnTurn;
            StateOnPlayerTurn.Reset();
            CurrentState = StateOnPlayerTurn;
        }

        public void ChangeToStateOnBoardSlotAction()
        {
            StateOnBoardSlotAction.StateBefore = CurrentState;
            StateOnBoardSlotAction.BoardSlot = PlayerOnTurn.BoardSlot;
            CurrentState = StateOnBoardSlotAction;
        }

        public void ThrowDice(int playerId)
        {
            ThrowDice(playerId, 0, 0);
        }

        public void ThrowDice(int playerId, int die1, int die2)
        {
            if (CheckCanThrowDice(playerId))
            {
                ((StateOnPlayerTurn)CurrentState).ThrowDice(die1, die2);
            }
            else
            {
                throw new MonopolyAlertException("Player can't throw dice. Wait player's turn.");
            }
        }

        public void EndTurn()
        {
            CurrentPlayerIndex++;

            if (CurrentPlayerIndex > Board.PlayerList.Count - 1)
            {
                CurrentPlayerIndex = 0;
            }

            PlayerOnTurn = Board.PlayerList[CurrentPlayerIndex];

            ChangeToStateOnPlayerTurn();
        }

        public Player AddLocalPlayer(int id)
        {
            // Instantiate local player on master and clients
            Player player = new Player();
            player.Id = id;
            player.Name = Database.PlayerQueue.Dequeue().Name;
            player.PlayerColor = Database.PlayerColorQueue.Dequeue();
            Database.PlayerDictionary.Add(id, player);
            Owner = player;
            return player;
        }

        public void FillBoardWithPlayers()
        {
            foreach (Player item in Database.PlayerDictionary.Values)
            {
                Board.PlayerList.Add(item);
            }
        }

        public void FillBoardWithBoardSlots()
        {
            foreach (BoardSlot item in Database.BoardSlotDictionary.Values)
            {
                Board.BoardSlotList.Add(item);
            }
        }

        public void FillBankWithLotCards()
        {
            foreach (LotCard item in Database.TitleDeedCardList)
            {
                Board.Bank.LotCardList.Add(item);
            }
            foreach (LotCard item in Database.RailroadCardList)
            {
                Board.Bank.LotCardList.Add(item);
            }
            foreach (LotCard item in Database.UtilityCardList)
            {
                Board.Bank.LotCardList.Add(item);
            }
        }

        public void FillBankWithBuildings()
        {
            for (int i = 0; i < Constants.InitialNumberOfHouses; i++)
            {
                Building house = new Building(BuildingType.House);
                Board.Bank.BuildingList.Add(house);
            }
            for (int i = 0; i < Constants.InitialNumberOfHotels; i++)
            {
                Building hotel = new Building(BuildingType.Hotel);
                Board.Bank.BuildingList.Add(hotel);
            }
        }

        #endregion

        #region Check methods

        public bool CheckInState(string stateName)
        {
            return CurrentState.GetType().Name.Equals(stateName);
        }

        public bool CheckCanThrowDice(int playerId)
        {
            return (PlayerOnTurn.Id == playerId && CurrentState is StateOnPlayerTurn);
        }

        public int GetPlayerPositionOnBoard(int playerId)
        {
            return Board.FindIndexWherePlayerIs(Database.PlayerDictionary[playerId]);
        }

        public int GetNumberOfHousesWithBank()
        {
            int counter = 0;
            foreach (Building building in Board.Bank.BuildingList)
            {
                if (building.BuildingType.Equals(BuildingType.House))
                {
                    counter++;
                }
            }
            return counter;
        }

        public int GetNumberOfHotelsWithBank()
        {
            int counter = 0;
            foreach (Building building in Board.Bank.BuildingList)
            {
                if (building.BuildingType.Equals(BuildingType.Hotel))
                {
                    counter++;
                }
            }
            return counter;
        }

        #endregion

        #region Getters and Setters

        public VirtualDatabase Database { get; set; }

        public Player PlayerOnTurn { get; set; }

        public Board Board { get; set; }

        public State CurrentState { get; set; }

        public StateOnPreparation StateOnPreparation { get; set; }

        public StateOnPlayerTurn StateOnPlayerTurn { get; set; }

        public StateOnBoardSlotAction StateOnBoardSlotAction { get; set; }

        public Player Owner { get; set; }

        public bool IsGameStarted { get; set; }

        public StateOnClientPreparation StateOnClientPreparation { get; set; }

        public bool IsClientPrepared { get; set; }

        public int CurrentPlayerIndex { get; set; }

        public StateOnGameOver StateOnGameOver { get; set; }

        public bool IsGameOver { get; set; }

        #endregion

    }
}
