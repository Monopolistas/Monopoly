using System;
using System.Collections.Generic;
using UnityEngine;

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

    void ShuffleCards()
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

    void GiveInitialCashToPlayers()
    {
        Board.Bank.Cash = Constants.BANK_INITIAL_CASH;

        foreach (Player item in Board.PlayerList)
        {
            (new Transaction(TransactionType.CREDIT, Board.Bank, item, Constants.INITIAL_CASH)).ExecuteTransaction();
        }
    }

    void ShufflePlayers()
    {
        ShuffleList<Player>.Shuffle(Board.PlayerList);
    }

    void SetFirstPlayerToPlay()
    {
        GameStateMachine.PlayerOnTurn = Board.PlayerList[0];
    }

    void PutPlayersInFirstBoardSlot()
    {
        foreach (Player item in Board.PlayerList)
        {
            Board.BoardSlotList[0].PlayerList.Add(item);
            item.BoardSlot = Board.BoardSlotList[0];
        }
    }
}
