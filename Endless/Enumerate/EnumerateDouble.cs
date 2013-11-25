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
        public static IEnumerable<double> From(double n0)
        {
            return n0.Iterate(x => ++x);
        }

        public static IEnumerable<double> FromThen(double n0, double n1)
        {
            double distance = n1 - n0;
            if (distance == 0)
                return n0.Yield();

            unchecked
            {
                return n0.Iterate(x => x + distance);
            }
        }

        public static IEnumerable<double> FromTo(double n0, double m)
        {
            return FromThenTo(n0, ++n0, m);
        }

        public static IEnumerable<double> FromThenTo(double n0, double n1, double m)
        {
            Func<double, bool> predicate = n0 > n1 ? (x => x >= m) : new Func<double, bool>(x => x <= m);
            return FromThen(n0, n1).TakeWhile(predicate);
        }
    }
}