using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endless.Func;

namespace Endless
{
    public static class IEnumerableExtensions
    {
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

        public static IEnumerable<T> SelectMany<T>(this IEnumerable<IEnumerable<T>> source)
        {
            return source.SelectMany(Identity<IEnumerable<T>>.Func);
        }

        public static IEnumerable<T> Tail<T>(this IEnumerable<T> list)
        {
            return list.Skip(1);
        }

        public static bool Empty<T>(this IEnumerable<T> list)
        {
            return !list.Any();
        }

        public static T Random<T>(this IEnumerable<T> source)
        {
            return source.Shuffle().First();
        }

        public static T Random<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.Shuffle().First(predicate);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(_ => Guid.NewGuid());
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, T item)
        {
            return source.Except(item.Yield());
        }

        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, T item)
        {
            return source.TakeWhile(x => !Equals(x, item));
        }

        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.TakeWhile(x => !predicate(x));
        }

        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
        {
            return source.TakeWhile((x, index) => !predicate(x, index));
        }

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
    }
}