using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastGameOverEvent : NetworkEvent
{
    public BroadcastGameOverEvent()
    {
        this.Code = NetworkEvent.BROADCAST_GAME_OVER_ID;
    }

    public BroadcastGameOverEvent(int code) : base(code)
    {
    }

    public override void Execute(GameStateMachine gameStateMachine)
    {
        throw new System.NotImplementedException();
    }
}
