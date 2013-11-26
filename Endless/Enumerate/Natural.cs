using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    /// <summary>
    /// Natural numbers
    /// </summary>
    public static class Natural
    {
        /// <summary>
        /// Sequence of natural numbers with zero (0, 1, 2, 3, ...)
        /// </summary>
        public static IEnumerable<int> NumbersWithZero
        {
            get { return Enumerate.From(0); }
        }

        /// <summary>
        /// Sequence of natural numbers (1, 2, 3, ...)
        /// </summary>
        public static IEnumerable<int> Numbers
        {
            get { return Enumerate.From(1); }
        }
    }
}
