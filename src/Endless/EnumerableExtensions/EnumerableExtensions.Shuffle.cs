using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Orders the sequence randomly.
        /// </summary>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.OrderBy(_ => Guid.NewGuid());
        }
    }
}