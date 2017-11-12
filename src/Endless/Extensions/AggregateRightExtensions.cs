using System;
using Endless.Functional;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    /// <summary>
    /// Fold reductions (<see cref="Enumerable.Aggregate{TSource}" /> variations)
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
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            if (func == null) throw new ArgumentNullException(nameof(func));

            var result = sequence.Reverse().Aggregate(end, func.Flip());
            return result;
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
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            if (func == null) throw new ArgumentNullException(nameof(func));

            var result = sequence.Reverse().Aggregate(func.Flip());
            return result;
        }
    }
}