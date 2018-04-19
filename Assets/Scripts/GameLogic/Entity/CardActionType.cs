using System.Collections.Generic;

namespace Assets.Scripts.GameLogic.Entity
{
    public class CardActionType
    {
        public static readonly CardActionType Goto = new CardActionType("GT", "GOTO");
        public static readonly CardActionType Transaction = new CardActionType("TR", "TRANSACTION");
        public static readonly CardActionType JailFree = new CardActionType("JF", "JAIL FREE");
        public static readonly CardActionType AllPlayersTransaction = new CardActionType("AP", "ALL PLAYERS TRANSACTION");
        public static readonly CardActionType AllBuildingsTransaction = new CardActionType("AB", "ALL BUILDINGS TRANSACTION");
        public static readonly CardActionType GoToJail = new CardActionType("GJ", "GO TO JAIL");
        public static readonly CardActionType GoToNearest = new CardActionType("GN", "GO TO NEAREST");

        public CardActionType(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public static IEnumerable<CardActionType> Values
        {
            get
            {
                yield return Goto;
                yield return Transaction;
                yield return JailFree;
                yield return AllPlayersTransaction;
                yield return AllBuildingsTransaction;
                yield return GoToJail;
                yield return GoToNearest;
            }
        }

        public static CardActionType FindByCode(string code)
        {
            CardActionType type = null;
            foreach (CardActionType item in Values)
            {
                if (code.Equals(item.Code))
                {
                    type = item;
                }
            }
            return type;
        }

        public string Code { get; }

        public string Name { get; }
    }
}
