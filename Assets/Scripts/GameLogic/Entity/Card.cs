using System;

public class Card
{
    private int id;
    private CardType cardType;
    private Player owner;

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

    public CardType CardType
    {
        get
        {
            return cardType;
        }

        set
        {
            cardType = value;
        }
    }

    public Player Owner
    {
        get
        {
            return owner;
        }

        set
        {
            owner = value;
        }
    }
}
