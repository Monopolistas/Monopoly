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

    public static explicit operator TitleDeedCard(TitleDeedCardScriptableObject v)
    {
        TitleDeedCard titleDeedCard = new TitleDeedCard();
        titleDeedCard.Id = v.id;
        titleDeedCard.Name = v.name;
        titleDeedCard.Rent = v.rent;
        titleDeedCard.OneHouseRent = v.rentOneHouse;
        titleDeedCard.TwoHousesRent = v.rentTwoHouses;
        titleDeedCard.ThreeHousesRent = v.rentThreeHouses;
        titleDeedCard.FourHousesRent = v.rentFourHouses;
        titleDeedCard.HotelRent = v.rentHotel;
        titleDeedCard.Mortgage = v.mortgage;
        titleDeedCard.BuildingPrice = v.buildingPrice;
        return titleDeedCard;
    }

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

    #endregion
}
