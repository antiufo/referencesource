using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections
{
    class SortedList : System.Collections.Generic.SortedDictionary<string, string>
    {
        public SortedList(IComparer<string> comparer) : base(comparer)
        {
        }
        public SortedList() 
        {
        }

        internal bool Contains(string item)
        {
            return ContainsKey(item);
        }
    }
}
