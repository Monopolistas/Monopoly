using System.Collections.Generic;

public class TransactionType
{
    public static readonly TransactionType BUY = new TransactionType(1, "BUY");
    public static readonly TransactionType SELL = new TransactionType(2, "SELL");
    public static readonly TransactionType CREDIT = new TransactionType(3, "CREDIT");
    public static readonly TransactionType DEBT = new TransactionType(4, "DEBT");

    int code;
    string name;

	public TransactionType(int code, string name)
	{
        this.code = code;
        this.name = name;
	}

    public static IEnumerable<TransactionType> Values
    {
        get
        {
            yield return BUY;
            yield return SELL;
            yield return CREDIT;
            yield return DEBT;
        }
    }

    public static TransactionType FindByCode(string code)
    {
        TransactionType type = null;
        foreach (TransactionType item in Values)
        {
            if (code.Equals(item.code))
            {
                type = item;
            }
        }
        return type;
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
}
