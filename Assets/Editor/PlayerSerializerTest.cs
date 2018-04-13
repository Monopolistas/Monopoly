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
