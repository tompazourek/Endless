using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System;

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