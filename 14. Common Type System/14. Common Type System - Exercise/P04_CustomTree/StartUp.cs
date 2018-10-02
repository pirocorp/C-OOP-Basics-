namespace P04_CustomTree
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var bst = new BinarySearchTree<int>(10);
            bst.Add(5);
            bst.Add(15);
            bst.Add(3);
            bst.Add(4);
            bst.Add(2);
            bst.Add(20);
            bst.Add(17);
            bst.Add(40);
            bst.Add(25);
            bst.Add(19);
            bst.Add(16);
            bst.Add(43);
            bst.Add(12);
            bst.Add(14);
            bst.Add(11);
            bst.Add(13);
            bst.Add(18);

            var bstAsArray = bst.ToArray();
            Console.WriteLine(string.Join(", ", bstAsArray));

            var cloneBst = bst.Clone();
            var cloneVstAsArray = cloneBst.ToArray();

            var test = bst.Search(20);

            bst.Delete(20);
            bstAsArray = bst.ToArray();

            Console.WriteLine(string.Join(", ", bstAsArray));
            Console.WriteLine(string.Join(", ", cloneVstAsArray));
        }
    }
}
