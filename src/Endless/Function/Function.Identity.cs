using System;

namespace Endless
{
    /// <summary>
    /// Static class containing identity function
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Function<T>
    {
        /// <summary>
        /// Generic identity function
        /// </summary>
        public static Func<T, T> Identity { get; } = x => x;
    }
}