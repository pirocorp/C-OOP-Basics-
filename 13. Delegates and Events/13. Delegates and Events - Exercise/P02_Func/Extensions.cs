namespace P02_Func
{
    using System;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            var result = new List<T>();

            foreach (var element in collection)
            {
                if (condition(element))
                {
                    result.Add(element);
                }
                else
                {
                    break;
                }
            }

            return result;
        }
    }
}