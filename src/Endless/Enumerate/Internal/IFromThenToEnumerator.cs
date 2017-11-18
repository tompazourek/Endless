using System.Collections.Generic;

namespace Endless
{
    internal interface IFromThenToEnumerator<T> : IEnumerator<T> where T : struct
    {
        IFromThenToEnumerator<T> Clone();
        IFromThenToEnumerator<T> CloneWithThenRestriction(T then);
        IFromThenToEnumerator<T> CloneWithToRestriction(T to);
    }
}