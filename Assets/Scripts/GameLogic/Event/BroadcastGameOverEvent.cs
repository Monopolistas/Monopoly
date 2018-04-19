using System;
using Assets.Scripts.GameLogic.StateMachine;

namespace Assets.Scripts.GameLogic.Event
{
    public class BroadcastGameOverEvent : NetworkEvent
    {
        public BroadcastGameOverEvent()
        {
        }

        public BroadcastGameOverEvent(int code) : base(code)
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
