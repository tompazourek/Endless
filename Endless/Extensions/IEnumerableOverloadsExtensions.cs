using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (source == null) throw new ArgumentNullException("source");
            return source.SelectMany(Identity<IEnumerable<T>>.Func);
        }

        /// <summary>
        /// Sequence without given item. Overload of Enumerable.Except for single item.
        /// </summary>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, T item)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.Except(item.Yield());
        }

        /// <summary>
        /// Concatenates two sequences with lazy second sequence.
        /// </summary>
        /// <param name="first">The first sequence to concatenate.</param>
        /// <param name="second">The sequence to concatenate to the first sequence.</param>
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that contains the concatenated elements of the two input sequences.
        /// </returns>
        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, Func<IEnumerable<TSource>> second)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");

            foreach (TSource source in first)
                yield return source;

            foreach (TSource source in second())
                yield return source;
        }

        /// <summary>
        /// Merges two sequences in a sequence of tuples
        /// </summary>
        public static IEnumerable<Tuple<T1, T2>> Zip<T1, T2>(this IEnumerable<T1> first, IEnumerable<T2> second)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            return first.Zip(second, (x, y) => Tuple.Create(x, y));
        }

        /// <summary>
        /// Converts sequence of tuples to dictionary
        /// </summary>
        public static IDictionary<T1, T2> ToDictionary<T1, T2>(this IEnumerable<Tuple<T1, T2>> sequence)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            return sequence.ToDictionary(x => x.Item1, x => x.Item2);
        }

    }
}