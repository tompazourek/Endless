using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    /// <summary>
    /// Extensions to generic enumerables that follow the reduce paradigm
    /// </summary>
    public static class IEnumerableReduceExtensions
    {
        public static T1 Foldl<T1, T2>(this IEnumerable<T2> list, Func<T1, T2, T1> func, T1 start)
        {
            return list.Aggregate(start, func);
        }

        public static T Foldl1<T>(this IEnumerable<T> list, Func<T, T, T> func)
        {
            return list.Tail().Aggregate(list.First(), func);
        }

        public static T2 Foldr<T1, T2>(this IEnumerable<T1> list, Func<T1, T2, T2> func, T2 end)
        {
            return func(list.First(),
                        list.Tail().Any()
                            ? Foldr(list.Tail(), func, end)
                            : end);
        }

        public static T Foldr1<T>(this IEnumerable<T> list, Func<T, T, T> func)
        {
            return list.Tail().Any()
                       ? func(list.First(), Foldr1(list.Tail(), func))
                       : list.First();
        }

        public static bool And(this IEnumerable<bool> list)
        {
            if (list.Empty())
                return true;

            bool head = list.First();

            if (head)
                return And(list.Tail());

            return false;
        }

        public static bool And(this IEnumerable<Func<bool>> list)
        {
            if (list.Empty())
                return true;

            bool head = list.First()();

            if (head)
                return And(list.Tail());

            return false;
        }

        public static bool Or(this IEnumerable<bool> list)
        {
            if (list.Empty())
                return true;

            bool head = list.First();

            if (!head)
                return Or(list.Tail());

            return true;
        }

        public static bool Or(this IEnumerable<Func<bool>> list)
        {
            if (list.Empty())
                return true;

            bool head = list.First()();

            if (!head)
                return Or(list.Tail());

            return true;
        }
    }
}