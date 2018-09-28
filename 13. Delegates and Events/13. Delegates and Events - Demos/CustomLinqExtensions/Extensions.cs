namespace CustomLinqExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static IEnumerable<T> TakeLast<T>(
            this IEnumerable<T> collection, int takeCount)
        {
            var totalCount = collection.Count();
            var skipCount = totalCount - takeCount;

            return collection
                .Skip(skipCount)
                .Take(takeCount);
        }

        public static IEnumerable<T> Filter<T>(
            this IEnumerable<T> collection, Predicate<T> filterPredicate)
        {
            var matches = new List<T>();
            foreach (var element in collection)
            {
                if (filterPredicate(element))
                {
                    matches.Add(element);
                }
            }

            return matches;
        }

        public static IEnumerable<K> Project<T, K>(
            this IEnumerable<T> collection, Func<T, K> selectFunc)
        {
            var list = new List<K>();
            foreach (var element in collection)
            {
                var projectedElement = selectFunc(element);
                list.Add(projectedElement);
            }

            return list;
        }

        public static IEnumerable<T> SortBy<T, K>(
            this IEnumerable<T> collection, Func<T, K> selectFunc)
            where K : IComparable<K>
        {
            var list = collection.ToArray();
            var hasSwapped = true;
            while (hasSwapped)
            {
                hasSwapped = false;
                for (var i = 0; i < list.Length - 1; i++)
                {
                    var current = selectFunc(list[i]);
                    var next = selectFunc(list[i + 1]);
                    if (current.CompareTo(next) > 0)
                    {
                        Swap(list, i, i + 1);
                        hasSwapped = true;
                    }
                }
            }

            return list;
        }

        private static void Swap<T>(T[] array, int index1, int index2) 
        {
            var oldValue = array[index1];
            array[index1] = array[index2];
            array[index2] = oldValue;
        }
    }
}
