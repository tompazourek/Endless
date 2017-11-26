using System;

namespace Endless
{
    internal class DoubleFromStepToEnumerator : BaseFromStepToEnumerator<double>
    {
        public DoubleFromStepToEnumerator(double from, Func<double, double> step = null, double then = default(double), double to = default(double), bool hasThenRestriction = false, bool hasToRestriction = false)
            : base(from, step, then, to, hasThenRestriction, hasToRestriction)
        {
        }

        protected override IFromStepToEnumerator<double> Construct(double from, Func<double, double> step, double then, double to, bool hasThenRestriction, bool hasToRestriction)
            => new DoubleFromStepToEnumerator(from, step, then, to, hasThenRestriction, hasToRestriction);

        protected override double Add(double x, double y) => x + y;
        protected override double Subtract(double x, double y) => x - y;

        // ReSharper disable once CompareOfFloatsByEqualityOperator
        protected override bool EqualTo(double x, double y) => x == y;

        protected override bool LessThan(double x, double y) => x < y;
        protected override bool GreaterThan(double x, double y) => x > y;
    }
}