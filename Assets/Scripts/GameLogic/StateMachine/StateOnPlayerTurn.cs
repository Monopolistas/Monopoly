

using Assets.Scripts.GameLogic.Entity;

namespace Assets.Scripts.GameLogic.StateMachine
{
    public class StateOnPlayerTurn : State
    {

        public enum StateEnum
        {
            OnStart = 1,
            OnMove = 2,
            OnAction = 3
        }

        public StateOnPlayerTurn(GameStateMachine gameStateMachine) : base(gameStateMachine)
        {
            DiceThrow = new DiceThrow();
            Reset();
        }

        public void Reset()
        {
            CurrentState = StateEnum.OnStart;
        }

        public override void ExecuteGameLogic()
        {
            switch (CurrentState)
            {
                case StateEnum.OnMove:
                    int index = GameStateMachine.Board.FindIndexWherePlayerIs(PlayerOnTurn);
                    if (index + DiceThrow.Sum >= 40)
                    {
                        GameStateMachine.ChangeState(GameStateMachine.StateOnGameOver);
                    }
                    GameStateMachine.Board.MovePlayerTo(PlayerTurn.Player, DiceThrow.Sum);
                    CurrentState = StateEnum.OnAction;
                    break;
                case StateEnum.OnAction:
                    GameStateMachine.ChangeToStateOnBoardSlotAction();
                    break;
            }
        }

        public void ThrowDice()
        {
            ThrowDice(0, 0);
        }

        public void ThrowDice(int die1, int die2)
        {
            if (die1 == 0 && die2 == 0)
            {
                DiceThrow.Throw();
            }
            else
            {
                DiceThrow.Result[0] = die1;
                DiceThrow.Result[1] = die2;
                DiceThrow.IsThrown = true;
            }
            if (DiceThrow.IsDouble())
            {
                PlayerTurn.AddDiceThrow(DiceThrow);
            }
            CurrentState = StateEnum.OnMove;
        }

        public StateEnum CurrentState { get; set; }

        public DiceThrow DiceThrow { get; set; }

        public PlayerTurn PlayerTurn { get; set; }
    }
}
