using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace Endless.Func
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