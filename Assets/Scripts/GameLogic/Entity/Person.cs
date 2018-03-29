using System;

public class Person
{
    PersonType personType;
    int cash;

    #region Getters and Setters

    public PersonType PersonType
    {
        get
        {
            return personType;
        }

        set
        {
            personType = value;
        }
    }

    public int Cash
    {
        get
        {
            return cash;
        }

        set
        {
            cash = value;
        }
    }

    #endregion
}
