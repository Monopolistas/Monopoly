using System.Collections.Generic;

public class CardType
{
    public static readonly CardType TITLE_DEED = new CardType("TD", "TITLE DEED");
    public static readonly CardType CHANCE = new CardType("CH", "CHANCE");
    public static readonly CardType COMMUNITY_CHEST = new CardType("CC", "COMMUNITY CHEST");
    public static readonly CardType RAILROAD = new CardType("RR", "RAILROAD");
    public static readonly CardType UTILITY = new CardType("UT", "UTILITY");

    private string id;

    private string name;

    public CardType(string id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public static IEnumerable<CardType> Values
    {
        get
        {
            yield return TITLE_DEED;
            yield return CHANCE;
            yield return COMMUNITY_CHEST;
            yield return RAILROAD;
            yield return UTILITY;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
    }

    public string Id
    {
        get
        {
            return this.id;
        }
    }

    public override string ToString()
    {
        return this.name;
    }

}
