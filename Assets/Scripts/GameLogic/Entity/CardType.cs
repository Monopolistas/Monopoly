using System.Collections.Generic;

namespace Assets.Scripts.GameLogic.Entity
{
    public class CardType
    {
        public static readonly CardType TitleDeed = new CardType("TD", "TITLE DEED");
        public static readonly CardType Chance = new CardType("CH", "CHANCE");
        public static readonly CardType CommunityChest = new CardType("CC", "COMMUNITY CHEST");
        public static readonly CardType Railroad = new CardType("RR", "RAILROAD");
        public static readonly CardType Utility = new CardType("UT", "UTILITY");

        public CardType(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public static IEnumerable<CardType> Values
        {
            get
            {
                yield return TitleDeed;
                yield return Chance;
                yield return CommunityChest;
                yield return Railroad;
                yield return Utility;
            }
        }

        public string Name { get; }

        public string Id { get; }

        public override string ToString()
        {
            return Name;
        }

    }
}
