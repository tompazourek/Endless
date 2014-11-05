#region License

// Copyright (C) Tomáš Pažourek, 2014
// All rights reserved.
// 
// Distributed under MIT license as a part of project Endless.
// https://github.com/tompazourek/Endless

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

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
            if (func == null) throw new ArgumentNullException("func");
            return (x, y) => func(y, x);
        }

        /// <summary>
        /// Flips binary action arguments
        /// </summary>
        public static Action<T2, T1> Flip<T1, T2>(this Action<T1, T2> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            return (x, y) => action(y, x);
        }

        /// <summary>
        /// Applies function to a result, but can be still read from the end (as fluent interfaces do)
        /// </summary>
        public static TOut Pipe<TIn, TOut>(this TIn _this, Func<TIn, TOut> func)
        {
            if (func == null) throw new ArgumentNullException("func");
            return func(_this);
        }
    }
}