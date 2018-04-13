using System;

public class TitleDeedCard : LotCard
{
    int buildingPrice;
    int rent;
    int oneHouseRent;
    int twoHousesRent;
    int threeHousesRent;
    int fourHousesRent;
    int hotelRent;
    GroupColor groupColor;

    #region Getters and Setters

    public int BuildingPrice
    {
        get
        {
            return buildingPrice;
        }

        set
        {
            buildingPrice = value;
        }
    }

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

    public int OneHouseRent
    {
        get
        {
            return oneHouseRent;
        }

        set
        {
            oneHouseRent = value;
        }
    }

    public int TwoHousesRent
    {
        get
        {
            return twoHousesRent;
        }

        set
        {
            twoHousesRent = value;
        }
    }

    public int ThreeHousesRent
    {
        get
        {
            return threeHousesRent;
        }

        set
        {
            threeHousesRent = value;
        }
    }

    public int FourHousesRent
    {
        get
        {
            return fourHousesRent;
        }

        set
        {
            fourHousesRent = value;
        }
    }

    public int HotelRent
    {
        get
        {
            return hotelRent;
        }

        set
        {
            hotelRent = value;
        }
    }

    public GroupColor GroupColor
    {
        get
        {
            return groupColor;
        }

        set
        {
            groupColor = value;
        }
    }

    #endregion
}
