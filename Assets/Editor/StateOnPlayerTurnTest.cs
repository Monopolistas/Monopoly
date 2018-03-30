using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class StateOnPlayerTurnTest
{

    GameStateMachine gameStateMachine;
    ResourcesLoader resourcesLoader;

    int idPlayerOnTurn;
    int idNoPlayerOnTurn;

    int GetNoPlayerInTurnId(int id)
    {
        foreach (Player player in gameStateMachine.Board.PlayerList)
        {
            if (!player.Id.Equals(idPlayerOnTurn))
            {
                idNoPlayerOnTurn = player.Id;
                break;
            }
        }
        return idNoPlayerOnTurn;
    }

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

        // Execute onPreparation and enters OnPlayerTurn
        gameStateMachine.ExecuteGameLogic();

        idPlayerOnTurn = gameStateMachine.PlayerOnTurn.Id;
        idNoPlayerOnTurn = GetNoPlayerInTurnId(idPlayerOnTurn);
    }

    [Test]
    public void ThrowDiceTest()
    {
        gameStateMachine.ThrowDice(idPlayerOnTurn);

        Assert.AreEqual(StateOnPlayerTurn.StateEnum.ON_MOVE, ((StateOnPlayerTurn)gameStateMachine.CurrentState).CurrentState);
        Assert.NotNull(((StateOnPlayerTurn)gameStateMachine.CurrentState).DiceThrow);
    }

    [Test]
    public void ThrowDiceDoubleTest()
    {
        gameStateMachine.ThrowDice(idPlayerOnTurn, 5, 5);

        Assert.AreEqual(StateOnPlayerTurn.StateEnum.ON_MOVE, ((StateOnPlayerTurn)gameStateMachine.CurrentState).CurrentState);
        Assert.NotNull(((StateOnPlayerTurn)gameStateMachine.CurrentState).PlayerTurn);
        Assert.AreEqual(1, ((StateOnPlayerTurn)gameStateMachine.CurrentState).PlayerTurn.DiceThrowList.Count);

        // TODO: test if the player keeps playing
    }

    [Test]
    public void ThrowDiceNoPlayerOnTurnTest()
    {
        Assert.Throws<MonopolyAlertException>(delegate { gameStateMachine.ThrowDice(idNoPlayerOnTurn); });
    }

    [Test]
    public void ExecuteGameLogicAfterDiceThrownTest()
    {
        gameStateMachine.ThrowDice(idPlayerOnTurn, 3, 5);

        gameStateMachine.ExecuteGameLogic();

        Assert.AreEqual(8, gameStateMachine.GetPlayerPositionOnBoard(idPlayerOnTurn));

        gameStateMachine.ExecuteGameLogic();

        Assert.IsTrue(gameStateMachine.CheckInState("StateOnBoardSlotAction"));
    }

}
