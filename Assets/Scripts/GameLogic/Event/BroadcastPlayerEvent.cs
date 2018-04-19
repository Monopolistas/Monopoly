using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.StateMachine;

namespace Assets.Scripts.GameLogic.Event
{
    public class BroadcastPlayerEvent : NetworkEvent
    {
        public BroadcastPlayerEvent()
        {
        }

        public BroadcastPlayerEvent(int code) : base(code)
        {
        }

        public override void Broadcast(GameStateMachine gameStateMachine)
        {
        }

        public override void Execute(GameStateMachine gameStateMachine)
        {
            // Instantiate other players on clients
            Player[] received = (Player[])Content;

            foreach (Player p in received)
            {
                if (!gameStateMachine.Database.PlayerDictionary.ContainsKey(p.Id))
                {
                    gameStateMachine.Database.PlayerDictionary.Add(p.Id, p);
                }
            }

            gameStateMachine.Owner = gameStateMachine.Database.PlayerDictionary[PhotonNetwork.player.ID];
        }
    }
}
