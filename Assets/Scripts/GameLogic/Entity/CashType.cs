using System.Collections.Generic;

namespace Assets.Scripts.GameLogic.Entity
{
    public class CashType
    {
        public static readonly CashType One = new CashType(1, "ONE");
        public static readonly CashType Five = new CashType(5, "FIVE");
        public static readonly CashType Ten = new CashType(10, "TEN");
        public static readonly CashType Fifty = new CashType(50, "FIFTY");
        public static readonly CashType OneHundred = new CashType(100, "ONE HUNDRED");
        public static readonly CashType FiveHundred = new CashType(500, "FIVE HUNDRED");

        public CashType(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public static IEnumerable<CashType> Values
        {
            get
            {
                yield return One;
                yield return Five;
                yield return Ten;
                yield return Fifty;
                yield return OneHundred;
                yield return FiveHundred;
            }
        }

        public static CashType FindByValue(int value)
        {
            foreach (CashType item in Values)
            {
                if (item.Value.Equals(value))
                {
                    return item;
                }
            }

            return null;
        }

        public int Value { get; set; }

        public string Name { get; set; }
    }
}
