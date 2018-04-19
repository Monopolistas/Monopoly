using System.Collections.Generic;

namespace Assets.Scripts.GameLogic.Entity
{
    public class PlayerColor
    {
        public static readonly PlayerColor Black = new PlayerColor(1, "BLACK", "#000000");
        public static readonly PlayerColor Blue = new PlayerColor(2, "BLUE", "#0000FF");
        public static readonly PlayerColor Green = new PlayerColor(3, "GREEN", "#00FF00");
        public static readonly PlayerColor Red = new PlayerColor(4, "RED", "#FF0000");
        public static readonly PlayerColor White = new PlayerColor(5, "WHITE", "#FFFFFF");
        public static readonly PlayerColor Yellow = new PlayerColor(6, "YELLOW", "#FFFF00");

        public PlayerColor(int code, string name, string hexValue)
        {
            Code = code;
            Name = name;
            HexValue = hexValue;
        }

        public static IEnumerable<PlayerColor> Values
        {
            get
            {
                yield return Black;
                yield return Blue;
                yield return Green;
                yield return Red;
                yield return White;
                yield return Yellow;
            }
        }

        public static PlayerColor FindByName(string name)
        {
            PlayerColor color = null;
            foreach (PlayerColor item in Values)
            {
                if (name.Equals(item.Name))
                {
                    color = item;
                }
            }
            return color;
        }

        public int Code { get; set; }

        public string Name { get; set; }

        public string HexValue { get; set; }
    }
}
