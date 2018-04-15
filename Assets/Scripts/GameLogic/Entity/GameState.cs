using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{

    Player playerOnTurn;

    Player[] players;

    public GameState()
    {

    }

    public GameState(Player[] players, Player playerOnTurn)
    {
        this.playerOnTurn = playerOnTurn;
        this.players = players;
    }

    #region Getters and Setters

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

    public Player[] Players
    {
        get
        {
            return players;
        }

        set
        {
            players = value;
        }
    }

    #endregion
}
