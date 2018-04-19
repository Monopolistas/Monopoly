using System.Collections.Generic;

namespace Assets.Scripts.GameLogic.Entity
{
    public class GroupColor
    {
        public static readonly GroupColor Purple = new GroupColor(1, "PURPLE", "#A020F0");
        public static readonly GroupColor LightBlue = new GroupColor(2, "LIGHT BLUE", "#ADD8E6");
        public static readonly GroupColor Pink = new GroupColor(3, "PINK", "#FF69B4");
        public static readonly GroupColor Orange = new GroupColor(4, "ORANGE", "#FFA500");
        public static readonly GroupColor Red = new GroupColor(5, "RED", "#FF0000");
        public static readonly GroupColor Yellow = new GroupColor(6, "YELLOW", "#FFFF00");
        public static readonly GroupColor Green = new GroupColor(7, "GREEN", "#008000");
        public static readonly GroupColor DarkBlue = new GroupColor(8, "DARK BLUE", "#000080");

        public GroupColor(int code, string name, string hexValue)
        {
            Code = code;
            Name = name;
            HexValue = hexValue;
        }

        public static IEnumerable<GroupColor> Values
        {
            get
            {
                yield return Purple;
                yield return LightBlue;
                yield return Pink;
                yield return Orange;
                yield return Red;
                yield return Yellow;
                yield return Green;
                yield return DarkBlue;
            }
        }

        public static GroupColor FindByName(string name)
        {
            GroupColor type = null;
            foreach (GroupColor item in Values)
            {
                if (name.Equals(item.Name))
                {
                    type = item;
                }
            }
            return type;
        }

        public int Code { get; }

        public string Name { get; }

        public string HexValue { get; }

        public override string ToString()
        {
            return Name;
        }

    }
}
