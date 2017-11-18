using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Bypasses elements in a sequence as long as they are not equal to given element, then returns the remaining elements.
        /// </summary>
        public static IEnumerable<T> SkipUntil<T>(this IEnumerable<T> source, T item)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.SkipWhile(x => !Equals(x, item));
        }

        /// <summary>
        /// Bypasses elements in a sequence until given predicate is true, then returns the remaining elements.
        /// </summary>
        public static IEnumerable<T> SkipUntil<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.SkipWhile(x => !predicate(x));
        }

        /// <summary>
        /// Bypasses elements in a sequence until given predicate is true, then returns the remaining elements. The element's index is used in the logic of the predicate function.
        /// </summary>
        public static IEnumerable<T> SkipUntil<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.SkipWhile((x, index) => !predicate(x, index));
        }
    }
}