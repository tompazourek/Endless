using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    /// <summary>
    /// Existing enumerable extensions overloads
    /// </summary>
    public static partial class EnumerableOverloads
    {
        /// <summary>
        /// Enumerable select many without the projection function. Used to flatten sequence by one level.
        /// </summary>
        public static IEnumerable<T> SelectMany<T>(this IEnumerable<IEnumerable<T>> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.SelectMany(Function<IEnumerable<T>>.Identity);
        }
    }
}