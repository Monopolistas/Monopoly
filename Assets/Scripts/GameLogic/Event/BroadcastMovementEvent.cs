using System;
using Assets.Scripts.GameLogic.StateMachine;

namespace Assets.Scripts.GameLogic.Event
{
    public class BroadcastMovementEvent : NetworkEvent
    {

        public BroadcastMovementEvent()
        {
        }

        public BroadcastMovementEvent(int code) : base(code)
        {
        }

        public override void Broadcast(GameStateMachine gameStateMachine)
        {
            throw new NotImplementedException();
        }

        public override void Execute(GameStateMachine gameStateMachine)
        {
            throw new NotImplementedException();
        }
    }
}
