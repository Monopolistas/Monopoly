using System;

public class UtilityCard : LotCard
{
    int multiplierWithOne;
    int multiplierWithTwo;

    public static explicit operator UtilityCard(UtilityCardScriptableObject v)
    {
        UtilityCard utilityCard = new UtilityCard();
        utilityCard.Id = v.id;
        utilityCard.Name = v.name;
        utilityCard.MultiplierWithOne = v.rentWithOne;
        utilityCard.MultiplierWithTwo = v.rentWithTwo;
        utilityCard.Mortgage = v.mortgage;
        return utilityCard;
    }

    #region Getters and Setters

    public int MultiplierWithOne
    {
        get
        {
            return multiplierWithOne;
        }

        set
        {
            multiplierWithOne = value;
        }
    }

    public int MultiplierWithTwo
    {
        get
        {
            return multiplierWithTwo;
        }

        set
        {
            multiplierWithTwo = value;
        }
    }

    #endregion
}
