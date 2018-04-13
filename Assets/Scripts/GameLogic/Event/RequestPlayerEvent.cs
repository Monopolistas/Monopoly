public class RequestPlayerEvent : NetworkEvent
{
    public RequestPlayerEvent()
    {
        this.Code = NetworkEvent.REQUEST_PLAYER_ID;
    }

    public RequestPlayerEvent(int code) : base(code)
    {
    }

    public override void Execute(GameStateMachine gameStateMachine)
    {
        // Instantiate other players on master
        Player sender = new Player();
        sender.Id = SenderId;
        sender.Name = gameStateMachine.Database.PlayerQueue.Dequeue().Name;
        sender.PlayerColor = gameStateMachine.Database.PlayerColorQueue.Dequeue();
        gameStateMachine.Database.PlayerDictionary.Add(SenderId, sender);

        BroadcastPlayers(gameStateMachine);
    }

    private void BroadcastPlayers(GameStateMachine gameStateMachine)
    {
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
        raiseEventOptions.Receivers = ReceiverGroup.Others;
        PhotonNetwork.RaiseEvent(NetworkEvent.BROADCAST_PLAYER.CodeToByte(), BuildPlayersArray(gameStateMachine), true, raiseEventOptions);
    }

    public Player[] BuildPlayersArray(GameStateMachine gameStateMachine)
    {
        Player[] players = new Player[gameStateMachine.Database.PlayerDictionary.Count];
        gameStateMachine.Database.PlayerDictionary.Values.CopyTo(players, 0);
        return players;
    }
}
