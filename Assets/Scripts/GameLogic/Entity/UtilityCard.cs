using System;

public class UtilityCard : LotCard
{
    int multiplierWithOne;
    int multiplierWithTwo;

    #region Getters and Setters

    public int MultiplierWithOne
    {
        get
        {
            return multiplierWithOne;
        }

        set
        {
            multiplierWithOne = value;
        }
    }

    public int MultiplierWithTwo
    {
        get
        {
            return multiplierWithTwo;
        }

        set
        {
            multiplierWithTwo = value;
        }
    }

    #endregion
}
