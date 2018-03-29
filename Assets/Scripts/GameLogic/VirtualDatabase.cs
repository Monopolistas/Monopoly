using System;
using System.Collections.Generic;
using UnityEngine;

public class VirtualDatabase
{
    Dictionary<int, Card> cardDictionary;

    Dictionary<int, Player> playerDictionary;

    Dictionary<int, BoardSlot> boardSlotDictionary;

    Dictionary<int, Lot> lotDictionary;

    public VirtualDatabase()
    {
        this.cardDictionary = new Dictionary<int, Card>();
        this.playerDictionary = new Dictionary<int, Player>();
        this.boardSlotDictionary = new Dictionary<int, BoardSlot>();
        this.lotDictionary = new Dictionary<int, Lot>();
    }

    public void AddBoardSlot(BoardSlot boardSlot)
    {
        this.boardSlotDictionary.Add(boardSlot.Id, boardSlot);
    }

    public void AddChanceCard(ChanceCard chanceCard)
    {
        this.cardDictionary.Add(chanceCard.Id, chanceCard);
    }

    public void AddCommunityChestCard(CommunityChestCard communityChestCard)
    {
        this.cardDictionary.Add(communityChestCard.Id, communityChestCard);
    }

    public void AddTitleDeedCard(TitleDeedCard titleDeedCard)
    {
        this.cardDictionary.Add(titleDeedCard.Id, titleDeedCard);
    }

    public void AddRailroadCard(RailroadCard railroadCard)
    {
        this.cardDictionary.Add(railroadCard.Id, railroadCard);
    }

    public void AddUtilityCard(UtilityCard utilityCard)
    {
        this.cardDictionary.Add(utilityCard.Id, utilityCard);
    }

    public void AddPlayer(Player player)
    {
        this.playerDictionary.Add(player.Id, player);
    }

    public void AddLot(Lot lot)
    {
        this.lotDictionary.Add(lot.LotCard.Id, lot);
    }

    public Card FindCardById(int id)
    {
        return this.cardDictionary[id];
    }

    public BoardSlot FindBoardSlotById(int id)
    {
        return this.boardSlotDictionary[id];
    }

    public Player FindPlayerById(int id)
    {
        return this.playerDictionary[id];
    }

    public int GetNumberOfPlayers()
    {
        return this.playerDictionary.Count;
    }

    public int GetNumberOfBoardSlots()
    {
        return this.boardSlotDictionary.Count;
    }

    public int GetNumberOfLots()
    {
        return this.lotDictionary.Count;
    }

    public int GetNumberOfChanceCards()
    {
        int numberOfChanceCards = 0;

        foreach (Card item in this.cardDictionary.Values)
        {
            if (item is ChanceCard)
            {
                numberOfChanceCards++;
            }
        }

        return numberOfChanceCards;
    }

    public int GetNumberOfCommunityChestCards()
    {
        int numberOfCommunityChestCards = 0;

        foreach (Card item in this.cardDictionary.Values)
        {
            if (item is CommunityChestCard)
            {
                numberOfCommunityChestCards++;
            }
        }

        return numberOfCommunityChestCards;
    }

    public int GetNumberOfTitleDeedCards()
    {
        int numberOfTitleDeedCards = 0;

        foreach (Card item in this.cardDictionary.Values)
        {
            if (item is TitleDeedCard)
            {
                numberOfTitleDeedCards++;
            }
        }

        return numberOfTitleDeedCards;
    }

    public int GetNumberOfRailroadCards()
    {
        int numberOfRailroadCards = 0;

        foreach (Card item in this.cardDictionary.Values)
        {
            if (item is RailroadCard)
            {
                numberOfRailroadCards++;
            }
        }

        return numberOfRailroadCards;
    }

    public int GetNumberOfUtilityCards()
    {
        int numberOfUtilityCards = 0;

        foreach (Card item in this.cardDictionary.Values)
        {
            if (item is UtilityCard)
            {
                numberOfUtilityCards++;
            }
        }

        return numberOfUtilityCards;
    }

    public List<ChanceCard> FindAllChanceCards()
    {
        List<ChanceCard> chanceCardList = new List<ChanceCard>();

        foreach (Card item in this.cardDictionary.Values)
        {
            if (item is ChanceCard)
            {
                chanceCardList.Add((ChanceCard)item);
            }
        }

        return chanceCardList;
    }

    public List<CommunityChestCard> FindAllCommunityChestCards()
    {
        List<CommunityChestCard> communityChestCardList = new List<CommunityChestCard>();

        foreach (Card item in this.cardDictionary.Values)
        {
            if (item is CommunityChestCard)
            {
                communityChestCardList.Add((CommunityChestCard)item);
            }
        }

        return communityChestCardList;
    }

    public List<Player> FindAllPlayers()
    {
        List<Player> playerList = new List<Player>();

        foreach (Player item in this.playerDictionary.Values)
        {
            playerList.Add(item);
        }

        return playerList;
    }

    public List<BoardSlot> FindAllBoardSlots()
    {
        List<BoardSlot> boardSlotList = new List<BoardSlot>();

        foreach (BoardSlot item in this.boardSlotDictionary.Values)
        {
            boardSlotList.Add(item);
        }

        return boardSlotList;
    }

    public List<LotCard> FindAllLotCards()
    {
        List<LotCard> lotCardList = new List<LotCard>();

        foreach (Card item in this.cardDictionary.Values)
        {
            if (item is LotCard)
            {
                lotCardList.Add((LotCard)item);
            }
        }

        return lotCardList;
    }

}
