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
        FillBoardWithPlayers();
        FillBoardWithBoardSlots();
        FillBankWithLotCards();
        FillBankWithBuildings();
        ShuffleCards();
        GiveInitialCashToPlayers();
        ShufflePlayers();
        SetFirstPlayerToPlay();
        PutPlayersInFirstBoardSlot();
        GameStateMachine.ChangeToStateOnPlayerTurn();
    }

    void FillBoardWithPlayers()
    {
        foreach (Player item in GameStateMachine.Database.PlayerDictionary.Values)
        {
            Board.PlayerList.Add(item);
        }
    }

    void FillBoardWithBoardSlots()
    {
        foreach (BoardSlot item in GameStateMachine.Database.BoardSlotDictionary.Values)
        {
            Board.BoardSlotList.Add(item);
        }
    }

    void FillBankWithLotCards()
    {
        foreach (LotCard item in GameStateMachine.Database.TitleDeedCardList)
        {
            Board.Bank.LotCardList.Add(item);
        }
        foreach (LotCard item in GameStateMachine.Database.RailroadCardList)
        {
            Board.Bank.LotCardList.Add(item);
        }
        foreach (LotCard item in GameStateMachine.Database.UtilityCardList)
        {
            Board.Bank.LotCardList.Add(item);
        }
    }

    void FillBankWithBuildings()
    {
        for (int i = 0; i < Constants.INITIAL_NUMBER_OF_HOUSES; i++)
        {
            Building house = new Building(BuildingType.HOUSE);
            Board.Bank.BuildingList.Add(house);
        }
        for (int i = 0; i < Constants.INITIAL_NUMBER_OF_HOTELS; i++)
        {
            Building hotel = new Building(BuildingType.HOTEL);
            Board.Bank.BuildingList.Add(hotel);
        }
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
