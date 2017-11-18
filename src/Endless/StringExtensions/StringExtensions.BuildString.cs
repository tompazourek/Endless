using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    /// <summary>
    /// Extensions to strings and enumerables of char
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Creates new string out of given chars.
        /// </summary>
        public static string BuildString(this IEnumerable<char> chars)
        {
            if (chars == null) throw new ArgumentNullException(nameof(chars));
            return new string(chars.ToArray());
        }
    }
}