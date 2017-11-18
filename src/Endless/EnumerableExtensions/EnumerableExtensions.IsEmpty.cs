using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns true if the given sequence is empty.
        /// </summary>
        public static bool IsEmpty<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            return !sequence.Any();
        }
    }
}