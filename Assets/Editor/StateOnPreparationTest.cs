using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.IO;

public class StateOnPreparationTest
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

        gameStateMachine.Database.PlayerDictionary.Add(1, new Player(1, "Player1", PlayerColor.BLACK));
        gameStateMachine.Database.PlayerDictionary.Add(2, new Player(2, "Player2", PlayerColor.WHITE));
        gameStateMachine.Database.PlayerDictionary.Add(3, new Player(3, "Player3", PlayerColor.RED));
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
            Assert.AreEqual(Constants.INITIAL_CASH, player.Cash);
            playersCash += Constants.INITIAL_CASH;
        }

        Assert.AreEqual(Constants.BANK_INITIAL_CASH - playersCash, gameStateMachine.Board.Bank.Cash);
        Assert.AreEqual(3, gameStateMachine.Board.BoardSlotList[0].PlayerList.Count);
        Assert.AreEqual(Constants.INITIAL_NUMBER_OF_HOUSES, gameStateMachine.GetNumberOfHousesWithBank());
        Assert.AreEqual(Constants.INITIAL_NUMBER_OF_HOTELS, gameStateMachine.GetNumberOfHotelsWithBank());

        Assert.IsTrue(gameStateMachine.CheckInState("StateOnPlayerTurn"));
    }

}
