using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    public static partial class EnumerableOverloads
    {
        /// <summary>
        /// Concatenates two sequences with lazy second sequence.
        /// </summary>
        /// <param name="first">The first sequence to concatenate.</param>
        /// <param name="second">The function generating a sequence to concatenate to the first sequence.</param>
        /// <remarks>
        /// The second parameter function will be called only when items at that position need to be evaluated (i.e. all the items of first collections were already enumerated). Otherwise the function will not be called at all.
        /// </remarks>
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains the concatenated elements of the two input sequences.
        /// </returns>
        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, Func<IEnumerable<TSource>> second)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            foreach (var source in first)
                yield return source;

            foreach (var source in second())
                yield return source;
        }
    }
}