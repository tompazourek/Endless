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
    /// Enumerable that uses internal cache.
    /// </summary>
    /// <remarks>Note that it is disposable, since the enumerator obtained from the source must be correctly disposed.</remarks>
    /// <typeparam name="T"></typeparam>
    public interface ICachedEnumerable<out T> : IEnumerable<T>, IDisposable
    {
    }
}