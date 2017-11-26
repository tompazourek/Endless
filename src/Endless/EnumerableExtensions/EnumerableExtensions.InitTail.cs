using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Endless
{

    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// All elements in the sequence except the last one
        /// </summary>
        public static IEnumerable<T> Init<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));

            using (var enumerator = sequence.GetEnumerator())
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
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            return sequence.Skip(1);
        }
    }
}
