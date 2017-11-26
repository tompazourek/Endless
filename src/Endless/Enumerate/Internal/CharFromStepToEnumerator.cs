using System;

namespace Endless
{
    internal class CharFromStepToEnumerator : BaseFromStepToEnumerator<char>
    {
        public CharFromStepToEnumerator(char from, Func<char, char> step = null, char then = default(char), char to = default(char), bool hasThenRestriction = false, bool hasToRestriction = false)
            : base(from, step, then, to, hasThenRestriction, hasToRestriction)
        {
        }

        protected override IFromStepToEnumerator<char> Construct(char from, Func<char, char> step, char then, char to, bool hasThenRestriction, bool hasToRestriction)
            => new CharFromStepToEnumerator(from, step, then, to, hasThenRestriction, hasToRestriction);

        protected override char Add(char x, char y)
        {
            unchecked
            {
                return (char)(x + y);
            }
        }

        protected override char Subtract(char x, char y)
        {
            unchecked
            {
                return (char)(x - y);
            }
        }

        protected override bool EqualTo(char x, char y) => x == y;
        protected override bool LessThan(char x, char y) => x < y;
        protected override bool GreaterThan(char x, char y) => x > y;
    }
}