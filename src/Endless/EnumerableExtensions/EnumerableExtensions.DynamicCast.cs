using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Casts dynamically. Alternative to original Cast&lt;&gt; LINQ method, which does not make the use of conversion operators.
        /// </summary>
        /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">Thrown when cast is not supported.</exception>
        public static IEnumerable<TResult> DynamicCast<TResult>(this IEnumerable source)
        {
            return source.Cast<dynamic>().Select(result => (TResult)result);
        }
    }
}