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
    public static class AggregateRightExtensions
    {
        /// <summary>
        /// Applies an accumulator function over a sequence. The specified seed value is used as the initial accumulator value.
        /// The elements are combined from the right (starting at the end of the collection).
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
        /// <param name="sequence">Sequence to accumulate over</param>
        /// <param name="end">Seed value</param>
        /// <param name="func">An accumulator function to be invoked on each element.</param>
        /// <returns>The final accumulator value.</returns>
        public static TAccumulate AggregateRight<TSource, TAccumulate>(this IEnumerable<TSource> sequence, TAccumulate end, Func<TSource, TAccumulate, TAccumulate> func)
        {
            // ReSharper disable PossibleMultipleEnumeration
            if (sequence.IsEmpty())
                return end;

            return func(sequence.First(),
                        sequence.Tail().Any()
                            ? AggregateRight(sequence.Tail(), end, func)
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
        public static TSource AggregateRight<TSource>(this IEnumerable<TSource> sequence, Func<TSource, TSource, TSource> func)
        {
            // ReSharper disable PossibleMultipleEnumeration
            return sequence.Tail().Any()
                ? func(sequence.First(), AggregateRight(sequence.Tail(), func))
                : sequence.First();
            // ReSharper restore PossibleMultipleEnumeration
        }
    }
}