namespace _05._Greedy_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GreedyTimes
    {
        static void Main()
        {
            var inputLine = long.Parse(Console.ReadLine());
            var safeContents = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var myBag = new Dictionary<string, Dictionary<string, long>>();


            for (var i = 0; i < safeContents.Length; i += 2)
            {
                var currentItem = safeContents[i];
                var quantity = long.Parse(safeContents[i + 1]);

                var itemType = string.Empty;

                if (currentItem.Length == 3)
                {
                    itemType = "Cash";
                }
                else if (currentItem.ToLower().EndsWith("gem"))
                {
                    itemType = "Gem";
                }
                else if (currentItem.ToLower() == "gold")
                {
                    itemType = "Gold";
                }

                if (itemType == "")
                {
                    continue;
                }
                else if (inputLine < myBag.Values.Select(x => x.Values.Sum()).Sum() + quantity)
                {
                    continue;
                }

                switch (itemType)
                {
                    case "Gem":
                        if (!myBag.ContainsKey(itemType))
                        {
                            if (myBag.ContainsKey("Gold"))
                            {
                                if (quantity > myBag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (myBag[itemType].Values.Sum() + quantity > myBag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!myBag.ContainsKey(itemType))
                        {
                            if (myBag.ContainsKey("Gem"))
                            {
                                if (quantity > myBag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (myBag[itemType].Values.Sum() + quantity > myBag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!myBag.ContainsKey(itemType))
                {
                    myBag[itemType] = new Dictionary<string, long>();
                }

                if (!myBag[itemType].ContainsKey(currentItem))
                {
                    myBag[itemType][currentItem] = 0;
                }

                myBag[itemType][currentItem] += quantity;
            }

            foreach (var x in myBag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");

                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}