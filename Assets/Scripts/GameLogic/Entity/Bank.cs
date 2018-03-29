using System.Collections.Generic;

public class Bank : Person
{
    List<Building> buildingList;
    List<LotCard> lotCardList;

    public Bank()
    {
        Cash = Constants.BANK_INITIAL_CASH;
        buildingList = new List<Building>();
        lotCardList = new List<LotCard>();
    }

    #region Getters and Setters

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

    public List<LotCard> LotCardList
    {
        get
        {
            return lotCardList;
        }

        set
        {
            lotCardList = value;
        }
    }

    #endregion
}
