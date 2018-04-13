﻿using UnityEngine;

public class ResourcesLoader
{
    BoardSlot[] boardSlotArray;

    ChanceCard[] chanceCardArray;

    CommunityChestCard[] communityChestCardArray;

    RailroadCard[] railroadCardArray;

    TitleDeedCard[] titleDeedCardArray;

    UtilityCard[] utilityCardArray;

    GameStateMachine gameStateMachine;

    public void FillDatabase()
    {
        foreach (BoardSlot item in boardSlotArray)
        {
            gameStateMachine.Database.BoardSlotDictionary.Add(item.Id, item);
        }

        foreach (ChanceCard item in chanceCardArray)
        {
            gameStateMachine.Database.CardDictionary.Add(item.Id, item);
            gameStateMachine.Database.ChanceCardList.Add(item);
        }

        foreach (CommunityChestCard item in communityChestCardArray)
        {
            gameStateMachine.Database.CardDictionary.Add(item.Id, item);
            gameStateMachine.Database.CommunityChestCardList.Add(item);
        }

        foreach (RailroadCard item in railroadCardArray)
        {
            gameStateMachine.Database.CardDictionary.Add(item.Id, item);
            gameStateMachine.Database.RailroadCardList.Add(item);
            gameStateMachine.Database.LotDictionary.Add(item.Id, (Lot)item);
        }

        foreach (TitleDeedCard item in titleDeedCardArray)
        {
            gameStateMachine.Database.CardDictionary.Add(item.Id, item);
            gameStateMachine.Database.TitleDeedCardList.Add(item);
            gameStateMachine.Database.LotDictionary.Add(item.Id, (Lot)item);
        }


        foreach (UtilityCard item in utilityCardArray)
        {
            gameStateMachine.Database.CardDictionary.Add(item.Id, item);
            gameStateMachine.Database.UtilityCardList.Add(item);
            gameStateMachine.Database.LotDictionary.Add(item.Id, (Lot)item);
        }
    }

    #region Getters and Setters

    public GameStateMachine GameStateMachine
    {
        get
        {
            return gameStateMachine;
        }

        set
        {
            gameStateMachine = value;
        }
    }

    public ChanceCard[] ChanceCardArray
    {
        get
        {
            return chanceCardArray;
        }

        set
        {
            chanceCardArray = value;
        }
    }

    public CommunityChestCard[] CommunityChestCardArray
    {
        get
        {
            return communityChestCardArray;
        }

        set
        {
            communityChestCardArray = value;
        }
    }

    public RailroadCard[] RailroadCardArray
    {
        get
        {
            return railroadCardArray;
        }

        set
        {
            railroadCardArray = value;
        }
    }

    public TitleDeedCard[] TitleDeedCardArray
    {
        get
        {
            return titleDeedCardArray;
        }

        set
        {
            titleDeedCardArray = value;
        }
    }

    public UtilityCard[] UtilityCardArray
    {
        get
        {
            return utilityCardArray;
        }

        set
        {
            utilityCardArray = value;
        }
    }

    public BoardSlot[] BoardSlotArray
    {
        get
        {
            return boardSlotArray;
        }

        set
        {
            boardSlotArray = value;
        }
    }

    #endregion
}
