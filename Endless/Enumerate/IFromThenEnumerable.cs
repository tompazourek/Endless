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
        IEnumerable<T> To(T toNumber);
    }
}