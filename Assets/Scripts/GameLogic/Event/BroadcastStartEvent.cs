using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastStartEvent : NetworkEvent
{

    public BroadcastStartEvent()
    {
        this.Code = NetworkEvent.BROADCAST_START_ID;
    }

    public BroadcastStartEvent(int code) : base(code)
    {
    }

    public override void Execute(GameStateMachine gameStateMachine)
    {
        throw new System.NotImplementedException();
    }
}
