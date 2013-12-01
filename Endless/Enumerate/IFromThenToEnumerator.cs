using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace Endless
{
    internal interface IFromThenToEnumerator<T> : IEnumerator<T> where T : struct
    {
        IFromThenToEnumerator<T> Clone();
        IFromThenToEnumerator<T> CloneWithThenRestriction(T then);
        IFromThenToEnumerator<T> CloneWithToRestriction(T to);
    }
}