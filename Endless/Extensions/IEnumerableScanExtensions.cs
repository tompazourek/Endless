using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    /// <summary>
    /// Extensions to generic enumerables that follow the scan paradigm
    /// </summary>
    public static class IEnumerableScanExtensions
    {
        public static IEnumerable<T1> Scanl<T1, T2>(this IEnumerable<T2> list, Func<T1, T2, T1> func, T1 start)
        {
            yield return start;

            if (list.Empty())
                yield break;

            var x = list.First();
            var xs = list.Tail();
            var result = Scanl(xs, func, func(start, x));
            foreach (var item in result)
            {
                yield return item;
            }
        }

        public static IEnumerable<T> Scanl1<T>(this IEnumerable<T> list, Func<T, T, T> func)
        {
            if (list.Empty())
                return Enumerable.Empty<T>();

            return Scanl(list.Tail(), func, list.First());
        }
    }
}