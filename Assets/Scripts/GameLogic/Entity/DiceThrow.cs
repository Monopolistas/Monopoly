using System;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrow
{
    List<Die> dieList;

    List<int> result;

    bool isThrown;

    public DiceThrow()
    {
        Reset();
    }

    public void Reset()
    {
        this.dieList = new List<Die>();
        this.dieList.Add(new Die());
        this.dieList.Add(new Die());
        this.result = new List<int>();
        this.result.Add(0);
        this.result.Add(0);
        this.isThrown = false;
    }

    public void Throw()
    {
        for (int i = 0; i < dieList.Count; i++)
        {
            dieList[i].Throw();
            result[i] = dieList[i].Result;
        }
        isThrown = true;
    }

    public bool isDouble()
    {
        if (isThrown)
            return result[0].Equals(result[1]);
        else
            return false;
    }

    public int Sum
    {
        get
        {
            return result[0] + result[1];
        }
    }

    public List<int> Result
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

    public bool IsThrown
    {
        get
        {
            return isThrown;
        }

        set
        {
            isThrown = value;
        }
    }
}
