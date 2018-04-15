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
            GameState gameState = (GameState)Content;

            gameStateMachine.Board.PlayerList = new List<Player>(gameState.Players);
            gameStateMachine.PlayerOnTurn = gameState.PlayerOnTurn;

            if (!gameStateMachine.IsClientPrepared)
            {
                gameStateMachine.ChangeState(gameStateMachine.StateOnClientPreparation);
            }
        }
    }
}
