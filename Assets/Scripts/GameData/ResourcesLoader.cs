using System.IO;
using UnityEngine;

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

    public void LoadXmlData()
    {
        string boardSlotXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\BoardSlot.xml");
        string chanceCardXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\ChanceCard.xml");
        string communityChestCardXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\CommunityChestCard.xml");
        string railroadCardXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\RailroadCard.xml");
        string titleDeedCardXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\TitleDeedCard.xml");
        string utilityCardXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\UtilityCard.xml");

        ConvertXmlToArray(boardSlotXml, chanceCardXml, communityChestCardXml, railroadCardXml, titleDeedCardXml, utilityCardXml);
    }

    public void LoadXmlDataFromUnity()
    {
        string boardSlotXml = Resources.Load<TextAsset>("Xml/BoardSlot").text;
        string chanceCardXml = Resources.Load<TextAsset>("Xml/ChanceCard").text;
        string communityChestCardXml = Resources.Load<TextAsset>("Xml/CommunityChestCard").text;
        string railroadCardXml = Resources.Load<TextAsset>("Xml/RailroadCard").text;
        string titleDeedCardXml = Resources.Load<TextAsset>("Xml/TitleDeedCard").text;
        string utilityCardXml = Resources.Load<TextAsset>("Xml/UtilityCard").text;

        ConvertXmlToArray(boardSlotXml, chanceCardXml, communityChestCardXml, railroadCardXml, titleDeedCardXml, utilityCardXml);
    }

    public void ConvertXmlToArray(string boardSlotXml, string chanceCardXml, string communityChestCardXml, string railroadCardXml, string titleDeedCardXml, string utilityCardXml)
    {
        BoardSlotArray = BoardSlotXml.Deserialize(boardSlotXml).ToArray();
        ChanceCardArray = ChanceCardXml.Deserialize(chanceCardXml).ToArray();
        CommunityChestCardArray = CommunityChestCardXml.Deserialize(communityChestCardXml).ToArray();
        TitleDeedCardArray = TitleDeedCardXml.Deserialize(titleDeedCardXml).ToArray();
        RailroadCardArray = RailroadCardXml.Deserialize(railroadCardXml).ToArray();
        UtilityCardArray = UtilityCardXml.Deserialize(utilityCardXml).ToArray();
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
