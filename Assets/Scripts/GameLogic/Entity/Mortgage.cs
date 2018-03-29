using System;

public class Mortgage
{
    int value;
    Lot lot;

	public Mortgage()
	{
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

    public Lot Lot
    {
        get
        {
            return lot;
        }

        set
        {
            lot = value;
        }
    }
}
