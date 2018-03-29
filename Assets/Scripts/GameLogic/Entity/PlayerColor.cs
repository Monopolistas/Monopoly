using System.Collections.Generic;

public class PlayerColor
{
    public static readonly PlayerColor BLACK = new PlayerColor(1, "BLACK", "#000000");
    public static readonly PlayerColor WHITE = new PlayerColor(2, "WHITE", "#FFFFFF");
    public static readonly PlayerColor RED = new PlayerColor(3, "RED", "#FF0000");
    public static readonly PlayerColor BLUE = new PlayerColor(4, "BLUE", "#0000FF");
    public static readonly PlayerColor GREEN = new PlayerColor(5, "GREEN", "#00FF00");
    public static readonly PlayerColor YELLOW = new PlayerColor(6, "YELLOW", "#FFFF00");

    int code;
    string name;
    string hexValue;

    public PlayerColor(int code, string name, string hexValue)
    {
        this.code = code;
        this.name = name;
        this.hexValue = hexValue;
    }

    public static IEnumerable<PlayerColor> Values
    {
        get
        {
            yield return BLACK;
            yield return WHITE;
            yield return RED;
            yield return BLUE;
            yield return GREEN;
            yield return YELLOW;
        }
    }

    public static PlayerColor FindByName(string name)
    {
        PlayerColor color = null;
        foreach (PlayerColor item in Values)
        {
            if (name.Equals(item.name))
            {
                color = item;
            }
        }
        return color;
    }

    public int Code
    {
        get
        {
            return code;
        }

        set
        {
            code = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string HexValue
    {
        get
        {
            return hexValue;
        }

        set
        {
            hexValue = value;
        }
    }

}
