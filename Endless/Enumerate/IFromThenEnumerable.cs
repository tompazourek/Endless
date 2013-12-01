using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace Endless
{
    public interface IFromThenEnumerable<T> : IEnumerable<T>
    {
        /// <summary>
        /// Bounds the collection of numbers from the right.
        /// </summary>
        /// <returns>(n0, ..., m)</returns>
        IEnumerable<T> To(T toNumber);
    }
}