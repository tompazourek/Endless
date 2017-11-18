using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    public static partial class EnumerableOverloads
    {
        /// <summary>
        /// Merges two sequences in a sequence of tuples
        /// </summary>
        public static IEnumerable<Tuple<T1, T2>> Zip<T1, T2>(this IEnumerable<T1> first, IEnumerable<T2> second)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            return first.Zip(second, Tuple.Create);
        }
    }
}