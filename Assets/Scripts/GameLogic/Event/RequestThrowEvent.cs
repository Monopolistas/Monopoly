using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestThrowEvent : NetworkEvent
{

    public RequestThrowEvent()
    {
        this.Code = NetworkEvent.REQUEST_THROW_ID;
    }

    public RequestThrowEvent(int code) : base(code)
    {
    }

    public override void Execute(GameStateMachine gameStateMachine)
    {
        throw new System.NotImplementedException();
    }
}
