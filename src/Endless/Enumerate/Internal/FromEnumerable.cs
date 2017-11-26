using System;
using System.Collections;
using System.Collections.Generic;

namespace Endless
{
    internal class FromEnumerable<T> : IFromEnumerable<T>
    {
        private readonly IFromStepToEnumerator<T> _enumerator;

        public FromEnumerable(T from) : this(new DynamicFromStepToEnumerator<T>(from))
        {
        }

        public FromEnumerable(IFromStepToEnumerator<T> enumerator)
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

        public IFromStepEnumerable<T> Then(T thenNumber)
        {
            var enumerator = _enumerator.CloneWithThenRestriction(thenNumber);
            return new FromStepEnumerable<T>(enumerator);
        }

        public IFromStepEnumerable<T> Step(Func<T, T> stepFunction)
        {
            var enumerator = _enumerator.CloneWithStepRestriction(stepFunction);
            return new FromStepEnumerable<T>(enumerator);
        }

        public IEnumerator<T> GetEnumerator() => _enumerator.Clone();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}