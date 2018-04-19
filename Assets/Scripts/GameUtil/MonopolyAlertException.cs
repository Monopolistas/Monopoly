using System;

namespace Assets.Scripts.GameUtil
{
    public class MonopolyAlertException : Exception
    {
        public MonopolyAlertException(string message)
        {
            MonopolyMessage = message;
        }

        public string MonopolyMessage { get; set; }
    }
}
