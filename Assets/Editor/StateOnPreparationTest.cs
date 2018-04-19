using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.IO;
using Assets.Scripts.GameData;
using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.StateMachine;
using Assets.Scripts.GameUtil;

public class StateOnPreparationTest
{
    GameStateMachine gameStateMachine;
    ResourcesLoader resourcesLoader;

    [SetUp]
    public void SetUp()
    {
        gameStateMachine = new GameStateMachine();
        resourcesLoader = new ResourcesLoader();

        resourcesLoader.LoadXmlData();

        gameStateMachine.Database.PlayerDictionary.Add(1, new Player(1, "Player1", PlayerColor.Black));
        gameStateMachine.Database.PlayerDictionary.Add(2, new Player(2, "Player2", PlayerColor.White));
        gameStateMachine.Database.PlayerDictionary.Add(3, new Player(3, "Player3", PlayerColor.Red));
        resourcesLoader.GameStateMachine = gameStateMachine;
        resourcesLoader.FillDatabase();
        gameStateMachine.ChangeState(new StateOnPreparation(gameStateMachine));
    }

    [Test]
    public void ExecuteGameLogicTest()
    {
        gameStateMachine.ExecuteGameLogic();

        Assert.AreEqual(16, gameStateMachine.Board.ChanceCardQueue.Count);
        Assert.AreEqual(16, gameStateMachine.Board.CommunityChestCardQueue.Count);
        Assert.AreEqual(3, gameStateMachine.Board.PlayerList.Count);
        Assert.AreEqual(40, gameStateMachine.Board.BoardSlotList.Count);
        Assert.NotNull(gameStateMachine.PlayerOnTurn);
        Assert.NotNull(gameStateMachine.Board);

        int playersCash = 0;

        foreach (Player player in gameStateMachine.Board.PlayerList)
        {
            Assert.AreEqual(Constants.InitialCash, player.Cash);
            playersCash += Constants.InitialCash;
        }

        Assert.AreEqual(Constants.BankInitialCash - playersCash, gameStateMachine.Board.Bank.Cash);
        Assert.AreEqual(3, gameStateMachine.Board.BoardSlotList[0].PlayerList.Count);
        Assert.AreEqual(Constants.InitialNumberOfHouses, gameStateMachine.GetNumberOfHousesWithBank());
        Assert.AreEqual(Constants.InitialNumberOfHotels, gameStateMachine.GetNumberOfHotelsWithBank());

        Assert.IsTrue(gameStateMachine.CheckInState("StateOnPlayerTurn"));
    }

}
