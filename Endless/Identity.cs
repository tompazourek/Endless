using System;

namespace Endless
{
    /// <summary>
    /// Static class containing identity function
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Identity<T>
    {
        /// <summary>
        /// Generic identity function
        /// </summary>
        public static Func<T, T> Func { get; } = x => x;
    }
}