using Assets.Scripts.GameLogic.Entity;

namespace Assets.Scripts.GameLogic.StateMachine
{
    public abstract class State
    {
        public abstract void ExecuteGameLogic();

        protected State(GameStateMachine gameStateMachine)
        {
            this.GameStateMachine = gameStateMachine;
            Board = gameStateMachine.Board;
            PlayerOnTurn = gameStateMachine.PlayerOnTurn;
        }

        public Board Board { get; set; }

        public GameStateMachine GameStateMachine { get; set; }

        public Player PlayerOnTurn { get; set; }
    }
}
