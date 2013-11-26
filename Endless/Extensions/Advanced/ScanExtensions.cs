using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless.Advanced
{
    /// <summary>
    /// Scan paradigm functions. Similar to fold reductions (<seealso cref="FoldExtensions"/>), but instead of returning a final value it returns a list of all the intermediate values.
    /// </summary>
    public static class ScanExtensions
    {
        /// <summary>
        /// Returns sequence containing: seed, func(seed, x0), func(func(seed, x0), x1), func(func(func(seed, x0), x1), x2), ... 
        /// </summary>
        /// <typeparam name="T1">Seed item type, result sequence item type</typeparam>
        /// <typeparam name="T2">Sequence item type</typeparam>
        public static IEnumerable<T1> Scanl<T1, T2>(this IEnumerable<T2> sequence, Func<T1, T2, T1> func, T1 seed)
        {
            // ReSharper disable PossibleMultipleEnumeration
            yield return seed;

            if (sequence.Empty())
                yield break;

            T2 x = sequence.First();
            IEnumerable<T2> xs = sequence.Tail();
            IEnumerable<T1> result = Scanl(xs, func, func(seed, x));
            foreach (T1 item in result)
            {
                yield return item;
            }
            // ReSharper restore PossibleMultipleEnumeration
        }

        /// <summary>
        /// Returns sequence containing: x0, func(x0, x1), func(func(x0, x1), x2), func(func(func(x0, x1), x2), x3), ... 
        /// </summary>
        /// <typeparam name="T">Sequence item type</typeparam>
        public static IEnumerable<T> Scanl1<T>(this IEnumerable<T> sequence, Func<T, T, T> func)
        {
            // ReSharper disable PossibleMultipleEnumeration
            if (sequence.Empty())
                return Enumerable.Empty<T>();

            return Scanl(sequence.Tail(), func, sequence.First());
            // ReSharper restore PossibleMultipleEnumeration
        }

        /// <summary>
        /// Right-to-Left equivalent of <see cref="Scanl{T1,T2}"/>.
        /// Returns sequence containing: ..., func(xn-1, func(xn, seed)), func(xn, seed), seed
        /// </summary>
        /// <typeparam name="T1">Sequence item type</typeparam>
        /// <typeparam name="T2">Seed item type, result sequence item type</typeparam>
        public static IEnumerable<T2> Scanr<T1, T2>(this IEnumerable<T1> sequence, Func<T1, T2, T2> func, T2 seed)
        {
            // ReSharper disable PossibleMultipleEnumeration
            if (sequence.Empty())
            {
                yield return seed;
                yield break;
            }

            T1 x = sequence.First();
            IEnumerable<T1> xs = sequence.Tail();

            IEnumerable<T2> qs = Scanr(xs, func, seed);
            T2 q = qs.First();

            yield return func(x, q);
            foreach (T2 item in qs)
            {
                yield return item;
            }
            // ReSharper restore PossibleMultipleEnumeration
        }

        /// <summary>
        /// Right-to-Left equivalent of <see cref="Scanl1{T}"/>.
        /// Returns sequence containing: ..., func(xn-2, func(xn-1, xn)), func(xn-1, xn)
        /// </summary>
        /// <typeparam name="T">Sequence item type</typeparam>
        public static IEnumerable<T> Scanr1<T>(this IEnumerable<T> sequence, Func<T, T, T> func)
        {
            // ReSharper disable PossibleMultipleEnumeration
            if (sequence.Empty())
                yield break;

            T x = sequence.First();
            IEnumerable<T> xs = sequence.Tail();

            if (xs.Empty())
            {
                yield return x;
                yield break;
            }

            IEnumerable<T> qs = Scanr1(xs, func);
            T q = qs.First();

            yield return func(x, q);
            foreach (T item in qs)
            {
                yield return item;
            }
            // ReSharper restore PossibleMultipleEnumeration
        }
    }
}