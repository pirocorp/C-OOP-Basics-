namespace P03_Action
{
    using System;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var element in collection)
            {
                action(element);
            }
        }
    }
}