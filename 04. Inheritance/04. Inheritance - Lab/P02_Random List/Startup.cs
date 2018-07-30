using System;

public class Startup
{
    static void Main()
    {
        var randomList = new RandomList();
        randomList.Add("34wfsdsd");
        randomList.Add("444");
        randomList.Add("asdf");
        randomList.Add("55");

        Console.WriteLine(randomList.RandomString());
    }
}