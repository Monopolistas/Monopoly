public abstract class State
{

    Board board;

    GameStateMachine gameStateMachine;

    Player playerOnTurn;

    public abstract void ExecuteGameLogic();

    public State(GameStateMachine gameStateMachine)
    {
        this.gameStateMachine = gameStateMachine;
        this.board = gameStateMachine.Board;
        this.playerOnTurn = gameStateMachine.PlayerOnTurn;
    }

    public Board Board
    {
        get
        {
            return this.board;
        }
        set
        {
            this.board = value;
        }
    }

    public GameStateMachine GameStateMachine
    {
        get
        {
            return this.gameStateMachine;
        }
        set
        {
            this.gameStateMachine = value;
        }
    }

    public Player PlayerOnTurn
    {
        get
        {
            return this.playerOnTurn;
        }
        set
        {
            this.playerOnTurn = value;
        }
    }

}
