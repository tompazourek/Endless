using System;
using System.Collections.Generic;

namespace Endless
{
    /// <summary>
    /// Enumerable that uses internal cache.
    /// </summary>
    /// <remarks>Note that it is disposable, since the enumerator obtained from the source must be correctly disposed.</remarks>
    /// <typeparam name="T"></typeparam>
    public interface ICachedEnumerable<out T> : IEnumerable<T>, IDisposable
    {
    }
}