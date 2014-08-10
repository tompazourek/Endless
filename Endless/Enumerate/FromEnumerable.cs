using System.Collections;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace Endless
{
    internal class FromEnumerable<T> : IFromEnumerable<T> where T : struct
    {
        private readonly IFromThenToEnumerator<T> _enumerator;

        public FromEnumerable(T from) : this(new DynamicFromThenToEnumerator<T>(from))
        {
        }

        public FromEnumerable(IFromThenToEnumerator<T> enumerator)
        {
            _enumerator = enumerator;
        }
        
        public IEnumerable<T> To(T toNumber)
        {
            IFromThenToEnumerator<T> enumerator = _enumerator.CloneWithToRestriction(toNumber);
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        public IFromThenEnumerable<T> Then(T thenNumber)
        {
            IFromThenToEnumerator<T> enumerator = _enumerator.CloneWithThenRestriction(thenNumber);
            return new FromThenEnumerable<T>(enumerator);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _enumerator.Clone();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}