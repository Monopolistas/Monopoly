using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastPlayerEvent : NetworkEvent
{
    public BroadcastPlayerEvent()
    {
        this.Code = NetworkEvent.BROADCAST_PLAYER.Code;
    }

    public BroadcastPlayerEvent(int code) : base(code)
    {
    }

    public override void Execute(GameStateMachine gameStateMachine)
    {
        // Instantiate other players on clients
        Player[] received = (Player[])Content;

        foreach (Player p in received)
        {
            if (!gameStateMachine.Database.PlayerDictionary.ContainsKey(p.Id))
            {
                gameStateMachine.Database.PlayerDictionary.Add(p.Id, p);
            }
        }

        gameStateMachine.Owner = gameStateMachine.Database.PlayerDictionary[PhotonNetwork.player.ID];
    }
}
