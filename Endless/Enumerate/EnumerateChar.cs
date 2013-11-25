using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    public static partial class Enumerate
    {
        public static IEnumerable<char> From(char n0)
        {
            return n0.Iterate(x => ++x);
        }

        public static IEnumerable<char> FromThen(char n0, char n1)
        {
            int distance = n1 - n0;
            if (distance == 0)
                return n0.Yield();

            unchecked
            {
                return n0.Iterate(x => (char) (x + distance));
            }
        }

        public static IEnumerable<char> FromTo(char n0, char m)
        {
            return FromThenTo(n0, ++n0, m);
        }

        public static IEnumerable<char> FromThenTo(char n0, char n1, char m)
        {
            Func<char, bool> predicate = n0 > n1 ? (x => x >= m) : new Func<char, bool>(x => x <= m);
            return FromThen(n0, n1).TakeWhile(predicate);
        }
    }
}