using System.Collections.Generic;

public class PersonType
{
    public static readonly PersonType PLAYER = new PersonType(1, "PLAYER");
    public static readonly PersonType BANK = new PersonType(2, "BANK");

    int code;
    string name;

    public PersonType(int code, string name)
	{
        this.code = code;
        this.name = name;
	}

    public static IEnumerable<PersonType> Values
    {
        get
        {
            yield return PLAYER;
            yield return BANK;
        }
    }

    public static PersonType FindByCode(string code)
    {
        PersonType type = null;
        foreach (PersonType item in Values)
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
}
