using System;

class ObjectCloning
{
    static void Main()
    {
		var initialList =
			new LinkedList<string>("Old fellow John",
			new LinkedList<string>("Granny Yaga",
			new LinkedList<string>("King Kiro")));

		var deeplyClonedList = initialList.Clone();
		deeplyClonedList.Value = "1st changed";
		deeplyClonedList.NextNode.Value = "2nd changed";

		Console.WriteLine("initial list = {0}", initialList);
		Console.WriteLine("deeply cloned list = {0}", deeplyClonedList);

		Console.WriteLine();

		initialList =
			new LinkedList<string>("Old fellow John",
			new LinkedList<string>("Granny Yaga",
			new LinkedList<string>("King Kiro")));

		var shallowCopy = initialList.ShallowCopy();
		shallowCopy.Value = "1st changed";
		shallowCopy.NextNode.Value = "2nd changed";

		Console.WriteLine("initial list = {0}", initialList);
		Console.WriteLine("shallow cloned list = {0}", shallowCopy);

		Console.WriteLine();

		initialList =
			new LinkedList<string>("Old fellow John",
			new LinkedList<string>("Granny Yaga",
			new LinkedList<string>("King Kiro")));

		var memberwiseCopy = initialList.MemberwiseCopy();
		memberwiseCopy.Value = "1st changed";
		memberwiseCopy.NextNode.Value = "2nd changed";

		Console.WriteLine("initial list = {0}", initialList);
		Console.WriteLine("memberwise cloned list = {0}", memberwiseCopy);
	}
}
