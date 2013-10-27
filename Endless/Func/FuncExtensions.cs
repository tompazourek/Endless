using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless.Func
{
    public static class FuncExtensions
    {
        public static Func<T2, T1, TResult> Flip<T1, T2, TResult>(this Func<T1, T2, TResult> func)
        {
            return (x, y) => func(y, x);
        }

        public static Action<T2, T1> Flip<T1, T2>(this Action<T1, T2> action)
        {
            return (x, y) => action(y, x);
        }

        public static Func<T1, Func<T2, TResult>> Curry<T1, T2, TResult>(this Func<T1, T2, TResult> func)
        {
            return x => (y => func(x, y));
        }

        public static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func)
        {
            return x => (y => new Func<T3, TResult>(z => func(x, y, z)));
        }

        public static Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> Curry<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func)
        {
            return a => (b => (c => new Func<T4, TResult>(d => func(a, b, c, d))));
        }

        public static Func<T1, Action<T2>> Curry<T1, T2>(this Action<T1, T2> action)
        {
            return x => (y => action(x, y));
        }

        public static Func<T1, Func<T2, Action<T3>>> Curry<T1, T2, T3>(this Action<T1, T2, T3> action)
        {
            return x => (y => new Action<T3>(z => { action(x, y, z); }));
        }

        public static Func<T1, Func<T2, Func<T3, Action<T4>>>> Curry<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
        {
            return a => (b => (c => new Action<T4>(d => { action(a, b, c, d); })));
        }
    }
}