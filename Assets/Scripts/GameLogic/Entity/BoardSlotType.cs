using System.Collections.Generic;

namespace Assets.Scripts.GameLogic.Entity
{
    public class BoardSlotType
    {
        public static readonly BoardSlotType Go = new BoardSlotType(1, "GO");
        public static readonly BoardSlotType Lot = new BoardSlotType(2, "LOT");
        public static readonly BoardSlotType Tax = new BoardSlotType(3, "TAX");
        public static readonly BoardSlotType Railroad = new BoardSlotType(4, "RAILROAD");
        public static readonly BoardSlotType Utility = new BoardSlotType(5, "UTILITY");
        public static readonly BoardSlotType Jail = new BoardSlotType(6, "JAIL");
        public static readonly BoardSlotType Park = new BoardSlotType(7, "PARK");
        public static readonly BoardSlotType CommunityChest = new BoardSlotType(8, "COMMUNITY CHEST");
        public static readonly BoardSlotType Chance = new BoardSlotType(9, "CHANCE");
        public static readonly BoardSlotType GoToJail = new BoardSlotType(10, "GO TO JAIL");

        public BoardSlotType(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public static IEnumerable<BoardSlotType> Values
        {
            get
            {
                yield return Go;
                yield return Lot;
                yield return Tax;
                yield return Railroad;
                yield return Utility;
                yield return Jail;
                yield return Park;
                yield return CommunityChest;
                yield return Chance;
                yield return GoToJail;
            }
        }

        public static BoardSlotType FindByCode(int code)
        {
            BoardSlotType type = null;
            foreach (BoardSlotType item in Values)
            {
                if (code.Equals(item.Code))
                {
                    type = item;
                }
            }
            return type;
        }

        public int Code { get; }

        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            var type = obj as BoardSlotType;
            return type != null &&
                   Code == type.Code;
        }

        public override int GetHashCode()
        {
            return -1021610220 + Code.GetHashCode();
        }
    }
}
