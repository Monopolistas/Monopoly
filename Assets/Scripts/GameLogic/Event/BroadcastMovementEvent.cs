using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        throw new System.NotImplementedException();
    }

    public override void Execute(GameStateMachine gameStateMachine)
    {
        throw new System.NotImplementedException();
    }
}
