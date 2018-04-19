using System;
using System.Collections.Generic;
using Assets.Scripts.GameLogic.StateMachine;

namespace Assets.Scripts.GameLogic.Event
{
    public abstract class NetworkEvent
    {
        public static int RequestPlayerId = 1;
        public static int BroadcastPlayerId = 2;
        public static int BroadcastGameStateId = 3;
        public static int RequestThrowId = 4;
        public static int BroadcastMovementId = 5;
        public static int BroadcastGameOverId = 6;

        public static NetworkEvent RequestPlayer = new RequestPlayerEvent(RequestPlayerId);
        public static NetworkEvent BroadcastPlayer = new BroadcastPlayerEvent(BroadcastPlayerId);
        public static NetworkEvent BroadcastGameState = new BroadcastGameStateEvent(BroadcastGameStateId);
        public static NetworkEvent RequestThrow = new RequestThrowEvent(RequestThrowId);
        public static NetworkEvent BroadcastMovement = new BroadcastMovementEvent(BroadcastMovementId);
        public static NetworkEvent BroadcastGameOver = new BroadcastGameOverEvent(BroadcastGameOverId);
        private int _code;
        private int _senderId;
        private object _content;
        private bool _isMasterClient;

        protected NetworkEvent()
        {

        }

        protected NetworkEvent(int code)
        {
            _code = code;
        }

        public static IEnumerable<NetworkEvent> Values
        {
            get
            {
                yield return RequestPlayer;
                yield return BroadcastPlayer;
                yield return BroadcastGameState;
                yield return RequestThrow;
                yield return BroadcastMovement;
                yield return BroadcastGameOver;
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
            return Convert.ToByte(_code);
        }

        #region Getters and Setters

        public int Code
        {
            get
            {
                return _code;
            }

            set
            {
                _code = value;
            }
        }

        public int SenderId
        {
            get
            {
                return _senderId;
            }
            set
            {
                _senderId = value;
            }
        }

        public bool IsMasterClient
        {
            get
            {
                return _isMasterClient;
            }

            set
            {
                _isMasterClient = value;
            }
        }

        public object Content
        {
            get
            {
                return _content;
            }

            set
            {
                _content = value;
            }
        }

        #endregion
    }
}
