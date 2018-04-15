using ExitGames.Client.Photon;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateSerializerTest
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
    public void SerializeTest()
    {
        Player[] players = new Player[3];
        int index = 0;
        foreach (Player p in gameStateMachine.Database.PlayerDictionary.Values)
        {
            players[index] = p;
            index++;
        }
        GameState gameState = new GameState(players, gameStateMachine.Database.PlayerDictionary[1]);

        int size = 2 + 25 + 2 + (2 * 3) + 25 + 24 + 25;

        StreamBuffer buffer = new StreamBuffer(size);
        GameStateSerializer.gameStateMachine = gameStateMachine;
        GameStateSerializer.Serialize(buffer, gameState);
        buffer.Position = 0;
        GameState newGameState = (GameState)GameStateSerializer.Deserialize(buffer, (short)size);
        Assert.AreEqual(1, newGameState.PlayerOnTurn.Id);
        Assert.AreEqual("PLAYER 1", newGameState.PlayerOnTurn.Name);
        Assert.AreEqual(3, newGameState.Players.Length);
        Assert.AreEqual(1, newGameState.Players[0].Id);
        Assert.AreEqual("PLAYER 1", newGameState.Players[0].Name);
        Assert.AreEqual(2, newGameState.Players[1].Id);
        Assert.AreEqual("PLAYER 2", newGameState.Players[1].Name);
        Assert.AreEqual(3, newGameState.Players[2].Id);
        Assert.AreEqual("PLAYER 3", newGameState.Players[2].Name);
    }

}
