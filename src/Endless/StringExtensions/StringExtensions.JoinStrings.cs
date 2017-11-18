using System;
using System.Collections.Generic;

namespace Endless
{
    /// <summary>
    /// Extensions to strings and enumerables of char
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Concatenates given strings.
        /// </summary>
        public static string JoinStrings(this IEnumerable<string> strings)
        {
            if (strings == null) throw new ArgumentNullException(nameof(strings));
            var result = string.Concat(strings);
            return result;
        }

        /// <summary>
        /// Concatenates given strings with given separator.
        /// </summary>
        public static string JoinStrings(this IEnumerable<string> strings, string separator)
        {
            if (strings == null) throw new ArgumentNullException(nameof(strings));
            var result = string.Join(separator, strings);
            return result;
        }
    }
}