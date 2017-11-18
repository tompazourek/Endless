using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
