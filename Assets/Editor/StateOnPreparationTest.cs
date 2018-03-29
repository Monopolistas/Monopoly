using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class StateOnPreparationTest
{
    GameStateMachine gameStateMachine;
    ResourcesLoader resourcesLoader;

    [SetUp]
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
    public void ExecuteGameLogicTest()
    {
        gameStateMachine.ExecuteGameLogic();

        Assert.AreEqual(16, gameStateMachine.GetNumberOfEnqueuedChanceCards());
        Assert.AreEqual(16, gameStateMachine.GetNumberOfEnqueuedCommunityChestCards());
        Assert.AreEqual(3, gameStateMachine.GetNumberOfPlayersInGame());
        Assert.AreEqual(40, gameStateMachine.GetNumberOfBoardSlotsInBoard());
        Assert.NotNull(gameStateMachine.PlayerOnTurn);
        Assert.NotNull(gameStateMachine.Board);

        int playersCash = 0;

        foreach (Player player in gameStateMachine.Board.PlayerList)
        {
            Assert.AreEqual(Constants.INITIAL_CASH, player.Cash);
            playersCash += Constants.INITIAL_CASH;
        }

        Assert.AreEqual(Constants.BANK_INITIAL_CASH - playersCash, gameStateMachine.Board.Bank.Cash);
        Assert.AreEqual(3, gameStateMachine.GetNumberOfPlayersInBoardSlot(0));

        Assert.IsTrue(gameStateMachine.CheckInState("StateOnPlayerTurn"));
    }

}
