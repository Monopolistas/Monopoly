using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.IO;

public class RequestPlayerEventTest
{

    GameStateMachine gameStateMachine;
    ResourcesLoader resourcesLoader;
    RequestPlayerEvent requestPlayerEvent;

    [SetUp]
    public void SetUp()
    {
        gameStateMachine = new GameStateMachine();
        resourcesLoader = new ResourcesLoader();

        string boardSlotXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\BoardSlot.xml");
        string chanceCardXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\ChanceCard.xml");
        string communityChestCardXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\CommunityChestCard.xml");
        string railroadCardXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\RailroadCard.xml");
        string titleDeedCardXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\TitleDeedCard.xml");
        string utilityCardXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\UtilityCard.xml");

        resourcesLoader.BoardSlotArray = BoardSlotXml.Deserialize(boardSlotXml).ToArray();
        resourcesLoader.ChanceCardArray = ChanceCardXml.Deserialize(chanceCardXml).ToArray();
        resourcesLoader.CommunityChestCardArray = CommunityChestCardXml.Deserialize(communityChestCardXml).ToArray();
        resourcesLoader.TitleDeedCardArray = TitleDeedCardXml.Deserialize(titleDeedCardXml).ToArray();
        resourcesLoader.RailroadCardArray = RailroadCardXml.Deserialize(railroadCardXml).ToArray();
        resourcesLoader.UtilityCardArray = UtilityCardXml.Deserialize(utilityCardXml).ToArray();

        Player p1 = gameStateMachine.Database.PlayerQueue.Dequeue();
        Player p2 = gameStateMachine.Database.PlayerQueue.Dequeue();
        Player p3 = gameStateMachine.Database.PlayerQueue.Dequeue();
        PlayerColor pc1 = gameStateMachine.Database.PlayerColorQueue.Dequeue();
        PlayerColor pc2 = gameStateMachine.Database.PlayerColorQueue.Dequeue();
        PlayerColor pc3 = gameStateMachine.Database.PlayerColorQueue.Dequeue();

        gameStateMachine.Database.PlayerDictionary.Add(1, new Player(1, p1.Name, pc1));
        gameStateMachine.Database.PlayerDictionary.Add(2, new Player(2, p2.Name, pc2));
        gameStateMachine.Database.PlayerDictionary.Add(3, new Player(3, p3.Name, pc3));
        resourcesLoader.GameStateMachine = gameStateMachine;
        resourcesLoader.FillDatabase();
        gameStateMachine.ChangeState(new StateOnPreparation(gameStateMachine));

        requestPlayerEvent = new RequestPlayerEvent();
        requestPlayerEvent.SenderId = 4;
    }

    [Test]
    public void ExecuteTest()
    {
        requestPlayerEvent.Execute(gameStateMachine);
        Assert.AreEqual(4, gameStateMachine.Database.PlayerDictionary.Count);
        Assert.AreEqual(4, gameStateMachine.Database.PlayerDictionary[4].Id);
        Assert.AreEqual("PLAYER 4", gameStateMachine.Database.PlayerDictionary[4].Name);
        Assert.AreEqual("BLUE", gameStateMachine.Database.PlayerDictionary[4].PlayerColor.Name);
        Assert.IsNull(gameStateMachine.Database.PlayerDictionary[4].BoardSlot);
    }

    [Test]
    public void BuildPlayersArrayTest()
    {
        Player[] players = requestPlayerEvent.BuildPlayersArray(gameStateMachine);
        Assert.AreEqual(3, players.Length);
    }

}
