using System;

public class Transaction
{
    TransactionType transactionType;
    Person from;
    Person to;
    int value;

	public Transaction(TransactionType transactionType, Person from, Person to, int value)
	{
        this.transactionType = transactionType;
        this.from = from;
        this.to = to;
        this.value = value;
	}

    public void ExecuteTransaction()
    {
        if (TransactionType.CREDIT.Code.Equals(transactionType.Code))
        {
            from.Cash -= value;
            to.Cash += value;
        }
        if (TransactionType.DEBT.Code.Equals(transactionType.Code))
        {
            from.Cash += value;
            to.Cash -= value;
        }
        if (TransactionType.BUY.Code.Equals(transactionType.Code))
        {
            from.Cash -= value;
            to.Cash += value;
        }
        if (TransactionType.SELL.Code.Equals(transactionType.Code))
        {
            from.Cash += value;
            to.Cash -= value;
        }
    }

    #region Getters and Setters

    public TransactionType TransactionType
    {
        get
        {
            return transactionType;
        }

        set
        {
            transactionType = value;
        }
    }

    public Person From
    {
        get
        {
            return from;
        }

        set
        {
            from = value;
        }
    }

    public Person To
    {
        get
        {
            return to;
        }

        set
        {
            to = value;
        }
    }

    public int Value
    {
        get
        {
            return value;
        }

        set
        {
            this.value = value;
        }
    }

    #endregion
}
