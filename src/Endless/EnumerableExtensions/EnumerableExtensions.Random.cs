using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns random element out of given sequence.
        /// </summary>
        public static T Random<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.Shuffle().First();
        }

        /// <summary>
        /// Returns first random element that satisfies the predicate.
        /// </summary>
        public static T Random<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.Shuffle().First(predicate);
        }
    }
}