using System.Collections.Generic;

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