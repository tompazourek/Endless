using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    public static partial class EnumerableOverloads
    {
        /// <summary>
        /// Sequence without given items. Overload of Enumerable.Except for items given in params.
        /// </summary>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, params T[] items)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.Except((IEnumerable<T>)items);
        }
    }
}