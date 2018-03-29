using System;
using System.Collections.Generic;

public class CashType
{
    public static readonly CashType ONE = new CashType(1, "ONE");
    public static readonly CashType FIVE = new CashType(5, "FIVE");
    public static readonly CashType TEN = new CashType(10, "TEN");
    public static readonly CashType FIFTY = new CashType(50, "FIFTY");
    public static readonly CashType ONE_HUNDRED = new CashType(100, "ONE HUNDRED");
    public static readonly CashType FIVE_HUNDRED = new CashType(500, "FIVE HUNDRED");

    int value;
    string name;

    public CashType(int value, string name)
    {
        this.value = value;
        this.name = name;
    }

    public static IEnumerable<CashType> Values
    {
        get
        {
            yield return ONE;
            yield return FIVE;
            yield return TEN;
            yield return FIFTY;
            yield return ONE_HUNDRED;
            yield return FIVE_HUNDRED;
        }
    }

    public static CashType FindByValue(int value)
    {
        foreach (CashType item in Values)
        {
            if (item.value.Equals(value))
            {
                return item;
            }
        }

        return null;
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
