using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.StateMachine;

namespace Assets.Scripts.GameLogic.Event
{
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
        }

        public void BroadcastPlayers(GameStateMachine gameStateMachine)
        {
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
            raiseEventOptions.Receivers = ReceiverGroup.Others;
            PhotonNetwork.RaiseEvent(BroadcastPlayer.CodeToByte(), BuildPlayersArray(gameStateMachine), true, raiseEventOptions);
        }

        public Player[] BuildPlayersArray(GameStateMachine gameStateMachine)
        {
            Player[] players = new Player[gameStateMachine.Database.PlayerDictionary.Count];
            gameStateMachine.Database.PlayerDictionary.Values.CopyTo(players, 0);
            return players;
        }

        public override void Broadcast(GameStateMachine gameStateMachine)
        {
            BroadcastPlayers(gameStateMachine);
        }
    }
}
