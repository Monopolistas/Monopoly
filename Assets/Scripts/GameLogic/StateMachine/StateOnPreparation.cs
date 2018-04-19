using System.Collections.Generic;
using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameUtil;

namespace Assets.Scripts.GameLogic.StateMachine
{
    public class StateOnPreparation : State
    {

        public StateOnPreparation(GameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public override void ExecuteGameLogic()
        {
            GameStateMachine.FillBoardWithPlayers();
            GameStateMachine.FillBoardWithBoardSlots();
            GameStateMachine.FillBankWithLotCards();
            GameStateMachine.FillBankWithBuildings();
            ShuffleCards();
            GiveInitialCashToPlayers();
            ShufflePlayers();
            SetFirstPlayerToPlay();
            PutPlayersInFirstBoardSlot();
            GameStateMachine.ChangeToStateOnPlayerTurn();
            GameStateMachine.IsGameStarted = true;
        }

        private void ShuffleCards()
        {
            List<ChanceCard> chanceCardList = new List<ChanceCard>(GameStateMachine.Database.ChanceCardList);

            ShuffleList<ChanceCard>.Shuffle(chanceCardList);

            foreach (ChanceCard item in chanceCardList)
            {
                Board.ChanceCardQueue.Enqueue(item);
            }

            List<CommunityChestCard> communityChestCardList = new List<CommunityChestCard>(GameStateMachine.Database.CommunityChestCardList);

            ShuffleList<CommunityChestCard>.Shuffle(communityChestCardList);

            foreach (CommunityChestCard item in communityChestCardList)
            {
                Board.CommunityChestCardQueue.Enqueue(item);
            }
        }

        private void GiveInitialCashToPlayers()
        {
            Board.Bank.Cash = Constants.BankInitialCash;

            foreach (Player item in Board.PlayerList)
            {
                (new Transaction(TransactionType.Credit, Board.Bank, item, Constants.InitialCash)).ExecuteTransaction();
            }
        }

        private void ShufflePlayers()
        {
            ShuffleList<Player>.Shuffle(Board.PlayerList);
        }

        private void SetFirstPlayerToPlay()
        {
            GameStateMachine.PlayerOnTurn = Board.PlayerList[0];
        }

        private void PutPlayersInFirstBoardSlot()
        {
            foreach (Player item in Board.PlayerList)
            {
                Board.BoardSlotList[0].PlayerList.Add(item);
                item.BoardSlot = Board.BoardSlotList[0];
            }
        }
    }
}
