using System;

public class StateOnAuction : State
{
	public StateOnAuction(GameStateMachine gameStateMachine) : base(gameStateMachine)
    {
	}

    public override void ExecuteGameLogic()
    {
        throw new NotImplementedException();
    }
}
