using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections
{
    internal class Hashtable : Dictionary<string, object>
    {
        public Hashtable() { }
        public Hashtable(IEqualityComparer<string> comparer) : base(comparer)
        {
        }
    }
}
