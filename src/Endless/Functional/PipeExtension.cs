using System;

namespace Endless.Functional
{
    public static class PipeExtension
    {
        /// <summary>
        /// Applies a function to given input in a fluent interface fashion.
        /// This makes it easy to apply many functions without getting lost in loads of brackets.
        /// </summary>
        public static TOut Pipe<TIn, TOut>(this TIn _this, Func<TIn, TOut> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            return func(_this);
        }
    }
}