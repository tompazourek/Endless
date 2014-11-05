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
    public interface IFromThenEnumerable<T> : IEnumerable<T>
    {
        /// <summary>
        /// Bounds the collection of numbers from the right.
        /// </summary>
        /// <returns>(n0, ..., m)</returns>
        IEnumerable<T> To(T toNumber);
    }
}