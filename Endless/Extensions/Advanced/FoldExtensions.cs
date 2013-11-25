using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless.Advanced
{
    /// <summary>
    /// Fold reductions (<see cref="Enumerable.Aggregate{TSource}"/> variations)
    /// </summary>
    public static class FoldExtensions
    {
        /// <summary>
        /// Applies an accumulator function over a sequence. The specified seed value is used as the initial accumulator value.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
        /// <param name="sequence">Sequence to accumulate over</param>
        /// <param name="func">An accumulator function to be invoked on each element.</param>
        /// <param name="start">Seed value</param>
        /// <returns>The final accumulator value.</returns>
        public static TAccumulate Foldl<TSource, TAccumulate>(this IEnumerable<TSource> sequence, Func<TAccumulate, TSource, TAccumulate> func, TAccumulate start)
        {
            return sequence.Aggregate(start, func);
        }

        /// <summary>
        /// Applies an accumulator function over a sequence. The initial accumulator value is the first element of the collection.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="sequence">Sequence to accumulate over</param>
        /// <param name="func">An accumulator function to be invoked on each element.</param>
        /// <returns>The final accumulator value.</returns>
        public static TSource Foldl1<TSource>(this IEnumerable<TSource> sequence, Func<TSource, TSource, TSource> func)
        {
            // ReSharper disable PossibleMultipleEnumeration
            return sequence.Tail().Aggregate(sequence.First(), func);
            // ReSharper restore PossibleMultipleEnumeration
        }

        /// <summary>
        /// Applies an accumulator function over a sequence. The specified seed value is used as the initial accumulator value.
        /// The elements are combined from the right (starting at the end of the collection).
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
        /// <param name="sequence">Sequence to accumulate over</param>
        /// <param name="func">An accumulator function to be invoked on each element.</param>
        /// <param name="end">Seed value</param>
        /// <returns>The final accumulator value.</returns>
        public static TAccumulate Foldr<TSource, TAccumulate>(this IEnumerable<TSource> sequence, Func<TSource, TAccumulate, TAccumulate> func, TAccumulate end)
        {
            // ReSharper disable PossibleMultipleEnumeration
            return func(sequence.First(),
                        sequence.Tail().Any()
                            ? Foldr(sequence.Tail(), func, end)
                            : end);
            // ReSharper restore PossibleMultipleEnumeration
        }

        /// <summary>
        /// Applies an accumulator function over a sequence. The initial accumulator value is the last element of the collection.
        /// The elements are combined from the right (starting at the end of the collection).
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="sequence">Sequence to accumulate over</param>
        /// <param name="func">An accumulator function to be invoked on each element.</param>
        /// <returns>The final accumulator value.</returns>
        public static TSource Foldr1<TSource>(this IEnumerable<TSource> sequence, Func<TSource, TSource, TSource> func)
        {
            // ReSharper disable PossibleMultipleEnumeration
            return sequence.Tail().Any()
                ? func(sequence.First(), Foldr1(sequence.Tail(), func))
                : sequence.First();
            // ReSharper restore PossibleMultipleEnumeration
        }
    }
}