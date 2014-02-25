using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    /// <summary>
    /// Extensions that help to generate infinite collections (endless IEnumerables)
    /// </summary>
    public static class Generate
    {
        /// <summary>
        /// Creates IEnumerable containing one item
        /// </summary>
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }

        /// <summary>
        /// Creates an infinite list where the first item is calculated by applying the function on the argument,
        /// the second item by applying the function on the previous result and so on.
        /// </summary>
        /// <returns>IEnumerable of: seed, func(seed), func(func(seed)), ...</returns>
        public static IEnumerable<T> Iterate<T>(this T seed, Func<T, T> func)
        {
            if (func == null) throw new ArgumentNullException("func");

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
			if (func == null) throw new ArgumentNullException("func");

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

        // ReSharper disable FunctionNeverReturns

        /// <summary>
        /// Creates an infinite list where all items are the first argument.
        /// </summary>
        /// <returns>IEnumerable of: seed, seed, seed, seed, ...</returns>
        public static IEnumerable<T> Repeat<T>(this T seed)
        {
            while (true)
                yield return seed;
        }

        // ReSharper restore FunctionNeverReturns

        // ReSharper disable FunctionNeverReturns

        /// <summary>
        /// Creates an infinite list where all items are generated by the given function.
        /// </summary>
        /// <returns>IEnumerable of: func(), func(), func(), func(), ...</returns>
        public static IEnumerable<T> Repeat<T>(this Func<T> func)
        {
            if (func == null) throw new ArgumentNullException("func");

            while (true)
                yield return func();
        }

        // ReSharper restore FunctionNeverReturns

        /// <summary>
        /// Creates a circular list from a finite one.
        /// </summary>
        public static IEnumerable<T> Cycle<T>(this IEnumerable<T> values)
        {
            if (values == null) throw new ArgumentNullException("values");

            // ReSharper disable PossibleMultipleEnumeration
            while (true)
            {
                if (values.IsEmpty())
                    yield break;

                foreach (T item in values)
                    yield return item;
            }
            // ReSharper restore PossibleMultipleEnumeration
        }
    }
}