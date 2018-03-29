public class Player : Person {
    int id;
    string name;
    BoardSlot boardSlot;
    PlayerColor playerColor;

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
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

    public PlayerColor PlayerColor
    {
        get
        {
            return playerColor;
        }

        set
        {
            playerColor = value;
        }
    }
}
