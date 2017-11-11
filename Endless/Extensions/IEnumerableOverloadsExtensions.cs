using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    /// <summary>
    /// Existing enumerable extensions overloads
    /// </summary>
    public static class IEnumerableOverloadsExtensions
    {
        /// <summary>
        /// Enumerable select many without the projection function. Used to flatten sequence by one level.
        /// </summary>
        public static IEnumerable<T> SelectMany<T>(this IEnumerable<IEnumerable<T>> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.SelectMany(Identity<IEnumerable<T>>.Func);
        }

        /// <summary>
        /// Sequence without given items. Overload of Enumerable.Except for items given in params.
        /// </summary>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, params T[] items)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.Except((IEnumerable<T>)items);
        }

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

        /// <summary>
        /// Merges two sequences in a sequence of tuples
        /// </summary>
        public static IEnumerable<Tuple<T1, T2>> Zip<T1, T2>(this IEnumerable<T1> first, IEnumerable<T2> second)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            return first.Zip(second, Tuple.Create);
        }

        /// <summary>
        /// Converts sequence of tuples to dictionary
        /// </summary>
        public static IDictionary<T1, T2> ToDictionary<T1, T2>(this IEnumerable<Tuple<T1, T2>> sequence)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            return sequence.ToDictionary(x => x.Item1, x => x.Item2);
        }
    }
}