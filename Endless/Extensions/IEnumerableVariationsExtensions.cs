#region License

// Copyright (C) Tomáš Pažourek, 2014
// All rights reserved.
// 
// Distributed under MIT license as a part of project Endless.
// https://github.com/tompazourek/Endless

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Endless
{
    /// <summary>
    /// Existing enumerable extensions variations
    /// </summary>
    public static class IEnumerableVariationsExtensions
    {
        /// <summary>
        /// All elements in the sequence except the last one
        /// </summary>
        public static IEnumerable<T> Init<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");

            using (IEnumerator<T> enumerator = sequence.GetEnumerator())
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
        /// All elements except the first one
        /// </summary>
        public static IEnumerable<T> Tail<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            return sequence.Skip(1);
        }

        /// <summary>
        /// Returns true if the given sequence is empty.
        /// </summary>
        public static bool IsEmpty<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            return !sequence.Any();
        }

        /// <summary>
        /// Returns all elements of the sequence from the begining until given element. The given element will not be part of the collection.
        /// </summary>
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, T item)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.TakeWhile(x => !Equals(x, item));
        }

        /// <summary>
        /// Returns elements from a sequence until given predicate is true.
        /// </summary>
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");
            return source.TakeWhile(x => !predicate(x));
        }

        /// <summary>
        /// Returns elements from a sequence until given predicate is true. The element's index is used in the logic of the predicate function.
        /// </summary>
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");
            return source.TakeWhile((x, index) => !predicate(x, index));
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as they are not equal to given element, then returns the remaining elements.
        /// </summary>
        public static IEnumerable<T> SkipUntil<T>(this IEnumerable<T> source, T item)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.SkipWhile(x => !Equals(x, item));
        }

        /// <summary>
        /// Bypasses elements in a sequence until given predicate is true, then returns the remaining elements.
        /// </summary>
        public static IEnumerable<T> SkipUntil<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");
            return source.SkipWhile(x => !predicate(x));
        }

        /// <summary>
        /// Bypasses elements in a sequence until given predicate is true, then returns the remaining elements. The element's index is used in the logic of the predicate function.
        /// </summary>
        public static IEnumerable<T> SkipUntil<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");
            return source.SkipWhile((x, index) => !predicate(x, index));
        }

        /// <summary>
        /// Sorts the elements of the sequence in ascending order
        /// </summary>
        public static IEnumerable<T> Sort<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.OrderBy(Identity<T>.Func);
        }

        /// <summary>
        /// Sorts the elements of the sequence in descending order
        /// </summary>
        public static IEnumerable<T> SortDescending<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.OrderByDescending(Identity<T>.Func);
        }
    }
}