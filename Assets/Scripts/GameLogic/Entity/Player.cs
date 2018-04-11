using ExitGames.Client.Photon;
using System;
using System.Collections.Generic;

public class Player : Person
{
    public static readonly Player PLAYER_1 = new Player(1, "PLAYER 1");
    public static readonly Player PLAYER_2 = new Player(2, "PLAYER 2");
    public static readonly Player PLAYER_3 = new Player(3, "PLAYER 3");
    public static readonly Player PLAYER_4 = new Player(4, "PLAYER 4");
    public static readonly Player PLAYER_5 = new Player(5, "PLAYER 5");
    public static readonly Player PLAYER_6 = new Player(6, "PLAYER 6");

    int id;
    string name;
    BoardSlot boardSlot;
    PlayerColor playerColor;

    public Player()
    {
    }

    public Player(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public Player(int id, string name, PlayerColor playerColor)
    {
        this.id = id;
        this.name = name;
        this.playerColor = playerColor;
    }

    public static IEnumerable<Player> Values
    {
        get
        {
            yield return PLAYER_1;
            yield return PLAYER_2;
            yield return PLAYER_3;
            yield return PLAYER_4;
            yield return PLAYER_5;
            yield return PLAYER_6;
        }
    }

    public Player FindById(int id)
    {
        foreach (Player p in Values)
        {
            if (p.Id.Equals(id))
            {
                return p;
            }
        }

        return null;
    }

    #region Getters and Setters

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

    #endregion
}
