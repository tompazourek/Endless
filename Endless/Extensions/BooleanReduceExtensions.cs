using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // ReSharper disable PossibleMultipleEnumeration
            if (sequence.IsEmpty())
                return true;

            bool head = sequence.First();

            if (head)
                return And(sequence.Tail());

            return false;
            // ReSharper restore PossibleMultipleEnumeration
        }

        /// <summary>
        /// Returns true if all the elements in the sequence evaluate to true (lazy).
        /// </summary>
        public static bool And(this IEnumerable<Func<bool>> sequence)
        {
            // ReSharper disable PossibleMultipleEnumeration
            if (sequence.IsEmpty())
                return true;

            bool head = sequence.First()();

            if (head)
                return And(sequence.Tail());

            return false;
            // ReSharper restore PossibleMultipleEnumeration
        }

        /// <summary>
        /// Returns true when any of the elements in the sequence is true (lazy).
        /// </summary>
        public static bool Or(this IEnumerable<bool> sequence)
        {
            // ReSharper disable PossibleMultipleEnumeration
            if (sequence.IsEmpty())
                return true;

            bool head = sequence.First();

            if (!head)
                return Or(sequence.Tail());

            return true;
            // ReSharper restore PossibleMultipleEnumeration
        }

        /// <summary>
        /// Returns true when any of the elements in the sequence evaluate to true (lazy).
        /// </summary>
        public static bool Or(this IEnumerable<Func<bool>> sequence)
        {
            // ReSharper disable PossibleMultipleEnumeration
            if (sequence.IsEmpty())
                return true;

            bool head = sequence.First()();

            if (!head)
                return Or(sequence.Tail());

            return true;
            // ReSharper restore PossibleMultipleEnumeration
        }
    }
}