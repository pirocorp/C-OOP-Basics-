using System;
using System.Text;
using P09_CollectionHierarchy.Interfaces;

namespace P09_CollectionHierarchy
{
    public class Startup
    {
        private static StringBuilder resultingOutput = new StringBuilder();

        static void Main()
        {
            IAddCollection addcollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyList myList = new MyList();

            var input = Console.ReadLine().Split();

            FillCollection(input, addcollection);
            FillCollection(input, addRemoveCollection);
            FillCollection(input, myList);

            var numberOfRemovals = int.Parse(Console.ReadLine());

            RemoveOperation(numberOfRemovals, addRemoveCollection);
            RemoveOperation(numberOfRemovals, myList);

            Console.WriteLine(resultingOutput.ToString().Trim());
        }

        private static void FillCollection(string[] input, IAddCollection collection)
        {
            foreach (var str in input)
            {
                var index = collection.Add(str);
                resultingOutput.Append($"{index} ");
            }

            resultingOutput
                .Remove(resultingOutput.Length - 1, 1)
                .AppendLine();
        }

        private static void RemoveOperation(int numberOfRemovals, IAddRemoveCollection collection)
        {
            while (numberOfRemovals > 0)
            {
                var removedElement = collection.Remove();
                resultingOutput.Append($"{removedElement} ");
                numberOfRemovals--;
            }

            resultingOutput
                .Remove(resultingOutput.Length - 1, 1)
                .AppendLine();
        }
    }
}