using System;

public class StateOnBuy : State
{
	public StateOnBuy(GameStateMachine gameStateMachine) : base(gameStateMachine)
    {
	}

    public override void ExecuteGameLogic()
    {
        throw new NotImplementedException();
    }
}
