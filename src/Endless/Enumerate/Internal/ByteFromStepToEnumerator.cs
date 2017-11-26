using System;

namespace Endless
{
    internal class ByteFromStepToEnumerator : BaseFromStepToEnumerator<byte>
    {
        public ByteFromStepToEnumerator(byte from, Func<byte, byte> step = null, byte then = default(byte), byte to = default(byte), bool hasThenRestriction = false, bool hasToRestriction = false)
            : base(from, step, then, to, hasThenRestriction, hasToRestriction)
        {
        }

        protected override IFromStepToEnumerator<byte> Construct(byte from, Func<byte, byte> step, byte then, byte to, bool hasThenRestriction, bool hasToRestriction)
            => new ByteFromStepToEnumerator(from, step, then, to, hasThenRestriction, hasToRestriction);

        protected override byte Add(byte x, byte y)
        {
            unchecked
            {
                return (byte)(x + y);
            }
        }

        protected override byte Subtract(byte x, byte y)
        {
            unchecked
            {
                return (byte)(x - y);
            }
        }

        protected override bool EqualTo(byte x, byte y) => x == y;
        protected override bool LessThan(byte x, byte y) => x < y;
        protected override bool GreaterThan(byte x, byte y) => x > y;
    }
}