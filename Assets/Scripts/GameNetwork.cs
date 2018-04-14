using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNetwork : Photon.PunBehaviour
{
    public GameGui gameGui;
    public GameController gameController;

    GameStateMachine gameStateMachine;

    float updateTime;

    void Start()
    {
        PlayerSerializer.gameStateMachine = gameController.gameStateMachine;
        PhotonPeer.RegisterType(typeof(Player), 255, PlayerSerializer.Serialize, PlayerSerializer.Deserialize);
        updateTime = 0;
        gameStateMachine = gameController.gameStateMachine;
    }

    void Update()
    {
        if (gameStateMachine.IsGameStarted)
        {
            updateTime += Time.deltaTime;
            if (updateTime > Constants.UPDATE_TIME)
            {
                BroadcastGameState();
                updateTime = 0;
            }
        }
    }

    public void JoinGame()
    {
        PhotonNetwork.ConnectUsingSettings(Constants.MONOPOLY_VERSION);
    }

    public Player[] BuildPlayersOnBoardArray(GameStateMachine gameStateMachine)
    {
        Player[] players = new Player[gameStateMachine.Board.PlayerList.Count];
        gameStateMachine.Board.PlayerList.CopyTo(players, 0);
        return players;
    }

    public void BroadcastGameState()
    {
        if (PhotonNetwork.isMasterClient)
        {
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
            raiseEventOptions.Receivers = ReceiverGroup.Others;
            PhotonNetwork.RaiseEvent(NetworkEvent.BROADCAST_GAME_STATE.CodeToByte(), BuildPlayersOnBoardArray(gameStateMachine), true, raiseEventOptions);
        }
    }

    public override void OnJoinedLobby()
    {
        OnConnectedToMaster(); // this way, it does not matter if we join a lobby or not
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = Constants.MAX_PLAYERS;
        PhotonNetwork.JoinOrCreateRoom(Constants.ROOM_NAME, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        gameStateMachine = gameController.gameStateMachine;

        // Dequeue current joined players
        // Since this method is called once in the client at join phase, we dequeue already joined players
        int length = PhotonNetwork.countOfPlayers - 1;
        for (int i = 0; i < length; i++)
        {
            gameStateMachine.Database.PlayerQueue.Dequeue();
            gameStateMachine.Database.PlayerColorQueue.Dequeue();
        }

        // It is meant to change the state of Gui from ON_CONNECTING to ON_CONNECTED
        gameGui.ChangeState();

        if (!PhotonNetwork.isMasterClient)
        {
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
            raiseEventOptions.Receivers = ReceiverGroup.MasterClient;
            PhotonNetwork.RaiseEvent(NetworkEvent.REQUEST_PLAYER.CodeToByte(), null, true, raiseEventOptions);
        }
        else
        {
            gameStateMachine.AddLocalPlayer(PhotonNetwork.player.ID);
        }
    }

    // setup our OnEvent as callback:
    void OnEnable()
    {
        PhotonNetwork.OnEventCall += this.OnEvent;
    }

    void OnDisable()
    {
        PhotonNetwork.OnEventCall -= this.OnEvent;
    }

    // handle custom events:
    void OnEvent(byte eventcode, object content, int senderid)
    {
        NetworkEvent networkEvent = NetworkEvent.Instantiate(eventcode);
        networkEvent.IsMasterClient = PhotonNetwork.isMasterClient;
        networkEvent.Content = content;
        networkEvent.SenderId = senderid;
        networkEvent.Execute(gameStateMachine);
        networkEvent.Broadcast(gameStateMachine);
    }

    public GameStateMachine GameStateMachine
    {
        get
        {
            return gameStateMachine;
        }

        set
        {
            gameStateMachine = value;
        }
    }

}
