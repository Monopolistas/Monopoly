using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{

    Player playerOnTurn;

    Player[] players;

    bool isGameOver;

    public GameState()
    {

    }

    public GameState(Player[] players, Player playerOnTurn, bool isGameOver)
    {
        this.playerOnTurn = playerOnTurn;
        this.players = players;
        this.isGameOver = isGameOver;
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

    public bool IsGameOver
    {
        get
        {
            return isGameOver;
        }

        set
        {
            isGameOver = value;
        }
    }

    #endregion
}
