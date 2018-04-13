using System.Collections.Generic;

public class Lot
{
    string name;
    GroupColor groupColor;
    int price;
    List<Building> buildingList;
    Mortgage mortgage;
    LotCard lotCard;
    int lotCardId;

    public static explicit operator Lot(TitleDeedCard v)
    {
        Lot lot = new Lot();
        lot.Name = v.Name;
        lot.GroupColor = v.GroupColor;
        lot.Price = v.Price;
        lot.LotCardId = v.Id;
        return lot;
    }

    public static explicit operator Lot(RailroadCard v)
    {
        Lot lot = new Lot();
        lot.Name = v.Name;
        lot.Price = v.Price;
        lot.LotCardId = v.Id;
        return lot;
    }

    public static explicit operator Lot(UtilityCard v)
    {
        Lot lot = new Lot();
        lot.Name = v.Name;
        lot.Price = v.Price;
        lot.LotCardId = v.Id;
        return lot;
    }

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

    public int Price
    {
        get
        {
            return price;
        }

        set
        {
            price = value;
        }
    }

    public List<Building> BuildingList
    {
        get
        {
            return buildingList;
        }

        set
        {
            buildingList = value;
        }
    }

    public Mortgage Mortgage
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

    public LotCard LotCard
    {
        get
        {
            return lotCard;
        }

        set
        {
            lotCard = value;
        }
    }

    public int LotCardId
    {
        get
        {
            return lotCardId;
        }

        set
        {
            lotCardId = value;
        }
    }

    #endregion
}
