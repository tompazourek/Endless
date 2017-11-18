using System;
using System.Collections.Generic;

namespace Endless
{
    public static partial class Generate
    {
        /// <summary>
        /// Creates an infinite list where the first item is calculated by applying the function on the argument,
        /// the second item by applying the function on the previous result and so on.
        /// </summary>
        /// <returns>IEnumerable of: seed, func(seed), func(func(seed)), ...</returns>
        public static IEnumerable<T> Iterate<T>(this T seed, Func<T, T> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));

            while (true)
            {
                yield return seed;
                seed = func(seed);
            }
        }

        /// <summary>
        /// Creates an infinite list where the first two items are given,
        /// and the next item is generated from current and previous item using given function.
        /// </summary>
        /// <returns>IEnumerable of: seed1, seed2, func(seed1, seed2), func(seed2, func(seed1, seed2)), ...</returns>
        public static IEnumerable<T> Iterate<T>(T seed1, T seed2, Func<T, T, T> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));

            var previous = seed1;
            var current = seed2;

            yield return previous;
            yield return current;
            while (true)
            {
                var next = func(previous, current);
                yield return next;

                previous = current;
                current = next;
            }
        }
    }
}