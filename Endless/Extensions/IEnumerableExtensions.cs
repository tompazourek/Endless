using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endless.Func;

namespace Endless
{
    /// <summary>
    /// Extensions to generic enumerables
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// All elements in the sequence except the last one
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<T> Init<T>(this IEnumerable<T> list)
        {
            using (IEnumerator<T> enumerator = list.GetEnumerator())
            {
                T previous;

                if (enumerator.MoveNext())
                    previous = enumerator.Current;
                else
                    yield break;

                while (enumerator.MoveNext())
                {
                    yield return previous;
                    previous = enumerator.Current;
                }
            }
        }

        /// <summary>
        /// Enumerable select many without the projection function. Used to flatten sequence by one level.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> SelectMany<T>(this IEnumerable<IEnumerable<T>> source)
        {
            return source.SelectMany(Identity<IEnumerable<T>>.Func);
        }

        /// <summary>
        /// All elements except the first one
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<T> Tail<T>(this IEnumerable<T> list)
        {
            return list.Skip(1);
        }

        /// <summary>
        /// Returns true if the given sequence is empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool Empty<T>(this IEnumerable<T> list)
        {
            return !list.Any();
        }

        /// <summary>
        /// Returns random element out of given sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Random<T>(this IEnumerable<T> source)
        {
            return source.Shuffle().First();
        }

        /// <summary>
        /// Returns first random element that satisfies the predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T Random<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.Shuffle().First(predicate);
        }

        /// <summary>
        /// Orders the sequence randomly.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(_ => Guid.NewGuid());
        }

        /// <summary>
        /// Sequence without given item. Overload of Enumerable.Except for single item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, T item)
        {
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
            foreach (TSource source in first)
                yield return source;

            foreach (TSource source in second())
                yield return source;
        }
        
        /// <summary>
        /// Returns all elements of the sequence from the begining until given element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, T item)
        {
            return source.TakeWhile(x => !Equals(x, item));
        }

        /// <summary>
        /// Returns elements from a sequence until given predicate is true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.TakeWhile(x => !predicate(x));
        }

        /// <summary>
        /// Returns elements from a sequence until given predicate is true. The element's index is used in the logic of the predicate function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
        {
            return source.TakeWhile((x, index) => !predicate(x, index));
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as they are not equal to given element, then returns the remaining elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<T> SkipUntil<T>(this IEnumerable<T> source, T item)
        {
            return source.SkipWhile(x => !Equals(x, item));
        }

        /// <summary>
        /// Bypasses elements in a sequence until given predicate is true, then returns the remaining elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> SkipUntil<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.SkipWhile(x => !predicate(x));
        }

        /// <summary>
        /// Bypasses elements in a sequence until given predicate is true, then returns the remaining elements. The element's index is used in the logic of the predicate function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> SkipUntil<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
        {
            return source.SkipWhile((x, index) => !predicate(x, index));
        }

        /// <summary>
        /// Splits the given sequence into pieces of given size and returns sequence of these pieces.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize)
        {
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
        /// Sorts the elements of the sequence in ascending order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> Order<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(Identity<T>.Func);
        }

        /// <summary>
        /// Sorts the elements of the sequence in descending order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrderDescending<T>(this IEnumerable<T> source)
        {
            return source.OrderByDescending(Identity<T>.Func);
        }
    }
}