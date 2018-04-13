using System;

public class RailroadCard : LotCard
{
    int rent;
    int twoRailroadsRent;
    int threeRailroadsRent;
    int fourRailroadsRent;

    #region Getters and Setters 

    public int Rent
    {
        get
        {
            return rent;
        }

        set
        {
            rent = value;
        }
    }

    public int TwoRailroadsRent
    {
        get
        {
            return twoRailroadsRent;
        }

        set
        {
            twoRailroadsRent = value;
        }
    }

    public int ThreeRailroadsRent
    {
        get
        {
            return threeRailroadsRent;
        }

        set
        {
            threeRailroadsRent = value;
        }
    }

    public int FourRailroadsRent
    {
        get
        {
            return fourRailroadsRent;
        }

        set
        {
            fourRailroadsRent = value;
        }
    }

    #endregion
}
