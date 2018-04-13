using ExitGames.Client.Photon;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class PlayerSerializerTest
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

        resourcesLoader.GameStateMachine = gameStateMachine;

        resourcesLoader.FillDatabase();
    }

    [Test]
    public void SerializeTest()
    {
        gameStateMachine.Owner.BoardSlot = gameStateMachine.Database.BoardSlotDictionary[1];

        StreamBuffer buffer = new StreamBuffer(25);
        PlayerSerializer.gameStateMachine = gameStateMachine;
        PlayerSerializer.Serialize(buffer, gameStateMachine.Owner);
        buffer.Position = 0;
        Player newPlayer = (Player)PlayerSerializer.Deserialize(buffer, 25);
        Assert.AreEqual(1, newPlayer.Id);
        Assert.AreEqual("PLAYER 1", newPlayer.Name);
    }

    [Test]
    public void SerializeBoardSlotNullTest()
    {
        StreamBuffer buffer = new StreamBuffer(25);
        PlayerSerializer.gameStateMachine = gameStateMachine;
        PlayerSerializer.Serialize(buffer, gameStateMachine.Owner);
        buffer.Position = 0;
        Player newPlayer = (Player)PlayerSerializer.Deserialize(buffer, 25);
        Assert.AreEqual(1, newPlayer.Id);
        Assert.AreEqual("PLAYER 1", newPlayer.Name);
    }
}
