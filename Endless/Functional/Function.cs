using System;

namespace Endless.Functional
{
    /// <summary>
    /// Functional extensions
    /// </summary>
    public static partial class Function
    {
        /// <summary>
        /// Flips binary function arguments
        /// </summary>
        public static Func<T2, T1, TResult> Flip<T1, T2, TResult>(this Func<T1, T2, TResult> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            return (x, y) => func(y, x);
        }

        /// <summary>
        /// Flips binary action arguments
        /// </summary>
        public static Action<T2, T1> Flip<T1, T2>(this Action<T1, T2> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            return (x, y) => action(y, x);
        }

        /// <summary>
        /// Applies function to a result, but can be still read from the end (as fluent interfaces do)
        /// </summary>
        public static TOut Pipe<TIn, TOut>(this TIn _this, Func<TIn, TOut> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            return func(_this);
        }
    }
}