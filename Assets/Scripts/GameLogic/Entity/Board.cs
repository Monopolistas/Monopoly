using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{

    List<Player> playerList;
    List<BoardSlot> boardSlotList;
    Queue<ChanceCard> chanceCardQueue;
    Queue<CommunityChestCard> communityChestCardQueue;
    Bank bank;

    public Board()
    {
        this.playerList = new List<Player>();
        this.boardSlotList = new List<BoardSlot>();
        this.chanceCardQueue = new Queue<ChanceCard>();
        this.communityChestCardQueue = new Queue<CommunityChestCard>();
        this.bank = new Bank();
    }

    public void MovePlayerTo(Player player, int steps)
    {
        int fromIndex = FindIndexWherePlayerIs(player);
        int toIndex = FindNextIndexWherePlayerWillBe(fromIndex, steps);

        boardSlotList[fromIndex].PlayerList.Remove(player);
        player.BoardSlot = boardSlotList[toIndex];
        boardSlotList[toIndex].PlayerList.Add(player);
    }

    int FindNextIndexWherePlayerWillBe(int index, int steps)
    {
        int j = index;

        for (int i = 0; i < steps; i++)
        {
            if (j >= boardSlotList.Count)
            {
                j = 0;
            }
            j++;
        }

        return j;
    }

    public int FindIndexWherePlayerIs(Player player)
    {
        int index = 0;
        foreach (BoardSlot item in boardSlotList)
        {
            if (item.Id.Equals(player.BoardSlot.Id))
            {
                break;
            }
            index++;
        }
        return index;
    }

    #region Getters and Setters

    public List<Player> PlayerList
    {
        get
        {
            return playerList;
        }

        set
        {
            playerList = value;
        }
    }

    public List<BoardSlot> BoardSlotList
    {
        get
        {
            return boardSlotList;
        }

        set
        {
            boardSlotList = value;
        }
    }

    public Queue<ChanceCard> ChanceCardQueue
    {
        get
        {
            return chanceCardQueue;
        }

        set
        {
            chanceCardQueue = value;
        }
    }

    public Queue<CommunityChestCard> CommunityChestCardQueue
    {
        get
        {
            return communityChestCardQueue;
        }

        set
        {
            communityChestCardQueue = value;
        }
    }

    public Bank Bank
    {
        get
        {
            return bank;
        }

        set
        {
            bank = value;
        }
    }

    #endregion
}
