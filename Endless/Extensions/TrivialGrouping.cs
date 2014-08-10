using System.Collections;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace Endless
{
    internal class TrivialGrouping<TKey, TSource> : IGrouping<TKey, TSource>
    {
        public TKey Key { get; private set; }
        public IList<TSource> Items { get; private set; }

        public TrivialGrouping(TKey key, IList<TSource> items)
        {
            Key = key;
            Items = items;
        }

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