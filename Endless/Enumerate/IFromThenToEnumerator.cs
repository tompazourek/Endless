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
    internal interface IFromThenToEnumerator<T> : IEnumerator<T> where T : struct
    {
        IFromThenToEnumerator<T> Clone();
        IFromThenToEnumerator<T> CloneWithThenRestriction(T then);
        IFromThenToEnumerator<T> CloneWithToRestriction(T to);
    }
}