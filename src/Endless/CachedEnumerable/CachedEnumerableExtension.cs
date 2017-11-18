using System.Collections.Generic;

namespace Endless
{
    public static class CachedEnumerableExtension
    {
        /// <summary>
        /// Returns enumerable that is cached (lazily).
        /// </summary>
        /// <remarks>
        /// No value from source enumerator will be enumerated twice. The values once enumerated are stored in internal list.
        /// Warning: The cached enumerable needs to be disposed (since the enumerator of the source is also IDisposable).
        /// </remarks>
        public static ICachedEnumerable<T> Cached<T>(this IEnumerable<T> source) => new CachedEnumerable<T>(source);
    }
}