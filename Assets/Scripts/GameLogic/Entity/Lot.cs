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

    public static explicit operator Lot(TitleDeedCardScriptableObject v)
    {
        Lot lot = new Lot();
        lot.Name = v.name;
        lot.GroupColor = GroupColor.FindByName(v.groupColor);
        lot.Price = v.price;
        lot.LotCardId = v.id;
        return lot;
    }

    public static explicit operator Lot(RailroadCardScriptableObject v)
    {
        Lot lot = new Lot();
        lot.Name = v.name;
        lot.Price = v.price;
        lot.LotCardId = v.id;
        return lot;
    }

    public static explicit operator Lot(UtilityCardScriptableObject v)
    {
        Lot lot = new Lot();
        lot.Name = v.name;
        lot.Price = v.price;
        lot.LotCardId = v.id;
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
