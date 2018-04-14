using System;
using System.Collections.Generic;

public abstract class NetworkEvent
{
    public static int REQUEST_PLAYER_ID = 1;
    public static int BROADCAST_PLAYER_ID = 2;
    public static int BROADCAST_GAME_STATE_ID = 3;
    public static int REQUEST_THROW_ID = 4;
    public static int BROADCAST_MOVEMENT_ID = 5;
    public static int BROADCAST_GAME_OVER_ID = 6;

    public static NetworkEvent REQUEST_PLAYER = new RequestPlayerEvent(REQUEST_PLAYER_ID);
    public static NetworkEvent BROADCAST_PLAYER = new BroadcastPlayerEvent(BROADCAST_PLAYER_ID);
    public static NetworkEvent BROADCAST_GAME_STATE = new BroadcastStartEvent(BROADCAST_GAME_STATE_ID);
    public static NetworkEvent REQUEST_THROW = new RequestThrowEvent(REQUEST_THROW_ID);
    public static NetworkEvent BROADCAST_MOVEMENT = new BroadcastMovementEvent(BROADCAST_MOVEMENT_ID);
    public static NetworkEvent BROADCAST_GAME_OVER = new BroadcastGameOverEvent(BROADCAST_GAME_OVER_ID);

    int code;
    int senderId;
    object content;

    bool isMasterClient;

    public NetworkEvent()
    {

    }

    public NetworkEvent(int code)
    {
        this.code = code;
    }

    public static IEnumerable<NetworkEvent> Values
    {
        get
        {
            yield return REQUEST_PLAYER;
            yield return BROADCAST_PLAYER;
            yield return BROADCAST_GAME_STATE;
            yield return REQUEST_THROW;
            yield return BROADCAST_MOVEMENT;
            yield return BROADCAST_GAME_OVER;
        }
    }

    public static NetworkEvent Instantiate(int code)
    {
        foreach (NetworkEvent item in Values)
        {
            if (item.Code.Equals(code))
            {
                return item;
            }
        }

        return null;
    }

    public abstract void Execute(GameStateMachine gameStateMachine);

    public abstract void Broadcast(GameStateMachine gameStateMachine);

    public byte CodeToByte()
    {
        return Convert.ToByte(code);
    }

    #region Getters and Setters

    public int Code
    {
        get
        {
            return code;
        }

        set
        {
            code = value;
        }
    }

    public int SenderId
    {
        get
        {
            return senderId;
        }
        set
        {
            senderId = value;
        }
    }

    public bool IsMasterClient
    {
        get
        {
            return isMasterClient;
        }

        set
        {
            isMasterClient = value;
        }
    }

    public object Content
    {
        get
        {
            return content;
        }

        set
        {
            content = value;
        }
    }

    #endregion
}
