using Assets.Scripts.GameData;
using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.StateMachine;
using Assets.Scripts.GameUtil;
using NUnit.Framework;

namespace Assets.Editor
{
    public class StateOnPlayerTurnTest
    {
        private GameStateMachine _gameStateMachine;
        private ResourcesLoader _resourcesLoader;

        private int _idPlayerOnTurn;
        private int _idNoPlayerOnTurn;

        private int GetNoPlayerInTurnId(int id)
        {
            foreach (Player player in _gameStateMachine.Board.PlayerList)
            {
                if (!player.Id.Equals(_idPlayerOnTurn))
                {
                    _idNoPlayerOnTurn = player.Id;
                    break;
                }
            }
            return _idNoPlayerOnTurn;
        }

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

            // Execute onPreparation and enters OnPlayerTurn
            _gameStateMachine.ExecuteGameLogic();

            _idPlayerOnTurn = _gameStateMachine.PlayerOnTurn.Id;
            _idNoPlayerOnTurn = GetNoPlayerInTurnId(_idPlayerOnTurn);
        }

        [Test]
        public void ThrowDiceTest()
        {
            _gameStateMachine.ThrowDice(_idPlayerOnTurn);

            Assert.AreEqual(StateOnPlayerTurn.StateEnum.OnMove, ((StateOnPlayerTurn)_gameStateMachine.CurrentState).CurrentState);
            Assert.NotNull(((StateOnPlayerTurn)_gameStateMachine.CurrentState).DiceThrow);
        }

        [Test]
        public void ThrowDiceDoubleTest()
        {
            _gameStateMachine.ThrowDice(_idPlayerOnTurn, 5, 5);

            Assert.AreEqual(StateOnPlayerTurn.StateEnum.OnMove, ((StateOnPlayerTurn)_gameStateMachine.CurrentState).CurrentState);
            Assert.NotNull(((StateOnPlayerTurn)_gameStateMachine.CurrentState).PlayerTurn);
            Assert.AreEqual(1, ((StateOnPlayerTurn)_gameStateMachine.CurrentState).PlayerTurn.DiceThrowList.Count);

            // TODO: test if the player keeps playing
        }

        [Test]
        public void ThrowDiceNoPlayerOnTurnTest()
        {
            Assert.Throws<MonopolyAlertException>(delegate { _gameStateMachine.ThrowDice(_idNoPlayerOnTurn); });
        }

        [Test]
        public void ExecuteGameLogicAfterDiceThrownTest()
        {
            _gameStateMachine.ThrowDice(_idPlayerOnTurn, 3, 5);

            _gameStateMachine.ExecuteGameLogic();

            Assert.AreEqual(8, _gameStateMachine.GetPlayerPositionOnBoard(_idPlayerOnTurn));

            _gameStateMachine.ExecuteGameLogic();

            Assert.IsTrue(_gameStateMachine.CheckInState("StateOnBoardSlotAction"));
        }

    }
}
