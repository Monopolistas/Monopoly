using System.Collections.Generic;

public class GroupColor
{
    public static readonly GroupColor PURPLE = new GroupColor(1, "PURPLE", "#A020F0");
    public static readonly GroupColor LIGHT_BLUE = new GroupColor(2, "LIGHT BLUE", "#ADD8E6");
    public static readonly GroupColor PINK = new GroupColor(3, "PINK", "#FF69B4");
    public static readonly GroupColor ORANGE = new GroupColor(4, "ORANGE", "#FFA500");
    public static readonly GroupColor RED = new GroupColor(5, "RED", "#FF0000");
    public static readonly GroupColor YELLOW = new GroupColor(6, "YELLOW", "#FFFF00");
    public static readonly GroupColor GREEN = new GroupColor(7, "GREEN", "#008000");
    public static readonly GroupColor DARK_BLUE = new GroupColor(8, "DARK BLUE", "#000080");

    private readonly int code;
    private readonly string name;
    private readonly string hexValue;

    public GroupColor(int code, string name, string hexValue)
    {
        this.code = code;
        this.name = name;
        this.hexValue = hexValue;
    }

    public static IEnumerable<GroupColor> Values
    {
        get
        {
            yield return PURPLE;
            yield return LIGHT_BLUE;
            yield return PINK;
            yield return ORANGE;
            yield return RED;
            yield return YELLOW;
            yield return GREEN;
            yield return DARK_BLUE;
        }
    }

    public static GroupColor FindByName(string name)
    {
        GroupColor type = null;
        foreach (GroupColor item in Values)
        {
            if (name.Equals(item.name))
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

    public string HexValue
    {
        get
        {
            return this.hexValue;
        }
    }

    public override string ToString()
    {
        return this.name;
    }

}
