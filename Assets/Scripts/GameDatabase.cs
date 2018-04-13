using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDatabase : MonoBehaviour
{

    ResourcesLoader resourcesLoader;

    public GameController gameController;

    // Use this for initialization
    void Start()
    {
        resourcesLoader = new ResourcesLoader();

        resourcesLoader.GameStateMachine = gameController.gameStateMachine;

        string boardSlotXml = Resources.Load<TextAsset>("Xml/BoardSlot.xml").text;
        string chanceCardXml = Resources.Load<TextAsset>("Xml/ChanceCard.xml").text;
        string communityChestCardXml = Resources.Load<TextAsset>("Xml/CommunityChestCard.xml").text;
        string railroadCardXml = Resources.Load<TextAsset>("Xml/RailroadCard.xml").text;
        string titleDeedCardXml = Resources.Load<TextAsset>("Xml/TitleDeedCard.xml").text;
        string utilityCardXml = Resources.Load<TextAsset>("Xml/UtilityCard.xml").text;

        resourcesLoader.BoardSlotArray = BoardSlotXml.Deserialize(boardSlotXml).ToArray();
        resourcesLoader.ChanceCardArray = ChanceCardXml.Deserialize(chanceCardXml).ToArray();
        resourcesLoader.CommunityChestCardArray = CommunityChestCardXml.Deserialize(communityChestCardXml).ToArray();
        resourcesLoader.TitleDeedCardArray = TitleDeedCardXml.Deserialize(titleDeedCardXml).ToArray();
        resourcesLoader.RailroadCardArray = RailroadCardXml.Deserialize(railroadCardXml).ToArray();
        resourcesLoader.UtilityCardArray = UtilityCardXml.Deserialize(utilityCardXml).ToArray();

        resourcesLoader.FillDatabase();
    }

}
