using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    public static partial class EnumerableOverloads
    {
        /// <summary>
        /// Converts sequence of tuples to dictionary
        /// </summary>
        public static IDictionary<T1, T2> ToDictionary<T1, T2>(this IEnumerable<Tuple<T1, T2>> sequence)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            return sequence.ToDictionary(x => x.Item1, x => x.Item2);
        }
    }
}