using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNetwork : Photon.PunBehaviour
{
    public GameGui gameGui;
    public GameController gameController;

    GameStateMachine gameStateMachine;

    void Start()
    {
        PhotonPeer.RegisterType(typeof(Player), 255, PlayerSerializer.Serialize, PlayerSerializer.Deserialize);
    }

    public void JoinGame()
    {
        PhotonNetwork.ConnectUsingSettings(Constants.MONOPOLY_VERSION);
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
    }
}
