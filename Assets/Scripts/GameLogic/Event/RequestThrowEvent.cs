﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestThrowEvent : NetworkEvent
{

    public RequestThrowEvent()
    {
    }

    public RequestThrowEvent(int code) : base(code)
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