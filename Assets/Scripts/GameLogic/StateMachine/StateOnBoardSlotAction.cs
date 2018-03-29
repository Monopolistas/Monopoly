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
            boardSlotAction = new BoardSlotActionChance();
        }
        if (BoardSlotType.GO_TO_JAIL.Equals(boardSlotType))
        {
            boardSlotAction = new BoardSlotActionChance();
        }
        if (BoardSlotType.JAIL.Equals(boardSlotType))
        {
            boardSlotAction = new BoardSlotActionChance();
        }
        if (BoardSlotType.LOT.Equals(boardSlotType))
        {
            boardSlotAction = new BoardSlotActionChance();
        }
        if (BoardSlotType.RAILROAD.Equals(boardSlotType))
        {
            boardSlotAction = new BoardSlotActionChance();
        }
        if (BoardSlotType.TAX.Equals(boardSlotType))
        {
            boardSlotAction = new BoardSlotActionChance();
        }
        if (BoardSlotType.UTILITY.Equals(boardSlotType))
        {
            boardSlotAction = new BoardSlotActionChance();
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
                boardSlotAction.ExecuteAction();
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
