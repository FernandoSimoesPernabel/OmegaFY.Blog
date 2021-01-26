using System;
using System.Collections.Generic;

namespace OmegaFY.Blog.Common.Extensions
{

    public static class IEnumerableExtensions
    {

        public static void ForEachItem<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (T item in collection)
                action(item);
        }

    }

}
