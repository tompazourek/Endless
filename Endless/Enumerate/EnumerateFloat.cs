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
        public static IEnumerable<float> From(float n0)
        {
            return n0.Iterate(x => ++x);
        }

        public static IEnumerable<float> FromThen(float n0, float n1)
        {
            float distance = n1 - n0;
            if (distance == 0)
                return n0.Yield();

            unchecked
            {
                return n0.Iterate(x => x + distance);
            }
        }

        public static IEnumerable<float> FromTo(float n0, float m)
        {
            return FromThenTo(n0, ++n0, m);
        }

        public static IEnumerable<float> FromThenTo(float n0, float n1, float m)
        {
            Func<float, bool> predicate = n0 > n1 ? (x => x >= m) : new Func<float, bool>(x => x <= m);
            return FromThen(n0, n1).TakeWhile(predicate);
        }
    }
}