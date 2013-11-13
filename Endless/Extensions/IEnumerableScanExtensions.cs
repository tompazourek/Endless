using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    /// <summary>
    /// Extensions to generic enumerables that follow the scan paradigm
    /// </summary>
    public static class IEnumerableScanExtensions
    {
        /// <summary>
        /// Returns list containing: seed, func(seed, x0), func(func(seed, x0), x1), func(func(func(seed, x0), x1), x2), ... 
        /// </summary>
        /// <typeparam name="T1">Seed item type, result list item type</typeparam>
        /// <typeparam name="T2">List item type</typeparam>
        public static IEnumerable<T1> Scanl<T1, T2>(this IEnumerable<T2> list, Func<T1, T2, T1> func, T1 seed)
        {
            yield return seed;

            if (list.Empty())
                yield break;

            T2 x = list.First();
            IEnumerable<T2> xs = list.Tail();
            IEnumerable<T1> result = Scanl(xs, func, func(seed, x));
            foreach (T1 item in result)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Returns list containing: x0, func(x0, x1), func(func(x0, x1), x2), func(func(func(x0, x1), x2), x3), ... 
        /// </summary>
        /// <typeparam name="T">List item type</typeparam>
        public static IEnumerable<T> Scanl1<T>(this IEnumerable<T> list, Func<T, T, T> func)
        {
            if (list.Empty())
                return Enumerable.Empty<T>();

            return Scanl(list.Tail(), func, list.First());
        }

        /// <summary>
        /// Right-to-Left equivalent of <see cref="Scanl{T1,T2}"/>.
        /// Returns list containing: ..., func(xn-1, func(xn, seed)), func(xn, seed), seed
        /// </summary>
        /// <typeparam name="T1">List item type</typeparam>
        /// <typeparam name="T2">Seed item type, result list item type</typeparam>
        public static IEnumerable<T2> Scanr<T1, T2>(this IEnumerable<T1> list, Func<T1, T2, T2> func, T2 seed)
        {
            if (list.Empty())
            {
                yield return seed;
                yield break;
            }

            T1 x = list.First();
            IEnumerable<T1> xs = list.Tail();

            IEnumerable<T2> qs = Scanr(xs, func, seed);
            T2 q = qs.First();

            yield return func(x, q);
            foreach (T2 item in qs)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Right-to-Left equivalent of <see cref="Scanl1{T}"/>.
        /// Returns list containing: ..., func(xn-2, func(xn-1, xn)), func(xn-1, xn)
        /// </summary>
        /// <typeparam name="T">List item type</typeparam>
        public static IEnumerable<T> Scanr1<T>(this IEnumerable<T> list, Func<T, T, T> func)
        {
            if (list.Empty())
                yield break;

            T x = list.First();
            IEnumerable<T> xs = list.Tail();

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
        }
    }
}