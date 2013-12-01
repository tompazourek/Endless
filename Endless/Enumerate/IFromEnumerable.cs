using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace Endless
{
    public interface IFromEnumerable<T> : IFromThenEnumerable<T>
    {
        IFromThenEnumerable<T> Then(T thenNumber);
    }
}