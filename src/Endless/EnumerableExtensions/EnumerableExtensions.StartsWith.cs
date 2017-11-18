using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns true if this sequence starts with given subsequence
        /// </summary>
        public static bool StartsWith<T>(this IEnumerable<T> source, IEnumerable<T> subsequence)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (subsequence == null) throw new ArgumentNullException(nameof(subsequence));

            using (var subsequenceIterator = subsequence.GetEnumerator())
            using (var sourceIterator = source.GetEnumerator())
            {
                while (subsequenceIterator.MoveNext())
                {
                    if (!sourceIterator.MoveNext())
                        return false;

                    if (!subsequenceIterator.Current.Equals(sourceIterator.Current))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns true if this sequence starts with given subsequence
        /// </summary>
        public static bool StartsWith<T>(this IEnumerable<T> source, params T[] sequence) => StartsWith(source, sequence.AsEnumerable());
    }
}