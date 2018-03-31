using UnityEngine;

public class GameStateMachine : IMonopolyCore
{

    StateOnStart stateOnStart;
    StateOnPreparation stateOnPreparation;
    StateOnPlayerTurn stateOnPlayerTurn;
    StateOnBoardSlotAction stateOnBoardSlotAction;

    State currentState;

    Board board;

    Player playerOnTurn;

    VirtualDatabase virtualDatabase;

    public GameStateMachine()
    {
        board = new Board();

        InitializeStates();

        virtualDatabase = new VirtualDatabase();

        this.currentState = stateOnStart;
    }

    void InitializeStates()
    {
        stateOnStart = new StateOnStart(this);
        stateOnPreparation = new StateOnPreparation(this);
        stateOnPlayerTurn = new StateOnPlayerTurn(this);
        stateOnBoardSlotAction = new StateOnBoardSlotAction(this);
    }

    public void ExecuteGameLogic()
    {
        this.currentState.ExecuteGameLogic();
    }

    #region Machine commands

    public void ChangeState(State state)
    {
        this.currentState = state;
    }

    public void ChangeToStateOnPlayerTurn()
    {
        StateOnPlayerTurn.PlayerOnTurn = playerOnTurn;
        StateOnPlayerTurn.PlayerTurn = new PlayerTurn();
        StateOnPlayerTurn.PlayerTurn.Player = playerOnTurn;
        this.currentState = StateOnPlayerTurn;
    }

    public void ChangeToStateOnBoardSlotAction()
    {
        StateOnBoardSlotAction.StateBefore = this.currentState;
        StateOnBoardSlotAction.BoardSlot = playerOnTurn.BoardSlot;
        this.currentState = StateOnBoardSlotAction;
    }

    public void ThrowDice(int playerId)
    {
        ThrowDice(playerId, 0, 0);
    }

    public void ThrowDice(int playerId, int die1, int die2)
    {
        if (CheckCanThrowDice(playerId))
        {
            ((StateOnPlayerTurn)currentState).ThrowDice(die1, die2);
        }
        else
        {
            throw new MonopolyAlertException("Player can't throw dice. Wait player's turn.");
        }
    }

    #endregion

    #region Database methods

    public void AddBoardSlot(BoardSlot boardSlot)
    {
        virtualDatabase.AddBoardSlot(boardSlot);
    }

    public void AddChanceCard(ChanceCard chanceCard)
    {
        chanceCard.BoardSlot = chanceCard.BoardSlotId == 0 ? null : virtualDatabase.FindBoardSlotById(chanceCard.BoardSlotId);
        virtualDatabase.AddChanceCard(chanceCard);
    }

    public void AddCommunityChestCard(CommunityChestCard communityChestCard)
    {
        communityChestCard.BoardSlot = communityChestCard.BoardSlotId == 0 ? null : virtualDatabase.FindBoardSlotById(communityChestCard.BoardSlotId);
        virtualDatabase.AddCommunityChestCard(communityChestCard);
    }

    public void AddTitleDeedCard(TitleDeedCard titleDeedCard)
    {
        virtualDatabase.AddTitleDeedCard(titleDeedCard);
    }

    public void AddLot(Lot lot)
    {
        Card card = virtualDatabase.FindCardById(lot.LotCardId);
        lot.LotCard = lot.LotCardId == 0 ? null : (LotCard)card;
        virtualDatabase.AddLot(lot);
        if (card is TitleDeedCard)
        {
            ((TitleDeedCard)card).Lot = lot;
        }
        if (card is RailroadCard)
        {
            ((RailroadCard)card).Lot = lot;
        }
        if (card is UtilityCard)
        {
            ((UtilityCard)card).Lot = lot;
        }
    }

    public void AddRailroadCard(RailroadCard railroadCard)
    {
        virtualDatabase.AddRailroadCard(railroadCard);
    }

    public void AddUtilityCard(UtilityCard utilityCard)
    {
        virtualDatabase.AddUtilityCard(utilityCard);
    }

    public void AddPlayer(int id, string name, string playerColor)
    {
        Player player = new Player();
        player.Id = id;
        player.Name = name;
        player.PlayerColor = PlayerColor.FindByName(playerColor);
        virtualDatabase.AddPlayer(player);
    }

    #endregion

    #region Check methods

    public bool CheckInState(string stateName)
    {
        return this.currentState.GetType().Name.Equals(stateName);
    }

    public bool CheckCanThrowDice(int playerId)
    {
        return (playerOnTurn.Id == playerId && currentState is StateOnPlayerTurn);
    }

    public int GetNumberOfPlayers()
    {
        return this.Database.GetNumberOfPlayers();
    }

    public int GetNumberOfBoardSlots()
    {
        return this.Database.GetNumberOfBoardSlots();
    }

    public int GetNumberOfChanceCards()
    {
        return this.Database.GetNumberOfChanceCards();
    }

    public int GetNumberOfCommunityChestCards()
    {
        return this.Database.GetNumberOfCommunityChestCards();
    }

    public int GetNumberOfTitleDeedCards()
    {
        return this.Database.GetNumberOfTitleDeedCards();
    }

    public int GetNumberOfRailroadCards()
    {
        return this.Database.GetNumberOfRailroadCards();
    }

    public int GetNumberOfUtilityCards()
    {
        return this.Database.GetNumberOfUtilityCards();
    }

    public int GetNumberOfLots()
    {
        return this.Database.GetNumberOfLots();
    }

    public int GetNumberOfEnqueuedChanceCards()
    {
        return board.ChanceCardQueue.Count;
    }

    public int GetNumberOfEnqueuedCommunityChestCards()
    {
        return board.CommunityChestCardQueue.Count;
    }

    public int GetNumberOfPlayersInGame()
    {
        return board.PlayerList.Count;
    }

    public int GetNumberOfBoardSlotsInBoard()
    {
        return board.BoardSlotList.Count;
    }

    public int GetNumberOfPlayersInBoardSlot(int index)
    {
        return board.BoardSlotList[index].PlayerList.Count;
    }

    public int GetPlayerPositionOnBoard(int playerId)
    {
        return board.FindIndexWherePlayerIs(virtualDatabase.FindPlayerById(playerId));
    }

    public int GetNumberOfHousesWithBank()
    {
        int counter = 0;
        foreach (Building building in board.Bank.BuildingList)
        {
            if (building.BuildingType.Equals(BuildingType.HOUSE))
            {
                counter++;
            }
        }
        return counter;
    }

    public int GetNumberOfHotelsWithBank()
    {
        int counter = 0;
        foreach (Building building in board.Bank.BuildingList)
        {
            if (building.BuildingType.Equals(BuildingType.HOTEL))
            {
                counter++;
            }
        }
        return counter;
    }

    #endregion

    #region Getters and Setters

    public VirtualDatabase Database
    {
        get
        {
            return this.virtualDatabase;
        }
    }

    public Player PlayerOnTurn
    {
        get
        {
            return playerOnTurn;
        }

        set
        {
            playerOnTurn = value;
        }
    }

    public Board Board
    {
        get
        {
            return board;
        }

        set
        {
            board = value;
        }
    }

    public State CurrentState
    {
        get
        {
            return currentState;
        }

        set
        {
            currentState = value;
        }
    }

    public StateOnPreparation StateOnPreparation
    {
        get
        {
            return stateOnPreparation;
        }

        set
        {
            stateOnPreparation = value;
        }
    }

    public StateOnPlayerTurn StateOnPlayerTurn
    {
        get
        {
            return stateOnPlayerTurn;
        }

        set
        {
            stateOnPlayerTurn = value;
        }
    }

    public StateOnBoardSlotAction StateOnBoardSlotAction
    {
        get
        {
            return stateOnBoardSlotAction;
        }

        set
        {
            stateOnBoardSlotAction = value;
        }
    }

    #endregion

}
