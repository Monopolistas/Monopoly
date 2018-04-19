using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.StateMachine;
using Assets.Scripts.GameUtil;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameGui : MonoBehaviour
    {

        public GameController GameController;

        public GameNetwork GameNetwork;

        public Button Join;
        public Button StartGame;
        public Button Quit;
        public Button ThrowDice;

        public Text ConnectionText;
        public Text PlayerNameText;
        public Text OtherPlayersNameText;

        public GameObject Black;
        public GameObject Blue;
        public GameObject Green;
        public GameObject Red;
        public GameObject White;
        public GameObject Yellow;

        public enum StateEnum
        {
            OnStart = 1,
            OnJoinPressed = 2,
            OnConnecting = 3,
            OnConnected = 4,
            OnStartPressed = 5,
            OnPlayersCreation = 6,
            OnGame = 7,
            OnGameOver = 8
        }

        private GameStateMachine _gameStateMachine;
        private StateEnum _currentState;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            _gameStateMachine = GameController.GameStateMachine;

            _currentState = StateEnum.OnStart;
        }

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            switch (_currentState)
            {
                case StateEnum.OnStart:
                    Join.interactable = true;
                    StartGame.interactable = false;
                    ThrowDice.interactable = false;
                    break;
                case StateEnum.OnJoinPressed:
                    Join.interactable = false;
                    ChangeState();
                    break;
                case StateEnum.OnConnecting:
                    ConnectionText.text = "Connecting...";
                    break;
                case StateEnum.OnConnected:
                    ConnectionText.text = "Connected!";
                    PlayerNameText.text = _gameStateMachine.Owner == null ? "" : _gameStateMachine.Owner.Name + ":" + PhotonNetwork.player;
                    if (_gameStateMachine.Database.PlayerDictionary.Count > 0)
                    {
                        string names = "";
                        foreach (Player item in _gameStateMachine.Database.PlayerDictionary.Values)
                        {
                            names += item.Name + "\n";
                        }
                        OtherPlayersNameText.text = names;
                    }
                    if (PhotonNetwork.isMasterClient)
                    {
                        StartGame.interactable = true;
                    }
                    else
                    {
                        if (_gameStateMachine.IsClientPrepared && _gameStateMachine.IsGameStarted)
                        {
                            ChangeState(StateEnum.OnPlayersCreation);
                        }
                    }
                    break;
                case StateEnum.OnStartPressed:
                    if (PhotonNetwork.isMasterClient)
                    {
                        StartGame.interactable = false;
                    }
                    ChangeState();
                    break;
                case StateEnum.OnPlayersCreation:
                    if (_gameStateMachine.IsGameStarted &&
                        _gameStateMachine.Board != null &&
                        _gameStateMachine.Board.PlayerList != null &&
                        _gameStateMachine.Board.PlayerList.Count > 0)
                    {
                        InstantiatePlayers();
                        ChangeState();
                    }
                    break;
                case StateEnum.OnGame:
                    if (_gameStateMachine.IsGameStarted &&
                        _gameStateMachine.Board != null &&
                        _gameStateMachine.Board.PlayerList != null &&
                        _gameStateMachine.Board.PlayerList.Count > 0)
                    {
                        if (_gameStateMachine.Board.PlayerList.Count > 0)
                        {
                            string names = "";
                            foreach (Player item in _gameStateMachine.Board.PlayerList)
                            {
                                // Write players' names
                                if (item.Id.Equals(_gameStateMachine.PlayerOnTurn.Id))
                                {
                                    names += "=> " + item.Name + " <=\n";
                                }
                                else
                                {
                                    names += item.Name + "\n";
                                }

                                // Update players' position
                                UpdatePlayersPositions(item);
                            }
                            OtherPlayersNameText.text = names;
                        }
                        if (_gameStateMachine.Owner.Id.Equals(_gameStateMachine.PlayerOnTurn.Id))
                        {
                            ThrowDice.interactable = true;
                        }
                        if (_gameStateMachine.IsGameOver)
                        {
                            ChangeState();
                        }
                    }
                    break;
                case StateEnum.OnGameOver:
                    Join.interactable = false;
                    StartGame.interactable = false;
                    ThrowDice.interactable = false;
                    break;
            }
        }

        private void UpdatePlayersPositions(Player item)
        {
            int index = _gameStateMachine.Board.FindIndexWherePlayerIs(item);

            float x = Constants.StartX;
            float y = Constants.StartY;
            if (index >= 0 && index <= 10)
            {
                float offsetX = (index * Constants.TileBoardSize);
                float offsetY = 0;
                x += offsetX;
                y += offsetY;
            }
            if (index >= 11 && index <= 20)
            {
                index -= 10;
                float offsetX = 10 * Constants.TileBoardSize;
                float offsetY = index * Constants.TileBoardSize;
                x += offsetX;
                y += offsetY;
            }
            if (index >= 21 && index <= 30)
            {
                index -= 20;
                index = 10 - index;
                float offsetX = index * Constants.TileBoardSize;
                float offsetY = 10 * Constants.TileBoardSize;
                x += offsetX;
                y += offsetY;
            }
            if (index >= 31)
            {
                index -= 30;
                index = 10 - index;
                float offsetX = 0;
                float offsetY = index * Constants.TileBoardSize;
                x += offsetX;
                y += offsetY;
            }

            if (_gameStateMachine.IsGameOver && _gameStateMachine.PlayerOnTurn.Id.Equals(item.Id))
            {
                x = Constants.StartX;
                y = Constants.StartY;
            }

            if (item.PlayerColor.Name.Equals(PlayerColor.Black.Name))
            {
                Black.transform.position = new Vector3(x, y, 0);
            }
            if (item.PlayerColor.Name.Equals(PlayerColor.Blue.Name))
            {
                Blue.transform.position = new Vector3(x, y, 0);
            }
            if (item.PlayerColor.Name.Equals(PlayerColor.Green.Name))
            {
                Green.transform.position = new Vector3(x, y, 0);
            }
            if (item.PlayerColor.Name.Equals(PlayerColor.Red.Name))
            {
                Red.transform.position = new Vector3(x, y, 0);
            }
            if (item.PlayerColor.Name.Equals(PlayerColor.White.Name))
            {
                White.transform.position = new Vector3(x, y, 0);
            }
            if (item.PlayerColor.Name.Equals(PlayerColor.Yellow.Name))
            {
                Yellow.transform.position = new Vector3(x, y, 0);
            }
        }

        public void OnClickJoin()
        {
            ChangeState();
            GameNetwork.JoinGame();
        }

        public void OnQuit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        public void OnClickStartGame()
        {
            _gameStateMachine.ChangeState(_gameStateMachine.StateOnPreparation);
            ChangeState();
        }

        public void OnClickThrowDice()
        {
            _gameStateMachine.ThrowDice(_gameStateMachine.Owner.Id);
        }

        public void OnEndGame()
        {
            ChangeState();
        }

        public void InstantiatePlayers()
        {
            foreach (Player p in _gameStateMachine.Board.PlayerList)
            {
                float x = Constants.StartX;
                float y = Constants.StartY;
                Black.transform.position = new Vector3(x, y, 0);
                Blue.transform.position = new Vector3(x, y, 0);
                Green.transform.position = new Vector3(x, y, 0);
                Red.transform.position = new Vector3(x, y, 0);
                White.transform.position = new Vector3(x, y, 0);
                Yellow.transform.position = new Vector3(x, y, 0);
                if (p.PlayerColor.Name.Equals(PlayerColor.Black.Name))
                {
                    Black = Instantiate(Black);
                }
                if (p.PlayerColor.Name.Equals(PlayerColor.Blue.Name))
                {
                    Blue = Instantiate(Black);
                }
                if (p.PlayerColor.Name.Equals(PlayerColor.Green.Name))
                {
                    Green = Instantiate(Black);
                }
                if (p.PlayerColor.Name.Equals(PlayerColor.Red.Name))
                {
                    Red = Instantiate(Black);
                }
                if (p.PlayerColor.Name.Equals(PlayerColor.White.Name))
                {
                    White = Instantiate(Black);
                }
                if (p.PlayerColor.Name.Equals(PlayerColor.Yellow.Name))
                {
                    Yellow = Instantiate(Black);
                }
            }
        }

        public void ChangeState(StateEnum state)
        {
            _currentState = state;
        }

        public void ChangeState()
        {
            switch (_currentState)
            {
                case StateEnum.OnStart:
                    _currentState = StateEnum.OnJoinPressed;
                    break;
                case StateEnum.OnJoinPressed:
                    _currentState = StateEnum.OnConnecting;
                    break;
                case StateEnum.OnConnecting:
                    _currentState = StateEnum.OnConnected;
                    break;
                case StateEnum.OnConnected:
                    _currentState = StateEnum.OnStartPressed;
                    break;
                case StateEnum.OnStartPressed:
                    _currentState = StateEnum.OnPlayersCreation;
                    break;
                case StateEnum.OnPlayersCreation:
                    _currentState = StateEnum.OnGame;
                    break;
                case StateEnum.OnGame:
                    _currentState = StateEnum.OnGameOver;
                    break;
            }
        }

    }
}
