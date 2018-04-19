using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.Strategy;
using Assets.Scripts.GameLogic.Strategy.BoardSlotActions;

namespace Assets.Scripts.GameLogic.StateMachine
{
    public class StateOnBoardSlotAction : State
    {
        public enum StateEnum
        {
            OnStart = 1,
            OnAction = 2
        }

        private BoardSlotAction _boardSlotAction; // "Strategy Pattern" was used to implement actions
        private StateEnum _currentState;

        public StateOnBoardSlotAction(GameStateMachine gameStateMachine) : base(gameStateMachine)
        {
            Reset();
        }

        public void Reset()
        {
            _currentState = StateEnum.OnStart;
        }

        public void GenerateBoardSlotAction(BoardSlotType boardSlotType)
        {
            if (BoardSlotType.Chance.Equals(boardSlotType))
            {
                _boardSlotAction = new BoardSlotActionChance();
            }
            if (BoardSlotType.CommunityChest.Equals(boardSlotType))
            {
                _boardSlotAction = new BoardSlotActionCommunityChest();
            }
            if (BoardSlotType.Go.Equals(boardSlotType))
            {
                _boardSlotAction = new BoardSlotActionGo();
            }
            if (BoardSlotType.GoToJail.Equals(boardSlotType))
            {
                _boardSlotAction = new BoardSlotActionGoToJail();
            }
            if (BoardSlotType.Jail.Equals(boardSlotType))
            {
                _boardSlotAction = new BoardSlotActionJail();
            }
            if (BoardSlotType.Lot.Equals(boardSlotType))
            {
                _boardSlotAction = new BoardSlotActionLot();
            }
            if (BoardSlotType.Railroad.Equals(boardSlotType))
            {
                _boardSlotAction = new BoardSlotActionRailroad();
            }
            if (BoardSlotType.Tax.Equals(boardSlotType))
            {
                _boardSlotAction = new BoardSlotActionTax();
            }
            if (BoardSlotType.Utility.Equals(boardSlotType))
            {
                _boardSlotAction = new BoardSlotActionUtility();
            }
        }

        public override void ExecuteGameLogic()
        {
            switch (_currentState)
            {
                case StateEnum.OnStart:
                    _currentState = StateEnum.OnAction;
                    break;
                case StateEnum.OnAction:
                    GenerateBoardSlotAction(BoardSlotType.Chance);
                    _boardSlotAction.ExecuteAction();
                    GameStateMachine.EndTurn();
                    break;
            }
        }

        public State StateBefore { get; set; }

        public BoardSlot BoardSlot { get; set; }
    }
}
