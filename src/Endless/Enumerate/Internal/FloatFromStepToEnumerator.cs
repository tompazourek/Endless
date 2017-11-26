using System;

namespace Endless
{
    internal class FloatFromStepToEnumerator : BaseFromStepToEnumerator<float>
    {
        public FloatFromStepToEnumerator(float from, Func<float, float> step = null, float then = default(float), float to = default(float), bool hasThenRestriction = false, bool hasToRestriction = false)
            : base(from, step, then, to, hasThenRestriction, hasToRestriction)
        {
        }

        protected override IFromStepToEnumerator<float> Construct(float from, Func<float, float> step, float then, float to, bool hasThenRestriction, bool hasToRestriction)
            => new FloatFromStepToEnumerator(from, step, then, to, hasThenRestriction, hasToRestriction);

        protected override float Add(float x, float y) => x + y;
        protected override float Subtract(float x, float y) => x - y;

        // ReSharper disable once CompareOfFloatsByEqualityOperator
        protected override bool EqualTo(float x, float y) => x == y;

        protected override bool LessThan(float x, float y) => x < y;
        protected override bool GreaterThan(float x, float y) => x > y;
    }
}