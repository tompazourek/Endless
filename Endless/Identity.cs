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
    /// Static class containing identity function
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Identity<T>
    {
        /// <summary>
        /// Generic identity function
        /// </summary>
        public static Func<T, T> Func
        {
            get { return x => x; }
        }
    }
}