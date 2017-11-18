using System;

namespace Endless.Functional
{
    public static class ThenExtension
    {
        /// <summary>
        /// Functional composition. g.Then(f)(x) = f(g(x)).
        /// </summary>
        /// <param name="first">Function that is applied first (inner)</param>
        /// <param name="second">Function that is applied second (outer)</param>
        public static Func<T1, T3> Then<T1, T2, T3>(this Func<T1, T2> first, Func<T2, T3> second)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            var result = new Func<T1, T3>(x => second(first(x)));
            return result;
        }
    }
}