using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="element"></param>
        /// <returns>The zero-based index of the first occurrence of item within the entire sequence if found; otherwise, –1.</returns>
        /// <remarks>
        /// This method determines equality using the default equality comparer EqualityComparer&lt;T&gt;.Default for T, the type of values in the sequence.
        /// </remarks>
        public static int IndexOf<T>(this IEnumerable<T> source, T element)
        {
            var currentIndex = 0;
            var comparer = EqualityComparer<T>.Default;
            foreach (var item in source)
            {
                if (comparer.Equals(item, element))
                {
                    return currentIndex;
                }
                currentIndex++;
            }
            return -1;
        }
    }
}