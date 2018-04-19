using System;

namespace Assets.Scripts.GameLogic.StateMachine
{
    public class StateOnPlayerBankrupt : State
    {
        public StateOnPlayerBankrupt(GameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public override void ExecuteGameLogic()
        {
            throw new NotImplementedException();
        }
    }
}
