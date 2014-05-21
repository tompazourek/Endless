using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (source == null) throw new ArgumentNullException("source");
            return source.Shuffle().First();
        }

        /// <summary>
        /// Returns first random element that satisfies the predicate.
        /// </summary>
        public static T Random<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");
            return source.Shuffle().First(predicate);
        }

        /// <summary>
        /// Orders the sequence randomly.
        /// </summary>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.OrderBy(_ => Guid.NewGuid());
        }

        /// <summary>
        /// Splits the given sequence into pieces of given size and returns sequence of these pieces.
        /// </summary>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize)
        {
            if (source == null) throw new ArgumentNullException("source");

            if (chunkSize <= 0)
                throw new ArgumentException(String.Format("Chunk size must be greater than zero, {0} given.", chunkSize));

            using (IEnumerator<T> enumerator = source.GetEnumerator())
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
        /// Returns true if this sequence starts with given subsequence
        /// </summary>
        public static bool StartsWith<T>(this IEnumerable<T> source, IEnumerable<T> subsequence)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (subsequence == null) throw new ArgumentNullException("subsequence");

            using (IEnumerator<T> subsequenceIterator = subsequence.GetEnumerator())
            using (IEnumerator<T> sourceIterator = source.GetEnumerator())
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
        /// Casts dynamically. Alternative to original Cast<> LINQ method, which does not make the use of conversion operators.
        /// </summary>
        public static IEnumerable<TResult> DynamicCast<TResult>(this IEnumerable source)
        {
            return source.Cast<dynamic>().Select(result => (TResult) result);
        }
    }
}