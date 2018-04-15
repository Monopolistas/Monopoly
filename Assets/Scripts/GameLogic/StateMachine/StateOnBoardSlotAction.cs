using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateOnBoardSlotAction : State
{
    public enum StateEnum
    {
        ON_START = 1,
        ON_ACTION = 2
    }

    State stateBefore;
    BoardSlot boardSlot;
    BoardSlotAction boardSlotAction; // "Strategy Pattern" was used to implement actions
    StateEnum currentState;

    public StateOnBoardSlotAction(GameStateMachine gameStateMachine) : base(gameStateMachine)
    {
        Reset();
    }

    public void Reset()
    {
        currentState = StateEnum.ON_START;
    }

    public void GenerateBoardSlotAction(BoardSlotType boardSlotType)
    {
        if (BoardSlotType.CHANCE.Equals(boardSlotType))
        {
            boardSlotAction = new BoardSlotActionChance();
        }
        if (BoardSlotType.COMMUNITY_CHEST.Equals(boardSlotType))
        {
            boardSlotAction = new BoardSlotActionCommunityChest();
        }
        if (BoardSlotType.GO.Equals(boardSlotType))
        {
            boardSlotAction = new BoardSlotActionGo();
        }
        if (BoardSlotType.GO_TO_JAIL.Equals(boardSlotType))
        {
            boardSlotAction = new BoardSlotActionGoToJail();
        }
        if (BoardSlotType.JAIL.Equals(boardSlotType))
        {
            boardSlotAction = new BoardSlotActionJail();
        }
        if (BoardSlotType.LOT.Equals(boardSlotType))
        {
            boardSlotAction = new BoardSlotActionLot();
        }
        if (BoardSlotType.RAILROAD.Equals(boardSlotType))
        {
            boardSlotAction = new BoardSlotActionRailroad();
        }
        if (BoardSlotType.TAX.Equals(boardSlotType))
        {
            boardSlotAction = new BoardSlotActionTax();
        }
        if (BoardSlotType.UTILITY.Equals(boardSlotType))
        {
            boardSlotAction = new BoardSlotActionUtility();
        }
    }

    public override void ExecuteGameLogic()
    {
        switch (currentState)
        {
            case StateEnum.ON_START:
                currentState = StateEnum.ON_ACTION;
                break;
            case StateEnum.ON_ACTION:
                GenerateBoardSlotAction(BoardSlotType.CHANCE);
                boardSlotAction.ExecuteAction();
                GameStateMachine.EndTurn();
                break;
        }
    }

    public State StateBefore
    {
        get
        {
            return stateBefore;
        }

        set
        {
            stateBefore = value;
        }
    }

    public BoardSlot BoardSlot
    {
        get
        {
            return boardSlot;
        }

        set
        {
            boardSlot = value;
        }
    }
}
