using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    public static partial class Enumerate
    {
        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IEnumerable<long> From(long n0)
        {
            return n0.Iterate(x => ++x);
        }

        /// <summary>
        /// Endless collection of numbers starting with the n0 and n1, incremented by their distance.
        /// </summary>
        /// <returns>(n0, n1, n1 + distance, n1 + distance + distance, ...) where distance = n1 - n0</returns>
        public static IEnumerable<long> FromThen(long n0, long n1)
        {
            long distance = n1 - n0;
            if (distance == 0)
                return n0.Yield();

            unchecked
            {
                return n0.Iterate(x => x + distance);
            }
        }

        /// <summary>
        /// Bounded collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ..., m)</returns>
        public static IEnumerable<long> FromTo(long n0, long m)
        {
            return FromThenTo(n0, ++n0, m);
        }

        /// <summary>
        /// Bounded collection of numbers starting with the n0 and n1, incremented by their distance.
        /// </summary>
        /// <returns>(n0, n1, n1 + distance, n1 + distance + distance, ..., m) where distance = n1 - n0</returns>
        public static IEnumerable<long> FromThenTo(long n0, long n1, long m)
        {
            Func<long, bool> predicate = n0 > n1 ? (x => x >= m) : new Func<long, bool>(x => x <= m);
            return FromThen(n0, n1).TakeWhile(predicate);
        }
    }
}