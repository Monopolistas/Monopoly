using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastMovementEvent : NetworkEvent
{

    public BroadcastMovementEvent()
    {
        this.Code = NetworkEvent.BROADCAST_MOVEMENT_ID;
    }

    public BroadcastMovementEvent(int code) : base(code)
    {
    }

    public override void Execute(GameStateMachine gameStateMachine)
    {
        throw new System.NotImplementedException();
    }
}
