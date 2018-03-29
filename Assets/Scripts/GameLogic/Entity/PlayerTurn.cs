using System;
using System.Collections.Generic;

public class PlayerTurn
{
    List<DiceThrow> diceThrowList;
    Player player;

    public PlayerTurn()
    {
        this.diceThrowList = new List<DiceThrow>();
    }

    public void AddDiceThrow(DiceThrow diceThrow)
    {
        this.diceThrowList.Add(diceThrow);
    }

    public bool isThirdThrow()
    {
        return (this.diceThrowList.Count >= 3);
    }

    public Player Player
    {
        get
        {
            return this.player;
        }
        set
        {
            this.player = value;
        }
    }

    public List<DiceThrow> DiceThrowList
    {
        get
        {
            return this.diceThrowList;
        }
        set
        {
            this.diceThrowList = value;
        }
    }
}
