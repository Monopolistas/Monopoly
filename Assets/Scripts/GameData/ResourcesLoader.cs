using UnityEngine;

public class ResourcesLoader
{
    BoardSlotScriptableObject[] boardSlotUnityArray;

    ChanceCardScriptableObject[] chanceCardUnityArray;

    CommunityChestCardScriptableObject[] communityChestCardUnityArray;

    RailroadCardScriptableObject[] railroadCardUnityArray;

    TitleDeedCardScriptableObject[] titleDeedCardUnityArray;

    UtilityCardScriptableObject[] utilityCardUnityArray;

    GameStateMachine gameStateMachine;

    public void FillDatabase()
    {
        boardSlotUnityArray = Resources.LoadAll<BoardSlotScriptableObject>("BoardSlots");
        chanceCardUnityArray = Resources.LoadAll<ChanceCardScriptableObject>("ChanceCards");
        communityChestCardUnityArray = Resources.LoadAll<CommunityChestCardScriptableObject>("CommunityChestCards");
        railroadCardUnityArray = Resources.LoadAll<RailroadCardScriptableObject>("RailroadCards");
        titleDeedCardUnityArray = Resources.LoadAll<TitleDeedCardScriptableObject>("TitleDeedCards");
        utilityCardUnityArray = Resources.LoadAll<UtilityCardScriptableObject>("UtilityCards");

        foreach (BoardSlotScriptableObject item in boardSlotUnityArray)
        {
            gameStateMachine.Database.BoardSlotDictionary.Add(item.id, (BoardSlot)item);
        }

        foreach (ChanceCardScriptableObject item in chanceCardUnityArray)
        {
            gameStateMachine.Database.CardDictionary.Add(item.id, (ChanceCard)item);
            gameStateMachine.Database.ChanceCardList.Add((ChanceCard)item);
        }

        foreach (CommunityChestCardScriptableObject item in communityChestCardUnityArray)
        {
            gameStateMachine.Database.CardDictionary.Add(item.id, (CommunityChestCard)item);
            gameStateMachine.Database.CommunityChestCardList.Add((CommunityChestCard)item);
        }

        foreach (RailroadCardScriptableObject item in railroadCardUnityArray)
        {
            gameStateMachine.Database.CardDictionary.Add(item.id, (RailroadCard)item);
            gameStateMachine.Database.RailroadCardList.Add((RailroadCard)item);
            gameStateMachine.Database.LotDictionary.Add(item.id, (Lot)item);
        }

        foreach (TitleDeedCardScriptableObject item in titleDeedCardUnityArray)
        {
            gameStateMachine.Database.CardDictionary.Add(item.id, (TitleDeedCard)item);
            gameStateMachine.Database.TitleDeedCardList.Add((TitleDeedCard)item);
            gameStateMachine.Database.LotDictionary.Add(item.id, (Lot)item);
        }


        foreach (UtilityCardScriptableObject item in utilityCardUnityArray)
        {
            gameStateMachine.Database.CardDictionary.Add(item.id, (UtilityCard)item);
            gameStateMachine.Database.UtilityCardList.Add((UtilityCard)item);
            gameStateMachine.Database.LotDictionary.Add(item.id, (Lot)item);
        }
    }

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
}
