using System;

namespace Endless
{
    internal class DynamicFromStepToEnumerator<T> : BaseFromStepToEnumerator<T>
    {
        public DynamicFromStepToEnumerator(T from, Func<T, T> step = null, T then = default(T), T to = default(T), bool hasThenRestriction = false, bool hasToRestriction = false)
            : base(from, step, then, to, hasThenRestriction, hasToRestriction)
        {
        }

        protected override IFromStepToEnumerator<T> Construct(T from, Func<T, T> step, T then, T to, bool hasThenRestriction, bool hasToRestriction)
            => new DynamicFromStepToEnumerator<T>(from, step, then, to, hasThenRestriction, hasToRestriction);

        protected override T Add(T x, T y) => (T)((dynamic)x + (dynamic)y);
        protected override T Subtract(T x, T y) => (T)((dynamic)x - (dynamic)y);
        protected override bool EqualTo(T x, T y) => (bool)((dynamic)x == (dynamic)y);
        protected override bool LessThan(T x, T y) => (bool)((dynamic)x < (dynamic)y);
        protected override bool GreaterThan(T x, T y) => (bool)((dynamic)x > (dynamic)y);
    }
}