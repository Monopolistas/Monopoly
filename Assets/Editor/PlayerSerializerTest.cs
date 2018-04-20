using Assets.Scripts.GameData;
using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.StateMachine;
using Assets.Scripts.Network;
using ExitGames.Client.Photon;
using NUnit.Framework;

namespace Assets.Editor
{
    public class PlayerSerializerTest
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

            _resourcesLoader.GameStateMachine = _gameStateMachine;

            _resourcesLoader.FillDatabase();
        }

        [Test]
        public void SerializeTest()
        {
            _gameStateMachine.Owner.BoardSlot = _gameStateMachine.Database.BoardSlotDictionary[1];

            StreamBuffer buffer = new StreamBuffer(25);
            PlayerSerializer.GameStateMachine = _gameStateMachine;
            PlayerSerializer.Serialize(buffer, _gameStateMachine.Owner);
            buffer.Position = 0;
            Player newPlayer = (Player)PlayerSerializer.Deserialize(buffer, 25);
            Assert.AreEqual(1, newPlayer.Id);
            Assert.AreEqual("PLAYER 1", newPlayer.Name);
        }

        [Test]
        public void SerializeBoardSlotNullTest()
        {
            StreamBuffer buffer = new StreamBuffer(25);
            PlayerSerializer.GameStateMachine = _gameStateMachine;
            PlayerSerializer.Serialize(buffer, _gameStateMachine.Owner);
            buffer.Position = 0;
            Player newPlayer = (Player)PlayerSerializer.Deserialize(buffer, 25);
            Assert.AreEqual(1, newPlayer.Id);
            Assert.AreEqual("PLAYER 1", newPlayer.Name);
        }
    }
}
