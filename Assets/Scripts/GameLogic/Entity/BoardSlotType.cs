using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardSlotType
{
    public static readonly BoardSlotType GO = new BoardSlotType(1, "GO");
    public static readonly BoardSlotType LOT = new BoardSlotType(2, "LOT");
    public static readonly BoardSlotType TAX = new BoardSlotType(3, "TAX");
    public static readonly BoardSlotType RAILROAD = new BoardSlotType(4, "RAILROAD");
    public static readonly BoardSlotType UTILITY = new BoardSlotType(5, "UTILITY");
    public static readonly BoardSlotType JAIL = new BoardSlotType(6, "JAIL");
    public static readonly BoardSlotType PARK = new BoardSlotType(7, "PARK");
    public static readonly BoardSlotType COMMUNITY_CHEST = new BoardSlotType(8, "COMMUNITY CHEST");
    public static readonly BoardSlotType CHANCE = new BoardSlotType(9, "CHANCE");
    public static readonly BoardSlotType GO_TO_JAIL = new BoardSlotType(10, "GO TO JAIL");

    private readonly int code;
    private readonly string name;

    public BoardSlotType(int code, string name)
    {
        this.code = code;
        this.name = name;
    }

    public static IEnumerable<BoardSlotType> Values
    {
        get
        {
            yield return GO;
            yield return LOT;
            yield return TAX;
            yield return RAILROAD;
            yield return UTILITY;
            yield return JAIL;
            yield return PARK;
            yield return COMMUNITY_CHEST;
            yield return CHANCE;
            yield return GO_TO_JAIL;
        }
    }

    public static BoardSlotType FindByCode(int code)
    {
        BoardSlotType type = null;
        foreach (BoardSlotType item in Values)
        {
            if (code.Equals(item.code))
            {
                type = item;
            }
        }
        return type;
    }

    public int Code
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

    public override string ToString()
    {
        return this.name;
    }

    public override bool Equals(object obj)
    {
        var type = obj as BoardSlotType;
        return type != null &&
               code == type.code;
    }

    public override int GetHashCode()
    {
        return -1021610220 + code.GetHashCode();
    }
}
