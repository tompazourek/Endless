using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Endless
{
    public static partial class Generate
    {
        /// <summary>
        /// Creates a circular list from a finite one.
        /// </summary>
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public static IEnumerable<T> Cycle<T>(this IEnumerable<T> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));

            while (true)
            {
                if (values.IsEmpty())
                    yield break;

                foreach (var item in values)
                    yield return item;
            }
        }
    }
}