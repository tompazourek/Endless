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
        public static IEnumerable<int> From(int n0)
        {
            return n0.Iterate(x => ++x);
        }

        public static IEnumerable<int> FromThen(int n0, int n1)
        {
            int distance = n1 - n0;
            if (distance == 0)
                return n0.Yield();

            unchecked
            {
                return n0.Iterate(x => x + distance);
            }
        }

        public static IEnumerable<int> FromTo(int n0, int m)
        {
            return FromThenTo(n0, ++n0, m);
        }

        public static IEnumerable<int> FromThenTo(int n0, int n1, int m)
        {
            Func<int, bool> predicate = n0 > n1 ? (x => x >= m) : new Func<int, bool>(x => x <= m);
            return FromThen(n0, n1).TakeWhile(predicate);
        }
    }
}