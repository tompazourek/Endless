﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    public static class Natural
    {
        public static IEnumerable<int> NumbersWithZero
        {
            get { return Enumerate.From(0); }
        }

        public static IEnumerable<int> Numbers
        {
            get { return Enumerate.From(1); }
        }
    }
}
