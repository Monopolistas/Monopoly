using Assets.Scripts.GameData;
using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.Event;
using Assets.Scripts.GameLogic.StateMachine;
using NUnit.Framework;

namespace Assets.Editor
{
    public class RequestPlayerEventTest
    {
        private GameStateMachine _gameStateMachine;
        private ResourcesLoader _resourcesLoader;
        private RequestPlayerEvent _requestPlayerEvent;

        [SetUp]
        public void SetUp()
        {
            _gameStateMachine = new GameStateMachine();
            _resourcesLoader = new ResourcesLoader();

            _resourcesLoader.LoadXmlData();

            Player p1 = _gameStateMachine.Database.PlayerQueue.Dequeue();
            Player p2 = _gameStateMachine.Database.PlayerQueue.Dequeue();
            Player p3 = _gameStateMachine.Database.PlayerQueue.Dequeue();
            PlayerColor pc1 = _gameStateMachine.Database.PlayerColorQueue.Dequeue();
            PlayerColor pc2 = _gameStateMachine.Database.PlayerColorQueue.Dequeue();
            PlayerColor pc3 = _gameStateMachine.Database.PlayerColorQueue.Dequeue();

            _gameStateMachine.Database.PlayerDictionary.Add(1, new Player(1, p1.Name, pc1));
            _gameStateMachine.Database.PlayerDictionary.Add(2, new Player(2, p2.Name, pc2));
            _gameStateMachine.Database.PlayerDictionary.Add(3, new Player(3, p3.Name, pc3));
            _resourcesLoader.GameStateMachine = _gameStateMachine;
            _resourcesLoader.FillDatabase();
            _gameStateMachine.ChangeState(new StateOnPreparation(_gameStateMachine));

            _requestPlayerEvent = new RequestPlayerEvent();
            _requestPlayerEvent.SenderId = 4;
        }

        [Test]
        public void ExecuteTest()
        {
            _requestPlayerEvent.Execute(_gameStateMachine);
            Assert.AreEqual(4, _gameStateMachine.Database.PlayerDictionary.Count);
            Assert.AreEqual(4, _gameStateMachine.Database.PlayerDictionary[4].Id);
            Assert.AreEqual("PLAYER 4", _gameStateMachine.Database.PlayerDictionary[4].Name);
            Assert.AreEqual("RED", _gameStateMachine.Database.PlayerDictionary[4].PlayerColor.Name);
            Assert.IsNull(_gameStateMachine.Database.PlayerDictionary[4].BoardSlot);
        }

        [Test]
        public void BuildPlayersArrayTest()
        {
            Player[] players = _requestPlayerEvent.BuildPlayersArray(_gameStateMachine);
            Assert.AreEqual(3, players.Length);
        }

    }
}
