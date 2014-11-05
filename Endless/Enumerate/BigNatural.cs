#region License

// Copyright (C) Tom� Pa�ourek, 2014
// All rights reserved.
// 
// Distributed under MIT license as a part of project Endless.
// https://github.com/tompazourek/Endless

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Endless
{
    /// <summary>
    /// Natural numbers
    /// </summary>
    public static class BigNatural
    {
        /// <summary>
        /// Sequence of natural numbers with zero (0, 1, 2, 3, ...)
        /// </summary>
        public static IFromEnumerable<BigInteger> NumbersWithZero
        {
            get { return Enumerate.From(new BigInteger(0)); }
        }

        /// <summary>
        /// Sequence of natural numbers (1, 2, 3, ...)
        /// </summary>
        public static IFromEnumerable<BigInteger> Numbers
        {
            get { return Enumerate.From(new BigInteger(1)); }
        }
    }
}