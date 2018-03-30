using System.Collections.Generic;

public class BuildingType
{
    public static readonly BuildingType HOUSE = new BuildingType(1, "HOUSE");
    public static readonly BuildingType HOTEL = new BuildingType(2, "HOTEL");

    int code;
    string name;

    public BuildingType(int code, string name)
    {
        this.code = code;
        this.name = name;
    }

    public static IEnumerable<BuildingType> Values
    {
        get
        {
            yield return HOUSE;
            yield return HOTEL;
        }
    }

    public static BuildingType FindByCode(int code)
    {
        BuildingType type = null;
        foreach (BuildingType item in Values)
        {
            if (code.Equals(item.code))
            {
                type = item;
            }
        }
        return type;
    }

    public int Code
    {
        get
        {
            return code;
        }

        set
        {
            code = value;
        }
    }

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

    public override bool Equals(object obj)
    {
        var type = obj as BuildingType;
        return type != null &&
               code == type.code;
    }

    public override int GetHashCode()
    {
        return -1021610220 + code.GetHashCode();
    }

}
