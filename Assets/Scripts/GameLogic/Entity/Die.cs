using System;

public class Die
{
    int sides;

    int result;

    public Die()
    {
        this.sides = 6;
    }

    public void Throw()
    {
        System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

        result = (random.Next(sides) + 1);
    }

    public int Result
    {
        get
        {
            return this.result;
        }
        set
        {
            this.result = value;
        }
    }
}
