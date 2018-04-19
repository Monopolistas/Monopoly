using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.StateMachine;

namespace Assets.Scripts.GameLogic
{
    public interface IMonopolyCore
    {

        #region Machine commands

        void ChangeState(State state);
        void ThrowDice(int playerId);
        void ThrowDice(int playerId, int die1, int die2);
        Player AddLocalPlayer(int id);

        #endregion

        #region Check methods

        bool CheckInState(string stateName);
        bool CheckCanThrowDice(int playerId);
        int GetPlayerPositionOnBoard(int playerId);

        #endregion

    }
}
