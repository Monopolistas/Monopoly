namespace Assets.Scripts.GameLogic.StateMachine
{
    public class StateOnStart : State
    {
        public StateOnStart(GameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public override void ExecuteGameLogic()
        {
            // TODO: Implement logic
            // Waiting for player connections...
        }
    }
}
