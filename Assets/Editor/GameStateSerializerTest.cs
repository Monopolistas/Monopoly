using Assets.Scripts.GameData;
using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.StateMachine;
using Assets.Scripts.Network;
using ExitGames.Client.Photon;
using NUnit.Framework;

namespace Assets.Editor
{
    public class GameStateSerializerTest
    {

        GameStateMachine _gameStateMachine;
        ResourcesLoader _resourcesLoader;

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
        public void SerializeTest()
        {
            Player[] players = new Player[3];
            int index = 0;
            foreach (Player p in _gameStateMachine.Database.PlayerDictionary.Values)
            {
                players[index] = p;
                index++;
            }
            GameState gameState = new GameState(players, _gameStateMachine.Database.PlayerDictionary[1], true);

            int size = 2 + 25 + 2 + (2 * 3) + 25 + 24 + 25 + 2;

            StreamBuffer buffer = new StreamBuffer(size);
            GameStateSerializer.GameStateMachine = _gameStateMachine;
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
            Assert.AreEqual(true, newGameState.IsGameOver);
        }

    }
}
