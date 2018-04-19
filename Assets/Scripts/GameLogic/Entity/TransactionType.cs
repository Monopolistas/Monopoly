using System.Collections.Generic;

namespace Assets.Scripts.GameLogic.Entity
{
    public class TransactionType
    {
        public static readonly TransactionType Buy = new TransactionType(1, "BUY");
        public static readonly TransactionType Sell = new TransactionType(2, "SELL");
        public static readonly TransactionType Credit = new TransactionType(3, "CREDIT");
        public static readonly TransactionType Debt = new TransactionType(4, "DEBT");

        public TransactionType(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public static IEnumerable<TransactionType> Values
        {
            get
            {
                yield return Buy;
                yield return Sell;
                yield return Credit;
                yield return Debt;
            }
        }

        public static TransactionType FindByCode(int code)
        {
            TransactionType type = null;
            foreach (TransactionType item in Values)
            {
                if (code.Equals(item.Code))
                {
                    type = item;
                }
            }
            return type;
        }

        public int Code { get; set; }

        public string Name { get; set; }
    }
}
