using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class GameStateMachineTest
{

    GameStateMachine gameStateMachine;
    ResourcesLoader resourcesLoader;

    [OneTimeSetUp]
    public void SetUp()
    {
        gameStateMachine = new GameStateMachine();
        resourcesLoader = new ResourcesLoader();
        gameStateMachine.AddPlayer(1, "Player1", PlayerColor.BLACK.Name);
        gameStateMachine.AddPlayer(2, "Player2", PlayerColor.WHITE.Name);
        gameStateMachine.AddPlayer(3, "Player3", PlayerColor.RED.Name);
        resourcesLoader.GameStateMachine = gameStateMachine;
        resourcesLoader.FillDatabase();
    }

    [Test]
    public void CheckOnPreparationTest()
    {
        Assert.IsTrue(gameStateMachine.CheckInState("StateOnPreparation"));
    }

    [Test]
    public void CheckNumberOfPlayersTest()
    {
        Assert.AreEqual(3, gameStateMachine.GetNumberOfPlayers());
    }

    [Test]
    public void CheckNumberOfBoardSlotsTest()
    {
        Assert.AreEqual(40, gameStateMachine.GetNumberOfBoardSlots());
    }

    [Test]
    public void CheckNumberOfTitleDeedCardsTest()
    {
        Assert.AreEqual(22, gameStateMachine.GetNumberOfTitleDeedCards());
    }

    [Test]
    public void CheckNumberOfRailroadCardsTest()
    {
        Assert.AreEqual(4, gameStateMachine.GetNumberOfRailroadCards());
    }

    [Test]
    public void CheckNumberOfUtilityCardsTest()
    {
        Assert.AreEqual(2, gameStateMachine.GetNumberOfUtilityCards());
    }

    [Test]
    public void CheckNumberOfLotsTest()
    {
        Assert.AreEqual(28, gameStateMachine.GetNumberOfLots());
    }

}
