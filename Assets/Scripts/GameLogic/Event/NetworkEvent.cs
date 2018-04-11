using System;
using System.Collections.Generic;

public abstract class NetworkEvent
{
    public static NetworkEvent REQUEST_PLAYER = new RequestPlayerEvent(1);
    public static NetworkEvent BROADCAST_PLAYER = new BroadcastPlayerEvent(2);

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
