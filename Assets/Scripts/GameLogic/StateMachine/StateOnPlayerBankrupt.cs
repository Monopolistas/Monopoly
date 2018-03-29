using System;

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
