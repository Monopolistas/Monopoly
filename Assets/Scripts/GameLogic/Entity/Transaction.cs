namespace Assets.Scripts.GameLogic.Entity
{
    public class Transaction
    {
        public Transaction(TransactionType transactionType, Person from, Person to, int value)
        {
            TransactionType = transactionType;
            From = from;
            To = to;
            Value = value;
        }

        public void ExecuteTransaction()
        {
            if (TransactionType.Credit.Code.Equals(TransactionType.Code))
            {
                From.Cash -= Value;
                To.Cash += Value;
            }
            if (TransactionType.Debt.Code.Equals(TransactionType.Code))
            {
                From.Cash += Value;
                To.Cash -= Value;
            }
            if (TransactionType.Buy.Code.Equals(TransactionType.Code))
            {
                From.Cash -= Value;
                To.Cash += Value;
            }
            if (TransactionType.Sell.Code.Equals(TransactionType.Code))
            {
                From.Cash += Value;
                To.Cash -= Value;
            }
        }

        #region Getters and Setters

        public TransactionType TransactionType { get; set; }

        public Person From { get; set; }

        public Person To { get; set; }

        public int Value { get; set; }

        #endregion
    }
}
