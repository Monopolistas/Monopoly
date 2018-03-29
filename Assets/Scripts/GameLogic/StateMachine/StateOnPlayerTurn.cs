

using UnityEngine;

public class StateOnPlayerTurn : State
{

    public enum StateEnum
    {
        ON_START = 1,
        ON_MOVE = 2,
        ON_ACTION = 3
    }

    PlayerTurn playerTurn;
    DiceThrow diceThrow;

    StateEnum currentState;

    public StateOnPlayerTurn(GameStateMachine gameStateMachine) : base(gameStateMachine)
    {
        this.diceThrow = new DiceThrow();
        Reset();
    }

    public void Reset()
    {
        this.currentState = StateEnum.ON_START;
    }

    public override void ExecuteGameLogic()
    {
        switch (currentState)
        {
            case StateEnum.ON_MOVE:
                GameStateMachine.Board.MovePlayerTo(playerTurn.Player, diceThrow.Sum);
                currentState = StateEnum.ON_ACTION;
                break;
            case StateEnum.ON_ACTION:
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
            diceThrow.Throw();
        }
        else
        {
            diceThrow.Result[0] = die1;
            diceThrow.Result[1] = die2;
            diceThrow.IsThrown = true;
        }
        if (diceThrow.isDouble())
        {
            playerTurn.AddDiceThrow(diceThrow);
        }
        this.currentState = StateEnum.ON_MOVE;
    }

    public StateEnum CurrentState
    {
        get
        {
            return currentState;
        }

        set
        {
            currentState = value;
        }
    }

    public DiceThrow DiceThrow
    {
        get
        {
            return diceThrow;
        }

        set
        {
            diceThrow = value;
        }
    }

    public PlayerTurn PlayerTurn
    {
        get
        {
            return playerTurn;
        }

        set
        {
            playerTurn = value;
        }
    }
}
