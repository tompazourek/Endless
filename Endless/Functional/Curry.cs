using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless.Functional
{
    public static partial class Function
    {
        /// <summary>
        /// Curryfication of binary function
        /// </summary>
        public static Func<T1, Func<T2, TResult>> Curry<T1, T2, TResult>(this Func<T1, T2, TResult> func)
        {
            if (func == null) throw new ArgumentNullException("func");
            return x => (y => func(x, y));
        }

        /// <summary>
        /// Curryfication of ternary function
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func)
        {
            if (func == null) throw new ArgumentNullException("func");
            return x => (y => new Func<T3, TResult>(z => func(x, y, z)));
        }

        /// <summary>
        /// Curryfication of 4-ary function
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> Curry<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func)
        {
            if (func == null) throw new ArgumentNullException("func");
            return a => (b => (c => new Func<T4, TResult>(d => func(a, b, c, d))));
        }

        /// <summary>
        /// Curryfication of binary action
        /// </summary>
        public static Func<T1, Action<T2>> Curry<T1, T2>(this Action<T1, T2> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            return x => (y => action(x, y));
        }

        /// <summary>
        /// Curryfication of ternary action
        /// </summary>
        public static Func<T1, Func<T2, Action<T3>>> Curry<T1, T2, T3>(this Action<T1, T2, T3> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            return x => (y => new Action<T3>(z => { action(x, y, z); }));
        }

        /// <summary>
        /// Curryfication of 4-ary action
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Action<T4>>>> Curry<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            return a => (b => (c => new Action<T4>(d => { action(a, b, c, d); })));
        }
    }
}