using System;

public class StateOnSelling : State
{
	public StateOnSelling(GameStateMachine gameStateMachine) : base(gameStateMachine)
    {
	}

    public override void ExecuteGameLogic()
    {
        throw new NotImplementedException();
    }
}
