using System;

public class LotCard : Card
{
    string name;
    Lot lot;
    int mortgage;

    #region Getters and Setters

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

    public int Mortgage
    {
        get
        {
            return mortgage;
        }

        set
        {
            mortgage = value;
        }
    }

    #endregion
}
