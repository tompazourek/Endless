using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// All elements except the first one
        /// </summary>
        public static IEnumerable<T> Tail<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            return sequence.Skip(1);
        }
    }
}