using System;

public class CommunityChestCard : Card
{
    string text;
    int value;
    TransactionType transactionType;
    CardActionType cardActionType;
    BoardSlot boardSlot;
    int boardSlotId;
    int valuePerHouse;
    int valuePerHotel;

    public static explicit operator CommunityChestCard(CommunityChestCardScriptableObject v)
    {
        CommunityChestCard communityChestCard = new CommunityChestCard();
        communityChestCard.Id = v.id;
        communityChestCard.Text = v.text;
        communityChestCard.Value = v.value;
        if (v.transaction != null)
        {
            communityChestCard.TransactionType = TransactionType.FindByCode(v.transaction);
        }
        communityChestCard.CardActionType = CardActionType.FindByCode(v.cardAction);
        communityChestCard.BoardSlotId = v.boardSlot;
        communityChestCard.ValuePerHouse = v.valuePerHouse;
        communityChestCard.ValuePerHotel = v.valuePerHotel;
        return communityChestCard;
    }

    #region Getters and Setters

    public string Text
    {
        get
        {
            return text;
        }

        set
        {
            text = value;
        }
    }

    public int Value
    {
        get
        {
            return value;
        }

        set
        {
            this.value = value;
        }
    }

    public TransactionType TransactionType
    {
        get
        {
            return transactionType;
        }

        set
        {
            transactionType = value;
        }
    }

    public CardActionType CardActionType
    {
        get
        {
            return cardActionType;
        }

        set
        {
            cardActionType = value;
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

    public int ValuePerHouse
    {
        get
        {
            return valuePerHouse;
        }

        set
        {
            valuePerHouse = value;
        }
    }

    public int ValuePerHotel
    {
        get
        {
            return valuePerHotel;
        }

        set
        {
            valuePerHotel = value;
        }
    }

    public int BoardSlotId
    {
        get
        {
            return boardSlotId;
        }

        set
        {
            boardSlotId = value;
        }
    }

    #endregion
}
