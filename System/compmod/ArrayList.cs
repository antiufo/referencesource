using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections
{
    internal class ArrayList : List<object>
    {
        internal bool IsFixedSize
        {
            get { return false; }
        }

        internal bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public ArrayList()
        {
        }

        public ArrayList(int capacity) : base(capacity)
        {
        }

        public new int Add(object item)
        {
            base.Add(item);
            return this.Count - 1;
        }
    }
}
