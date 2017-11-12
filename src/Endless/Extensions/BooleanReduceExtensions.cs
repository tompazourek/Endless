using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    /// <summary>
    /// Boolean reductions
    /// </summary>
    public static class BooleanReduceExtensions
    {
        /// <summary>
        /// Returns true if all the elements in the sequence are true (lazy).
        /// </summary>
        public static bool And(this IEnumerable<bool> sequence)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            return sequence.All(Identity<bool>.Func);
        }

        /// <summary>
        /// Returns true if all the elements in the sequence evaluate to true (lazy).
        /// </summary>
        public static bool And(this IEnumerable<Func<bool>> sequence)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            return sequence.All(x => x());
        }

        /// <summary>
        /// Returns true when any of the elements in the sequence is true (lazy).
        /// </summary>
        public static bool Or(this IEnumerable<bool> sequence)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            return sequence.Any(Identity<bool>.Func);
        }

        /// <summary>
        /// Returns true when any of the elements in the sequence evaluate to true (lazy).
        /// </summary>
        public static bool Or(this IEnumerable<Func<bool>> sequence)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            return sequence.Any(x => x());
        }
    }
}