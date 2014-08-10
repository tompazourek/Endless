using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Endless
{
    internal class FromEnumerable<T> : IFromEnumerable<T> where T : struct
    {
        private readonly T _from;

        public FromEnumerable(T from)
        {
            _from = from;
        }

        public IEnumerable<T> To(T toNumber)
        {
            using (IFromThenToEnumerator<T> enumerator = GetDynamicEnumerator().CloneWithToRestriction(toNumber))
            {
                while (enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                }
            }
        }

        public IFromThenEnumerable<T> Then(T thenNumber)
        {
            using (IFromThenToEnumerator<T> enumerator = GetDynamicEnumerator().CloneWithThenRestriction(thenNumber))
            {
                return new FromThenEnumerable<T>(enumerator);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetDynamicEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IFromThenToEnumerator<T> GetDynamicEnumerator()
        {
            return new DynamicFromThenToEnumerator<T>(_from);
        }
    }
}