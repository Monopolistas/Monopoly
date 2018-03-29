using System;

public class ChanceCard : Card
{
    string text;
    int value;
    TransactionType transactionType;
    CardActionType cardActionType;
    BoardSlot boardSlot;
    int boardSlotId;
    int multiplier;
    BoardSlotType boardSlotType;
    int valuePerHouse;
    int valuePerHotel;

    public static explicit operator ChanceCard(ChanceCardScriptableObject v)
    {
        ChanceCard chanceCard = new ChanceCard();
        chanceCard.Id = v.id;
        chanceCard.Text = v.text;
        chanceCard.Value = v.value;
        if (v.transaction != null)
        {
            chanceCard.TransactionType = TransactionType.FindByCode(v.transaction);
        }
        chanceCard.CardActionType = CardActionType.FindByCode(v.cardAction);
        chanceCard.BoardSlotId = v.boardSlot;
        chanceCard.Multiplier = v.multiplier;
        chanceCard.BoardSlotType = v.boardSlotType == 0 ? null : BoardSlotType.FindByCode(v.boardSlotType);
        chanceCard.ValuePerHouse = v.valuePerHouse;
        chanceCard.ValuePerHotel = v.valuePerHotel;
        return chanceCard;
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

    public int Multiplier
    {
        get
        {
            return multiplier;
        }

        set
        {
            multiplier = value;
        }
    }

    public BoardSlotType BoardSlotType
    {
        get
        {
            return boardSlotType;
        }

        set
        {
            boardSlotType = value;
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
