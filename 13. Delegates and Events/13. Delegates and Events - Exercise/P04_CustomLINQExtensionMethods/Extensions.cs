namespace P04_CustomLINQExtensionMethods
{
    using System;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> condition)
        {
            var result = new List<T>();
            foreach (var element in collection)
            {
                if (!condition(element))
                {
                    result.Add(element);
                }
            }

            return result;
        }

        public static TSelector Max<TSource, TSelector>(this IEnumerable<TSource> collection, Func<TSource, TSelector> selector)
            where TSelector : IComparable<TSelector>
        {
            var max = default(TSelector);
            foreach (var element in collection)
            {
                if (max == null)
                {
                    max = selector(element);
                }
                else
                {
                    if (max.CompareTo(selector(element)) == -1)
                    {
                        max = selector(element);
                    }
                }
            }

            return max;
        }
    }
}