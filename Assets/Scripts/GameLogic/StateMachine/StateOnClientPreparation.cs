namespace Assets.Scripts.GameLogic.StateMachine
{
    public class StateOnClientPreparation : State
    {
        public StateOnClientPreparation(GameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public override void ExecuteGameLogic()
        {
            GameStateMachine.FillBoardWithBoardSlots();
            GameStateMachine.FillBankWithLotCards();
            GameStateMachine.FillBankWithBuildings();
            GameStateMachine.ChangeToStateOnPlayerTurn();
            GameStateMachine.IsGameStarted = true;
            GameStateMachine.IsClientPrepared = true;
        }
    }
}
