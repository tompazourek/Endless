using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endless.Functional;

namespace Endless
{
    /// <summary>
    /// Scan paradigm functions. Similar to fold reductions (<seealso cref="AggregateRightExtensions"/>), but instead of returning a final value it returns a list of all the intermediate values.
    /// </summary>
    public static class ScanExtensions
    {
        /// <summary>
        /// Returns sequence containing: seed, func(seed, x0), func(func(seed, x0), x1), func(func(func(seed, x0), x1), x2), ... 
        /// </summary>
        /// <typeparam name="T1">Seed item type, result sequence item type</typeparam>
        /// <typeparam name="T2">Sequence item type</typeparam>
        public static IEnumerable<T1> Scan<T1, T2>(this IEnumerable<T2> sequence, T1 seed, Func<T1, T2, T1> func)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (func == null) throw new ArgumentNullException("func");

            // ReSharper disable PossibleMultipleEnumeration
            yield return seed;

            var current = seed;
            foreach (var item in sequence)
            {
                current = func(current, item);
                yield return current;
            }
            // ReSharper restore PossibleMultipleEnumeration
        }

        /// <summary>
        /// Returns sequence containing: x0, func(x0, x1), func(func(x0, x1), x2), func(func(func(x0, x1), x2), x3), ... 
        /// </summary>
        /// <typeparam name="T">Sequence item type</typeparam>
        public static IEnumerable<T> Scan<T>(this IEnumerable<T> sequence, Func<T, T, T> func)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (func == null) throw new ArgumentNullException("func");

            // ReSharper disable PossibleMultipleEnumeration
            if (sequence.IsEmpty())
                return Enumerable.Empty<T>();

            var result = Scan(sequence.Tail(), sequence.First(), func);
            return result;
            // ReSharper restore PossibleMultipleEnumeration
        }

        /// <summary>
        /// Right-to-Left equivalent of <see cref="Scan{T1,T2}"/>.
        /// Returns sequence containing: ..., func(xn-1, func(xn, seed)), func(xn, seed), seed
        /// </summary>
        /// <typeparam name="T1">Sequence item type</typeparam>
        /// <typeparam name="T2">Seed item type, result sequence item type</typeparam>
        public static IEnumerable<T2> ScanRight<T1, T2>(this IEnumerable<T1> sequence, T2 seed, Func<T1, T2, T2> func)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (func == null) throw new ArgumentNullException("func");

            var result = sequence.Reverse().Scan(seed, func.Flip()).Reverse();
            return result;
        }

        /// <summary>
        /// Right-to-Left equivalent of <see cref="Scan{T}"/>.
        /// Returns sequence containing: ..., func(xn-2, func(xn-1, xn)), func(xn-1, xn)
        /// </summary>
        /// <typeparam name="T">Sequence item type</typeparam>
        public static IEnumerable<T> ScanRight<T>(this IEnumerable<T> sequence, Func<T, T, T> func)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (func == null) throw new ArgumentNullException("func");

            var result = sequence.Reverse().Scan(func.Flip()).Reverse();
            return result;
        }
    }
}