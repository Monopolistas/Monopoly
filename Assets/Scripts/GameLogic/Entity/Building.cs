using System;

public class Building
{
    BuildingType buildingType;
    Lot lot;

    public Building(BuildingType buildingType)
    {
        this.buildingType = buildingType;
    }

    public BuildingType BuildingType
    {
        get
        {
            return buildingType;
        }

        set
        {
            buildingType = value;
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
