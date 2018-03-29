using System;

public class RailroadCard : LotCard
{
    int rent;
    int twoRailroadsRent;
    int threeRailroadsRent;
    int fourRailroadsRent;

    public static explicit operator RailroadCard(RailroadCardScriptableObject v)
    {
        RailroadCard railroadCard = new RailroadCard();
        railroadCard.Id = v.id;
        railroadCard.Name = v.name;
        railroadCard.Rent = v.rent;
        railroadCard.TwoRailroadsRent = v.rentWithTwo;
        railroadCard.ThreeRailroadsRent = v.rentWithThree;
        railroadCard.FourRailroadsRent = v.rentWithFour;
        railroadCard.Mortgage = v.mortgage;
        return railroadCard;
    }

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
