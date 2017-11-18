using System.Collections;
using System.Collections.Generic;

namespace Endless
{
    internal class FromThenEnumerable<T> : IFromThenEnumerable<T> where T : struct
    {
        private readonly IFromThenToEnumerator<T> _enumerator;

        public FromThenEnumerable(IFromThenToEnumerator<T> enumerator)
        {
            _enumerator = enumerator;
        }

        public IEnumerable<T> To(T toNumber)
        {
            var enumerator = _enumerator.CloneWithToRestriction(toNumber);
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        public IEnumerator<T> GetEnumerator() => _enumerator.Clone();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}