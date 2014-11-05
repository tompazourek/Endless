#region License

// Copyright (C) Tomáš Pažourek, 2014
// All rights reserved.
// 
// Distributed under MIT license as a part of project Endless.
// https://github.com/tompazourek/Endless

#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Endless
{
    internal class TrivialGrouping<TKey, TSource> : IGrouping<TKey, TSource>
    {
        public TrivialGrouping(TKey key, IList<TSource> items)
        {
            Key = key;
            Items = items;
        }

        public IList<TSource> Items { get; private set; }
        public TKey Key { get; private set; }

        public IEnumerator<TSource> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}