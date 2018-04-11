public class RequestPlayerEvent : NetworkEvent
{
    public RequestPlayerEvent()
    {
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

        Player[] players = new Player[gameStateMachine.Database.PlayerDictionary.Count];

        int index = 0;
        foreach (Player p in gameStateMachine.Database.PlayerDictionary.Values)
        {
            players[index] = p;
            index++;
        }

        RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
        raiseEventOptions.Receivers = ReceiverGroup.Others;
        PhotonNetwork.RaiseEvent(NetworkEvent.BROADCAST_PLAYER.CodeToByte(), players, true, raiseEventOptions);
    }
}
