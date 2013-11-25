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
        public static IEnumerable<decimal> From(decimal n0)
        {
            return n0.Iterate(x => ++x);
        }

        public static IEnumerable<decimal> FromThen(decimal n0, decimal n1)
        {
            decimal distance = n1 - n0;
            if (distance == 0)
                return n0.Yield();

            unchecked
            {
                return n0.Iterate(x => x + distance);
            }
        }

        public static IEnumerable<decimal> FromTo(decimal n0, decimal m)
        {
            return FromThenTo(n0, ++n0, m);
        }

        public static IEnumerable<decimal> FromThenTo(decimal n0, decimal n1, decimal m)
        {
            Func<decimal, bool> predicate = n0 > n1 ? (x => x >= m) : new Func<decimal, bool>(x => x <= m);
            return FromThen(n0, n1).TakeWhile(predicate);
        }
    }
}