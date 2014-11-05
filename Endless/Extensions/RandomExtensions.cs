#region License

// Copyright (C) Tomáš Pažourek, 2014
// All rights reserved.
// 
// Distributed under MIT license as a part of project Endless.
// https://github.com/tompazourek/Endless

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Endless
{
    /// <summary>
    /// Extensions to <see cref="Random"/>
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// Returns one random byte.
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static byte NextByte(this Random random)
        {
            if (random == null) throw new ArgumentNullException("random");
            var result = (byte) random.Next(byte.MinValue, byte.MaxValue + 1);
            return result;
        }

        /// <summary>
        /// Returns one random char.
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static char NextChar(this Random random)
        {
            if (random == null) throw new ArgumentNullException("random");
            var result = (char) random.Next(char.MinValue, char.MaxValue + 1);
            return result;
        }
    }
}