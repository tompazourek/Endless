using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <param name="chars"></param>
        /// <returns></returns>
        public static string BuildString(this IEnumerable<char> chars)
        {
            return new string(chars.ToArray());
        }

        /// <summary>
        /// Concatenates given strings.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static string JoinStrings(this IEnumerable<string> strings)
        {
            var result = string.Concat(strings);
            return result;
        }

        /// <summary>
        /// Concatenates given strings with given separator.
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string JoinStrings(this IEnumerable<string> strings, string separator)
        {
            var result = string.Join(separator, strings);
            return result;
        }
    }
}