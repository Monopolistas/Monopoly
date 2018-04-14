using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastGameStateEvent : NetworkEvent
{

    public BroadcastGameStateEvent()
    {
    }

    public BroadcastGameStateEvent(int code) : base(code)
    {
    }

    public override void Broadcast(GameStateMachine gameStateMachine)
    {
    }

    public override void Execute(GameStateMachine gameStateMachine)
    {
        if (!IsMasterClient)
        {
            Player[] players = (Player[])Content;

            gameStateMachine.Board.PlayerList = new List<Player>(players);

            if (!gameStateMachine.IsClientPrepared)
            {
                gameStateMachine.ChangeState(gameStateMachine.StateOnClientPreparation);
            }
        }
    }
}
