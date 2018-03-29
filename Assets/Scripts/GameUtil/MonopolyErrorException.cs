using System;

public class MonopolyErrorException : Exception
{
    string monopolyMessage;

    public MonopolyErrorException(string message) : base()
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
