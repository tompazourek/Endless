using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    /// <summary>
    /// Custom xtensions to generic enumerables
    /// </summary>
    public static class IEnumerableCustomExtensions
    {
        /// <summary>
        /// Returns random element out of given sequence.
        /// </summary>
        public static T Random<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.Shuffle().First();
        }

        /// <summary>
        /// Returns first random element that satisfies the predicate.
        /// </summary>
        public static T Random<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.Shuffle().First(predicate);
        }

        /// <summary>
        /// Orders the sequence randomly.
        /// </summary>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.OrderBy(_ => Guid.NewGuid());
        }

        /// <summary>
        /// Splits the given sequence into pieces of given size and returns sequence of these pieces.
        /// </summary>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (chunkSize <= 0)
                throw new ArgumentException(string.Format("Chunk size must be greater than zero, {0} given.", chunkSize));

            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    yield return GetChunk(enumerator, chunkSize).ToList();
                }
            }
        }

        private static IEnumerable<T> GetChunk<T>(IEnumerator<T> enumerator, int chunkSize)
        {
            do
            {
                yield return enumerator.Current;
            } while (--chunkSize > 0 && enumerator.MoveNext());
        }

        /// <summary>
        /// Groups results by contiguous values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<T, T>> ChunkBy<T>(this IEnumerable<T> source)
        {
            return source.ChunkBy(EqualityComparer<T>.Default);
        }

        /// <summary>
        /// Groups results by contiguous values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<T, T>> ChunkBy<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            return source.ChunkBy(Identity<T>.Func, comparer);
        }

        /// <summary>
        /// Groups results by contiguous keys
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<TKey, TSource>> ChunkBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return source.ChunkBy(keySelector, EqualityComparer<TKey>.Default);
        }

        /// <summary>
        /// Groups results by contiguous keys
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<TKey, TSource>> ChunkBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));

            using (var enumerator = source.GetEnumerator())
            {
                var movedNext = false;
                while (movedNext || enumerator.MoveNext())
                {
                    yield return GetChunkByGrouping(enumerator, keySelector, comparer, out movedNext);
                }
            }
        }

        private static IGrouping<TKey, TSource> GetChunkByGrouping<TKey, TSource>(IEnumerator<TSource> enumerator, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, out bool movedNext)
        {
            var currentKey = keySelector(enumerator.Current);
            var items = new List<TSource>();
            var grouping = new TrivialGrouping<TKey, TSource>(currentKey, items);
            do
            {
                items.Add(enumerator.Current);
                if (!enumerator.MoveNext())
                {
                    movedNext = false;
                    break;
                }
                if (!comparer.Equals(keySelector(enumerator.Current), currentKey))
                {
                    movedNext = true;
                    break;
                }
            } while (true);
            return grouping;
        }

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
        public static bool StartsWith<T>(this IEnumerable<T> source, params T[] sequence)
        {
            return StartsWith(source, sequence.AsEnumerable());
        }

        /// <summary>
        /// Casts dynamically. Alternative to original Cast&lt;&gt; LINQ method, which does not make the use of conversion operators.
        /// </summary>
        /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">Thrown when cast is not supported.</exception>
        public static IEnumerable<TResult> DynamicCast<TResult>(this IEnumerable source)
        {
            return source.Cast<dynamic>().Select(result => (TResult)result);
        }

        /// <summary>
        /// Returns enumerable that is cached (lazily).
        /// </summary>
        /// <remarks>
        /// No value from source enumerator will be enumerated twice. The values once enumerated are stored in internal list.
        /// Warning: The cached enumerable needs to be disposed (since the enumerator of the source is also IDisposable).
        /// </remarks>
        public static ICachedEnumerable<T> Cached<T>(this IEnumerable<T> source)
        {
            return new CachedEnumerable<T>(source);
        }
    }
}