using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.IO;

public class GameStateMachineTest
{

    GameStateMachine gameStateMachine;
    ResourcesLoader resourcesLoader;

    [SetUp]
    public void SetUp()
    {
        gameStateMachine = new GameStateMachine();
        resourcesLoader = new ResourcesLoader();

        resourcesLoader.LoadXmlData();

        gameStateMachine.AddLocalPlayer(1);
        gameStateMachine.AddLocalPlayer(2);
        gameStateMachine.AddLocalPlayer(3);

        resourcesLoader.GameStateMachine = gameStateMachine;

        resourcesLoader.FillDatabase();
    }

    [Test]
    public void CheckOnStartTest()
    {
        Assert.IsTrue(gameStateMachine.CheckInState("StateOnStart"));
    }

    [Test]
    public void CheckNumberOfPlayersTest()
    {
        Assert.AreEqual(3, gameStateMachine.Database.PlayerDictionary.Count);
    }

    [Test]
    public void CheckNumberOfBoardSlotsTest()
    {
        Assert.AreEqual(40, gameStateMachine.Database.BoardSlotDictionary.Count);
    }

    [Test]
    public void CheckNumberOfTitleDeedCardsTest()
    {
        Assert.AreEqual(22, gameStateMachine.Database.TitleDeedCardList.Count);
    }

    [Test]
    public void CheckNumberOfRailroadCardsTest()
    {
        Assert.AreEqual(4, gameStateMachine.Database.RailroadCardList.Count);
    }

    [Test]
    public void CheckNumberOfUtilityCardsTest()
    {
        Assert.AreEqual(2, gameStateMachine.Database.UtilityCardList.Count);
    }

    [Test]
    public void CheckNumberOfLotsTest()
    {
        Assert.AreEqual(28, gameStateMachine.Database.LotDictionary.Count);
    }

    [Test]
    public void AddLocalPlayerTest()
    {
        Assert.AreEqual(Player.PLAYER_1.Name, gameStateMachine.Database.PlayerDictionary[1].Name);
        Assert.AreEqual(Player.PLAYER_2.Name, gameStateMachine.Database.PlayerDictionary[2].Name);
        Assert.AreEqual(Player.PLAYER_3.Name, gameStateMachine.Database.PlayerDictionary[3].Name);
        Assert.AreEqual(PlayerColor.BLACK.Name, gameStateMachine.Database.PlayerDictionary[1].PlayerColor.Name);
        Assert.AreEqual(PlayerColor.BLUE.Name, gameStateMachine.Database.PlayerDictionary[2].PlayerColor.Name);
        Assert.AreEqual(PlayerColor.GREEN.Name, gameStateMachine.Database.PlayerDictionary[3].PlayerColor.Name);
        Assert.AreEqual(3, gameStateMachine.Database.PlayerQueue.Count);
        Assert.AreEqual(3, gameStateMachine.Database.PlayerColorQueue.Count);
        Assert.AreEqual(3, gameStateMachine.Database.PlayerDictionary.Count);
    }

}
