using UnityEngine;

public class GameStateMachine : IMonopolyCore
{

    StateOnStart stateOnStart;
    StateOnPreparation stateOnPreparation;
    StateOnPlayerTurn stateOnPlayerTurn;
    StateOnBoardSlotAction stateOnBoardSlotAction;

    State currentState;

    Board board;

    Player playerOnTurn;

    VirtualDatabase virtualDatabase;

    Player owner;

    public GameStateMachine()
    {
        board = new Board();

        InitializeStates();

        virtualDatabase = new VirtualDatabase();

        this.currentState = stateOnStart;
    }

    void InitializeStates()
    {
        stateOnStart = new StateOnStart(this);
        stateOnPreparation = new StateOnPreparation(this);
        stateOnPlayerTurn = new StateOnPlayerTurn(this);
        stateOnBoardSlotAction = new StateOnBoardSlotAction(this);
    }

    public void ExecuteGameLogic()
    {
        this.currentState.ExecuteGameLogic();
    }

    #region Machine commands

    public void ChangeState(State state)
    {
        this.currentState = state;
    }

    public void ChangeToStateOnPlayerTurn()
    {
        StateOnPlayerTurn.PlayerOnTurn = playerOnTurn;
        StateOnPlayerTurn.PlayerTurn = new PlayerTurn();
        StateOnPlayerTurn.PlayerTurn.Player = playerOnTurn;
        this.currentState = StateOnPlayerTurn;
    }

    public void ChangeToStateOnBoardSlotAction()
    {
        StateOnBoardSlotAction.StateBefore = this.currentState;
        StateOnBoardSlotAction.BoardSlot = playerOnTurn.BoardSlot;
        this.currentState = StateOnBoardSlotAction;
    }

    public void ThrowDice(int playerId)
    {
        ThrowDice(playerId, 0, 0);
    }

    public void ThrowDice(int playerId, int die1, int die2)
    {
        if (CheckCanThrowDice(playerId))
        {
            ((StateOnPlayerTurn)currentState).ThrowDice(die1, die2);
        }
        else
        {
            throw new MonopolyAlertException("Player can't throw dice. Wait player's turn.");
        }
    }

    public Player AddLocalPlayer(int id)
    {
        // Instantiate local player on master and clients
        Player player = new Player();
        player.Id = id;
        player.Name = virtualDatabase.PlayerQueue.Dequeue().Name;
        player.PlayerColor = virtualDatabase.PlayerColorQueue.Dequeue();
        virtualDatabase.PlayerDictionary.Add(id, player);
        owner = player;
        return player;
    }

    #endregion

    #region Check methods

    public bool CheckInState(string stateName)
    {
        return this.currentState.GetType().Name.Equals(stateName);
    }

    public bool CheckCanThrowDice(int playerId)
    {
        return (playerOnTurn.Id == playerId && currentState is StateOnPlayerTurn);
    }

    public int GetPlayerPositionOnBoard(int playerId)
    {
        return board.FindIndexWherePlayerIs(virtualDatabase.PlayerDictionary[playerId]);
    }

    public int GetNumberOfHousesWithBank()
    {
        int counter = 0;
        foreach (Building building in board.Bank.BuildingList)
        {
            if (building.BuildingType.Equals(BuildingType.HOUSE))
            {
                counter++;
            }
        }
        return counter;
    }

    public int GetNumberOfHotelsWithBank()
    {
        int counter = 0;
        foreach (Building building in board.Bank.BuildingList)
        {
            if (building.BuildingType.Equals(BuildingType.HOTEL))
            {
                counter++;
            }
        }
        return counter;
    }

    #endregion

    #region Getters and Setters

    public VirtualDatabase Database
    {
        get
        {
            return this.virtualDatabase;
        }
        set
        {
            virtualDatabase = value;
        }
    }

    public Player PlayerOnTurn
    {
        get
        {
            return playerOnTurn;
        }

        set
        {
            playerOnTurn = value;
        }
    }

    public Board Board
    {
        get
        {
            return board;
        }

        set
        {
            board = value;
        }
    }

    public State CurrentState
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

    public StateOnPreparation StateOnPreparation
    {
        get
        {
            return stateOnPreparation;
        }

        set
        {
            stateOnPreparation = value;
        }
    }

    public StateOnPlayerTurn StateOnPlayerTurn
    {
        get
        {
            return stateOnPlayerTurn;
        }

        set
        {
            stateOnPlayerTurn = value;
        }
    }

    public StateOnBoardSlotAction StateOnBoardSlotAction
    {
        get
        {
            return stateOnBoardSlotAction;
        }

        set
        {
            stateOnBoardSlotAction = value;
        }
    }

    public Player Owner
    {
        get
        {
            return owner;
        }
        set
        {
            this.owner = value;
        }
    }

    #endregion

}
