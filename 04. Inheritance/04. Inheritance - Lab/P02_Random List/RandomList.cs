﻿using System;
using System.Collections.Generic;

public class RandomList : List<string>
{
    private Random random;

    public RandomList()
    {
        this.random = new Random();
    }

    public string RandomString()
    {
        string result = null;

        if (this.Count > 0)
        {
            var randomIndex = random.Next(0, this.Count);
            result = this[randomIndex];
            this.RemoveAt(randomIndex);
        }

        return result;
    }
}