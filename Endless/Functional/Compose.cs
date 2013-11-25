using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace Endless.Functional
{
    public static partial class Function
    {
        /// <summary>
        /// Functional composition. Compose(f, g)(x) = f(g(x)).
        /// </summary>
        /// <param name="second">Function that is applied second (outer)</param>
        /// <param name="first">Function that is applied first (inner)</param>
        public static Func<T1, T3> Compose<T1, T2, T3>(Func<T2, T3> second, Func<T1, T2> first)
        {
            var result = new Func<T1, T3>(x => second(first(x)));
            return result;
        }

        /// <summary>
        /// Functional composition chain. <see cref="Compose{T1,T2,T3}"/>
        /// </summary>
        public static Func<T1, T4> Compose<T1, T2, T3, T4>(Func<T3, T4> func3, Func<T2, T3> func2, Func<T1, T2> func1)
        {
            return Compose(func3, Compose(func2, func1));
        }

        /// <summary>
        /// Functional composition chain. <see cref="Compose{T1,T2,T3}"/>
        /// </summary>
        public static Func<T1, T5> Compose<T1, T2, T3, T4, T5>(Func<T4, T5> func4, Func<T3, T4> func3, Func<T2, T3> func2, Func<T1, T2> func1)
        {
            return Compose(func4, Compose(func3, func2, func1));
        }

        /// <summary>
        /// Functional composition chain. <see cref="Compose{T1,T2,T3}"/>
        /// </summary>
        public static Func<T1, T6> Compose<T1, T2, T3, T4, T5, T6>(Func<T5, T6> func5, Func<T4, T5> func4, Func<T3, T4> func3, Func<T2, T3> func2, Func<T1, T2> func1)
        {
            return Compose(func5, Compose(func4, func3, func2, func1));
        }

        /// <summary>
        /// Functional composition chain. <see cref="Compose{T1,T2,T3}"/>
        /// </summary>
        public static Func<T1, T7> Compose<T1, T2, T3, T4, T5, T6, T7>(Func<T6, T7> func6, Func<T5, T6> func5, Func<T4, T5> func4, Func<T3, T4> func3, Func<T2, T3> func2, Func<T1, T2> func1)
        {
            return Compose(func6, Compose(func5, func4, func3, func2, func1));
        }
    }
}