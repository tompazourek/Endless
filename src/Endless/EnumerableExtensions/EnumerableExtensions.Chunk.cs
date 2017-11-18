using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    public static partial class EnumerableExtensions
    {
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

        /// <summary>
        /// Groups results by contiguous values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<T, T>> ChunkBy<T>(this IEnumerable<T> source) => source.ChunkBy(EqualityComparer<T>.Default);

        /// <summary>
        /// Groups results by contiguous values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<T, T>> ChunkBy<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer) => source.ChunkBy(Function<T>.Identity, comparer);

        /// <summary>
        /// Groups results by contiguous keys
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<TKey, TSource>> ChunkBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) => source.ChunkBy(keySelector, EqualityComparer<TKey>.Default);

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

        #region Internals

        private static IEnumerable<T> GetChunk<T>(IEnumerator<T> enumerator, int chunkSize)
        {
            do
            {
                yield return enumerator.Current;
            } while (--chunkSize > 0 && enumerator.MoveNext());
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

        #endregion
    }
}