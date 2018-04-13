using System;
using System.Collections.Generic;

public class BoardSlot
{

    private int id;
    private BoardSlotType boardSlotType;
    private int lotId;
    private List<Player> playerList;

    public BoardSlot()
    {
        playerList = new List<Player>();
    }

    #region Getters and Setters

    public BoardSlotType BoardSlotType
    {
        get
        {
            return this.boardSlotType;
        }
        set
        {
            this.boardSlotType = value;
        }
    }

    public int Id
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }

    public int LotId
    {
        get
        {
            return this.lotId;
        }
        set
        {
            this.lotId = value;
        }
    }

    public List<Player> PlayerList
    {
        get
        {
            return this.playerList;
        }
        set
        {
            this.playerList = value;
        }
    }
    #endregion
}