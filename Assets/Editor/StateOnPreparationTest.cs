using Assets.Scripts.GameData;
using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.StateMachine;
using Assets.Scripts.GameUtil;
using NUnit.Framework;

namespace Assets.Editor
{
    public class StateOnPreparationTest
    {
        private GameStateMachine _gameStateMachine;
        private ResourcesLoader _resourcesLoader;

        [SetUp]
        public void SetUp()
        {
            _gameStateMachine = new GameStateMachine();
            _resourcesLoader = new ResourcesLoader();

            _resourcesLoader.LoadXmlData();

            _gameStateMachine.Database.PlayerDictionary.Add(1, new Player(1, "Player1", PlayerColor.Black));
            _gameStateMachine.Database.PlayerDictionary.Add(2, new Player(2, "Player2", PlayerColor.White));
            _gameStateMachine.Database.PlayerDictionary.Add(3, new Player(3, "Player3", PlayerColor.Red));
            _resourcesLoader.GameStateMachine = _gameStateMachine;
            _resourcesLoader.FillDatabase();
            _gameStateMachine.ChangeState(new StateOnPreparation(_gameStateMachine));
        }

        [Test]
        public void ExecuteGameLogicTest()
        {
            _gameStateMachine.ExecuteGameLogic();

            Assert.AreEqual(16, _gameStateMachine.Board.ChanceCardQueue.Count);
            Assert.AreEqual(16, _gameStateMachine.Board.CommunityChestCardQueue.Count);
            Assert.AreEqual(3, _gameStateMachine.Board.PlayerList.Count);
            Assert.AreEqual(40, _gameStateMachine.Board.BoardSlotList.Count);
            Assert.NotNull(_gameStateMachine.PlayerOnTurn);
            Assert.NotNull(_gameStateMachine.Board);

            int playersCash = 0;

            foreach (Player player in _gameStateMachine.Board.PlayerList)
            {
                Assert.AreEqual(Constants.InitialCash, player.Cash);
                playersCash += Constants.InitialCash;
            }

            Assert.AreEqual(Constants.BankInitialCash - playersCash, _gameStateMachine.Board.Bank.Cash);
            Assert.AreEqual(3, _gameStateMachine.Board.BoardSlotList[0].PlayerList.Count);
            Assert.AreEqual(Constants.InitialNumberOfHouses, _gameStateMachine.GetNumberOfHousesWithBank());
            Assert.AreEqual(Constants.InitialNumberOfHotels, _gameStateMachine.GetNumberOfHotelsWithBank());

            Assert.IsTrue(_gameStateMachine.CheckInState("StateOnPlayerTurn"));
        }

    }
}
