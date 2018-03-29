using System.Collections.Generic;
using UnityEngine;

public class CardActionType
{
    public static readonly CardActionType GOTO = new CardActionType("GT", "GOTO");
    public static readonly CardActionType TRANSACTION = new CardActionType("TR", "TRANSACTION");
    public static readonly CardActionType JAIL_FREE = new CardActionType("JF", "JAIL FREE");
    public static readonly CardActionType ALL_PLAYERS_TRANSACTION = new CardActionType("AP", "ALL PLAYERS TRANSACTION");
    public static readonly CardActionType ALL_BUILDINGS_TRANSACTION = new CardActionType("AB", "ALL BUILDINGS TRANSACTION");
    public static readonly CardActionType GO_TO_JAIL = new CardActionType("GJ", "GO TO JAIL");
    public static readonly CardActionType GO_TO_NEAREST = new CardActionType("GN", "GO TO NEAREST");

    private readonly string code;
    private readonly string name;

    public CardActionType(string code, string name)
    {
        this.code = code;
        this.name = name;
    }

    public static IEnumerable<CardActionType> Values
    {
        get
        {
            yield return GOTO;
            yield return TRANSACTION;
            yield return JAIL_FREE;
            yield return ALL_PLAYERS_TRANSACTION;
            yield return ALL_BUILDINGS_TRANSACTION;
            yield return GO_TO_JAIL;
            yield return GO_TO_NEAREST;
        }
    }

    public static CardActionType FindByCode(string code)
    {
        CardActionType type = null;
        foreach (CardActionType item in Values)
        {
            if (code.Equals(item.code))
            {
                type = item;
            }
        }
        return type;
    }

    public string Code
    {
        get
        {
            return this.code;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
    }

}
