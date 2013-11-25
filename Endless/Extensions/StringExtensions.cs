using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    /// <summary>
    /// Extensions to strings and enumerables of char
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Creates new string out of given chars.
        /// </summary>
        public static string BuildString(this IEnumerable<char> chars)
        {
            return new string(chars.ToArray());
        }

        /// <summary>
        /// Concatenates given strings.
        /// </summary>
        public static string JoinStrings(this IEnumerable<string> strings)
        {
            string result = string.Concat(strings);
            return result;
        }

        /// <summary>
        /// Concatenates given strings with given separator.
        /// </summary>
        public static string JoinStrings(this IEnumerable<string> strings, string separator)
        {
            string result = string.Join(separator, strings);
            return result;
        }
    }
}