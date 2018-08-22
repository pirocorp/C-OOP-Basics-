using System;

class GenericListExample
{
	static void Main()
	{
		// Declare a list of type int 
		var intList = new GenericList<int>();
		intList.Add(1);
		intList.Add(2);
		intList.Add(3);
		Console.WriteLine("Number of elements: {0}", intList.Count);
		for (var i = 0; i < intList.Count; i++)
		{
			var element = intList[i];
			Console.WriteLine(element);
		}

		Console.WriteLine();

		// Declare a list of type string
		var stringList = new GenericList<string>();
		stringList.Add("C#");
		stringList.Add("Java");
		stringList.Add("PHP");
		stringList.Add("SQL");
		Console.WriteLine("Number of elements: {0}", stringList.Count);
		for (var i = 0; i < stringList.Count; i++)
		{
			var element = stringList[i];
			Console.WriteLine(element);
		}
	}
}
