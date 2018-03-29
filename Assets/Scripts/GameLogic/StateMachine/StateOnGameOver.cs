using System;

public class StateOnGameOver : State
{
	public StateOnGameOver(GameStateMachine gameStateMachine) : base(gameStateMachine)
    {
	}

    public override void ExecuteGameLogic()
    {
        throw new NotImplementedException();
    }
}
