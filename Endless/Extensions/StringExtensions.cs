using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Endless
{
    public static class StringExtensions
    {
        public static string BuildString(this IEnumerable<char> chars)
        {
            return new string(chars.ToArray());
        }

        public static string JoinStrings(this IEnumerable<string> strings)
        {
            var result = string.Concat(strings);
            return result;
        }

        public static string JoinStrings(this IEnumerable<string> strings, string separator)
        {
            var result = string.Join(separator, strings);
            return result;
        }
    }
}