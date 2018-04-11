using System;
using System.Collections.Generic;
using UnityEngine;

public class VirtualDatabase
{
    // Immutable collections
    Dictionary<int, Card> cardDictionary;

    Dictionary<int, BoardSlot> boardSlotDictionary;

    Dictionary<int, Lot> lotDictionary;

    Queue<Player> playerQueue;

    Queue<PlayerColor> playerColorQueue;

    List<TitleDeedCard> titleDeedCardList;

    List<ChanceCard> chanceCardList;

    List<CommunityChestCard> communityChestCardList;

    List<RailroadCard> railroadCardList;

    List<UtilityCard> utilityCardList;

    // Mutable
    Dictionary<int, Player> playerDictionary;

    public VirtualDatabase()
    {
        this.cardDictionary = new Dictionary<int, Card>();
        this.playerDictionary = new Dictionary<int, Player>();
        this.boardSlotDictionary = new Dictionary<int, BoardSlot>();
        this.lotDictionary = new Dictionary<int, Lot>();
        this.playerQueue = new Queue<Player>(Player.Values);
        this.playerColorQueue = new Queue<PlayerColor>(PlayerColor.Values);
        this.titleDeedCardList = new List<TitleDeedCard>();
        this.chanceCardList = new List<ChanceCard>();
        this.communityChestCardList = new List<CommunityChestCard>();
        this.railroadCardList = new List<RailroadCard>();
        this.utilityCardList = new List<UtilityCard>();
    }

    #region Getters and Setters

    public Queue<Player> PlayerQueue
    {
        get
        {
            return playerQueue;
        }
        set
        {
            playerQueue = value;
        }
    }

    public Queue<PlayerColor> PlayerColorQueue
    {
        get
        {
            return playerColorQueue;
        }
        set
        {
            playerColorQueue = value;
        }
    }

    public Dictionary<int, Player> PlayerDictionary
    {
        get
        {
            return playerDictionary;
        }
        set
        {
            playerDictionary = value;
        }
    }

    public Dictionary<int, Card> CardDictionary
    {
        get
        {
            return cardDictionary;
        }

        set
        {
            cardDictionary = value;
        }
    }

    public Dictionary<int, BoardSlot> BoardSlotDictionary
    {
        get
        {
            return boardSlotDictionary;
        }

        set
        {
            boardSlotDictionary = value;
        }
    }

    public Dictionary<int, Lot> LotDictionary
    {
        get
        {
            return lotDictionary;
        }

        set
        {
            lotDictionary = value;
        }
    }

    public List<TitleDeedCard> TitleDeedCardList
    {
        get
        {
            return titleDeedCardList;
        }

        set
        {
            titleDeedCardList = value;
        }
    }

    public List<ChanceCard> ChanceCardList
    {
        get
        {
            return chanceCardList;
        }

        set
        {
            chanceCardList = value;
        }
    }

    public List<CommunityChestCard> CommunityChestCardList
    {
        get
        {
            return communityChestCardList;
        }

        set
        {
            communityChestCardList = value;
        }
    }

    public List<RailroadCard> RailroadCardList
    {
        get
        {
            return railroadCardList;
        }

        set
        {
            railroadCardList = value;
        }
    }

    public List<UtilityCard> UtilityCardList
    {
        get
        {
            return utilityCardList;
        }

        set
        {
            utilityCardList = value;
        }
    }

    #endregion
}
