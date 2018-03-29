using System;

public class MonopolyAlertException : Exception
{
    string monopolyMessage;

    public MonopolyAlertException(string message) : base()
    {
        this.monopolyMessage = message;
    }

    public string MonopolyMessage
    {
        get
        {
            return monopolyMessage;
        }

        set
        {
            monopolyMessage = value;
        }
    }
}
