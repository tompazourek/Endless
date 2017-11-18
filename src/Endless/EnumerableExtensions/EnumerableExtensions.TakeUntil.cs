using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns all elements of the sequence from the begining until given element. The given element will not be part of the collection.
        /// </summary>
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, T item)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.TakeWhile(x => !Equals(x, item));
        }

        /// <summary>
        /// Returns elements from a sequence until given predicate is true.
        /// </summary>
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.TakeWhile(x => !predicate(x));
        }

        /// <summary>
        /// Returns elements from a sequence until given predicate is true. The element's index is used in the logic of the predicate function.
        /// </summary>
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.TakeWhile((x, index) => !predicate(x, index));
        }
    }
}