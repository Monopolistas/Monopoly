using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.Event;
using Assets.Scripts.GameLogic.StateMachine;
using Assets.Scripts.GameUtil;
using Assets.Scripts.Network;
using ExitGames.Client.Photon;
using Photon;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameNetwork : PunBehaviour
    {
        public GameGui GameGui;
        public GameController GameController;
        private GameStateMachine _gameStateMachine;
        private float _updateTime;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            GameStateSerializer.GameStateMachine = GameController.GameStateMachine;
            PlayerSerializer.GameStateMachine = GameController.GameStateMachine;
            PhotonPeer.RegisterType(typeof(Player), 255, PlayerSerializer.Serialize, PlayerSerializer.Deserialize);
            PhotonPeer.RegisterType(typeof(GameState), 254, GameStateSerializer.Serialize, GameStateSerializer.Deserialize);
            _updateTime = 0;
            _gameStateMachine = GameController.GameStateMachine;
        }

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            // Update clients every 2 secs
            if (_gameStateMachine.IsGameStarted)
            {
                _updateTime += Time.deltaTime;
                if (_updateTime > Constants.UpdateTime)
                {
                    BroadcastGameState();
                    _updateTime = 0;
                }
            }
        }

        public void JoinGame()
        {
            PhotonNetwork.ConnectUsingSettings(Constants.MonopolyVersion);
        }

        public GameState CreateGameState(GameStateMachine gameStateMachine)
        {
            GameState gameState = new GameState
            {
                PlayerOnTurn = gameStateMachine.PlayerOnTurn,
                Players = gameStateMachine.Board.PlayerList.ToArray()
            };
            return gameState;
        }

        public void BroadcastGameState()
        {
            if (PhotonNetwork.isMasterClient)
            {
                RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(NetworkEvent.BroadcastGameState.CodeToByte(), CreateGameState(_gameStateMachine), true, raiseEventOptions);
            }
        }

        public override void OnJoinedLobby()
        {
            OnConnectedToMaster(); // this way, it does not matter if we join a lobby or not
        }

        public override void OnConnectedToMaster()
        {
            RoomOptions roomOptions = new RoomOptions
            {
                MaxPlayers = Constants.MaxPlayers
            };
            PhotonNetwork.JoinOrCreateRoom(Constants.RoomName, roomOptions, TypedLobby.Default);
        }

        public override void OnJoinedRoom()
        {
            _gameStateMachine = GameController.GameStateMachine;

            // Dequeue current joined players
            // Since this method is called once in the client at join phase, we dequeue already joined players
            int length = PhotonNetwork.countOfPlayers - 1;
            for (int i = 0; i < length; i++)
            {
                _gameStateMachine.Database.PlayerQueue.Dequeue();
                _gameStateMachine.Database.PlayerColorQueue.Dequeue();
            }

            // It is meant to change the state of Gui from ON_CONNECTING to ON_CONNECTED
            GameGui.ChangeState();

            if (!PhotonNetwork.isMasterClient)
            {
                RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.MasterClient
                };
                PhotonNetwork.RaiseEvent(NetworkEvent.RequestPlayer.CodeToByte(), null, true, raiseEventOptions);
            }
            else
            {
                _gameStateMachine.AddLocalPlayer(PhotonNetwork.player.ID);
            }
        }

        // ReSharper disable once UnusedMember.Local
        private void OnEnable()
        {
            PhotonNetwork.OnEventCall += OnEvent;
        }

        // ReSharper disable once UnusedMember.Local
        private void OnDisable()
        {
            // ReSharper disable once DelegateSubtraction
            PhotonNetwork.OnEventCall -= OnEvent;
        }

        // handle custom events:
        private void OnEvent(byte eventcode, object content, int senderid)
        {
            NetworkEvent networkEvent = NetworkEvent.Instantiate(eventcode);
            networkEvent.IsMasterClient = PhotonNetwork.isMasterClient;
            networkEvent.Content = content;
            networkEvent.SenderId = senderid;
            networkEvent.Execute(_gameStateMachine);
            networkEvent.Broadcast(_gameStateMachine);
        }

        public GameStateMachine GameStateMachine
        {
            get
            {
                return _gameStateMachine;
            }

            set
            {
                _gameStateMachine = value;
            }
        }

    }
}
