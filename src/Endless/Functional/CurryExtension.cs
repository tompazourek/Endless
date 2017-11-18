using System;

namespace Endless.Functional
{
    public static class CurryExtension
    {
        /// <summary>
        /// Curryfication of binary function
        /// </summary>
        public static Func<T1, Func<T2, TResult>> Curry<T1, T2, TResult>(this Func<T1, T2, TResult> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            return x => (y => func(x, y));
        }

        /// <summary>
        /// Curryfication of ternary function
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            return x => (y => (z => func(x, y, z)));
        }

        /// <summary>
        /// Curryfication of 4-ary function
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> Curry<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            return a => (b => (c => (d => func(a, b, c, d))));
        }

        /// <summary>
        /// Curryfication of binary action
        /// </summary>
        public static Func<T1, Action<T2>> Curry<T1, T2>(this Action<T1, T2> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            return x => (y => action(x, y));
        }

        /// <summary>
        /// Curryfication of ternary action
        /// </summary>
        public static Func<T1, Func<T2, Action<T3>>> Curry<T1, T2, T3>(this Action<T1, T2, T3> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            return x => (y => (z => { action(x, y, z); }));
        }

        /// <summary>
        /// Curryfication of 4-ary action
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Action<T4>>>> Curry<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            return a => (b => (c => (d => { action(a, b, c, d); })));
        }
    }
}