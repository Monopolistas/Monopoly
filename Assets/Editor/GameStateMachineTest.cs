using Assets.Scripts.GameData;
using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.StateMachine;
using NUnit.Framework;

namespace Assets.Editor
{
    public class GameStateMachineTest
    {
        private GameStateMachine _gameStateMachine;
        private ResourcesLoader _resourcesLoader;

        [SetUp]
        public void SetUp()
        {
            _gameStateMachine = new GameStateMachine();
            _resourcesLoader = new ResourcesLoader();

            _resourcesLoader.LoadXmlData();

            _gameStateMachine.AddLocalPlayer(1);
            _gameStateMachine.AddLocalPlayer(2);
            _gameStateMachine.AddLocalPlayer(3);

            _resourcesLoader.GameStateMachine = _gameStateMachine;

            _resourcesLoader.FillDatabase();
        }

        [Test]
        public void CheckOnStartTest()
        {
            Assert.IsTrue(_gameStateMachine.CheckInState("StateOnStart"));
        }

        [Test]
        public void CheckNumberOfPlayersTest()
        {
            Assert.AreEqual(3, _gameStateMachine.Database.PlayerDictionary.Count);
        }

        [Test]
        public void CheckNumberOfBoardSlotsTest()
        {
            Assert.AreEqual(40, _gameStateMachine.Database.BoardSlotDictionary.Count);
        }

        [Test]
        public void CheckNumberOfTitleDeedCardsTest()
        {
            Assert.AreEqual(22, _gameStateMachine.Database.TitleDeedCardList.Count);
        }

        [Test]
        public void CheckNumberOfRailroadCardsTest()
        {
            Assert.AreEqual(4, _gameStateMachine.Database.RailroadCardList.Count);
        }

        [Test]
        public void CheckNumberOfUtilityCardsTest()
        {
            Assert.AreEqual(2, _gameStateMachine.Database.UtilityCardList.Count);
        }

        [Test]
        public void CheckNumberOfLotsTest()
        {
            Assert.AreEqual(28, _gameStateMachine.Database.LotDictionary.Count);
        }

        [Test]
        public void AddLocalPlayerTest()
        {
            Assert.AreEqual(Player.Player1.Name, _gameStateMachine.Database.PlayerDictionary[1].Name);
            Assert.AreEqual(Player.Player2.Name, _gameStateMachine.Database.PlayerDictionary[2].Name);
            Assert.AreEqual(Player.Player3.Name, _gameStateMachine.Database.PlayerDictionary[3].Name);
            Assert.AreEqual(PlayerColor.Black.Name, _gameStateMachine.Database.PlayerDictionary[1].PlayerColor.Name);
            Assert.AreEqual(PlayerColor.Blue.Name, _gameStateMachine.Database.PlayerDictionary[2].PlayerColor.Name);
            Assert.AreEqual(PlayerColor.Green.Name, _gameStateMachine.Database.PlayerDictionary[3].PlayerColor.Name);
            Assert.AreEqual(3, _gameStateMachine.Database.PlayerQueue.Count);
            Assert.AreEqual(3, _gameStateMachine.Database.PlayerColorQueue.Count);
            Assert.AreEqual(3, _gameStateMachine.Database.PlayerDictionary.Count);
        }

    }
}
