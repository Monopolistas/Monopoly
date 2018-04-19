using System;

namespace Assets.Scripts.GameUtil
{
    public class MonopolyErrorException : Exception
    {
        public MonopolyErrorException(string message)
        {
            MonopolyMessage = message;
        }

        public string MonopolyMessage { get; set; }
    }
}
