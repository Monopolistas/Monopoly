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
            gameStateMachine.AddBoardSlot((BoardSlot) item);
        }

        foreach (ChanceCardScriptableObject item in chanceCardUnityArray)
        {
            gameStateMachine.AddChanceCard((ChanceCard) item);
        }

        foreach (CommunityChestCardScriptableObject item in communityChestCardUnityArray)
        {
            gameStateMachine.AddCommunityChestCard((CommunityChestCard) item);
        }

        foreach (RailroadCardScriptableObject item in railroadCardUnityArray)
        {
            gameStateMachine.AddRailroadCard((RailroadCard) item);
            gameStateMachine.AddLot((Lot) item);
        }

        foreach (TitleDeedCardScriptableObject item in titleDeedCardUnityArray)
        {
            gameStateMachine.AddTitleDeedCard((TitleDeedCard) item);
            gameStateMachine.AddLot((Lot) item);
        }


        foreach (UtilityCardScriptableObject item in utilityCardUnityArray)
        {
            gameStateMachine.AddUtilityCard((UtilityCard) item);
            gameStateMachine.AddLot((Lot)item);
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
