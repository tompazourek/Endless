using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace Endless.Func
{
    public static class Identity<T>
    {
        public static Func<T, T> Func
        {
            get { return x => x; }
        }
    }
}