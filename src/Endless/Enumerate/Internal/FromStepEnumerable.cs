using System.Collections;
using System.Collections.Generic;

namespace Endless
{
    internal class FromStepEnumerable<T> : IFromStepEnumerable<T>
    {
        private readonly IFromStepToEnumerator<T> _enumerator;

        public FromStepEnumerable(IFromStepToEnumerator<T> enumerator)
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