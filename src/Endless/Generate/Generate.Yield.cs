using System;
using System.Collections.Generic;

namespace Endless
{
    /// <summary>
    /// Extensions that help to generate infinite collections (endless IEnumerables)
    /// </summary>
    public static partial class Generate
    {
        /// <summary>
        /// Creates IEnumerable containing one item
        /// </summary>
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }
    }
}