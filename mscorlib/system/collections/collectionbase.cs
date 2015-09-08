// ==++==
// 
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// 
// ==--==
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// <OWNER>[....]</OWNER>
// 

namespace System.Collections {
    using System;
    using Generic;
    using System.Diagnostics.Contracts;

    // Useful base class for typed read/write collections where items derive from object
    [Serializable]
[System.Runtime.InteropServices.ComVisible(true)]
    public abstract class CollectionBase : IList {
        ArrayList list;

        protected CollectionBase() {
            list = new ArrayList();
        }
        
        protected CollectionBase(int capacity) {
            list = new ArrayList(capacity);
        }


        protected List<object> InnerList { 
            get { 
                if (list == null)
                    list = new ArrayList();
                return list;
            }
        }

        protected IList List {
            get { return (IList)this; }
        }

        [System.Runtime.InteropServices.ComVisible(false)]        
        public int Capacity {
            get {
                return InnerList.Capacity;
            }
            set {
                InnerList.Capacity = value;
            }
        }


        public int Count {
            get {
                return list == null ? 0 : list.Count;
            }
        }

        public void Clear() {
            OnClear();
            InnerList.Clear();
            OnClearComplete();
        }

        public void RemoveAt(int index) {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException("index", Environment_.GetResourceString("ArgumentOutOfRange_Index"));
            Contract.EndContractBlock();
            Object temp = InnerList[index];
            OnValidate(temp);
            OnRemove(index, temp);
            InnerList.RemoveAt(index);
            try {
                OnRemoveComplete(index, temp);
            }
            catch {
                InnerList.Insert(index, temp);
                throw;
            }

        }

        bool IList.IsReadOnly {
            get { return false; }
        }

        bool IList.IsFixedSize {
            get { return false; }
        }

        bool ICollection.IsSynchronized {
            get { return false; }
        }

        Object ICollection.SyncRoot {
            get { throw new NotSupportedException(); }
        }

        void ICollection.CopyTo(Array array, int index) {
            InnerList.CopyTo((object[])array, index);
        }

        Object IList.this[int index] {
            get { 
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index", Environment_.GetResourceString("ArgumentOutOfRange_Index"));
                Contract.EndContractBlock();
                return InnerList[index]; 
            }
            set { 
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index", Environment_.GetResourceString("ArgumentOutOfRange_Index"));
                Contract.EndContractBlock();
                OnValidate(value);
                Object temp = InnerList[index];
                OnSet(index, temp, value); 
                InnerList[index] = value; 
                try {
                    OnSetComplete(index, temp, value);
                }
                catch {
                    InnerList[index] = temp; 
                    throw;
                }
            }
        }

        bool IList.Contains(Object value) {
            return InnerList.Contains(value);
        }

        int IList.Add(Object value) {
            OnValidate(value);
            OnInsert(InnerList.Count, value);
            InnerList.Add(value);
            var index = InnerList.Count - 1;
            try {
                OnInsertComplete(index, value);
            }
            catch {
                InnerList.RemoveAt(index);
                throw;
            }
            return index;
        }

       
        void IList.Remove(Object value) {
            OnValidate(value);
            int index = InnerList.IndexOf(value);
            if (index < 0) throw new ArgumentException(Environment_.GetResourceString("Arg_RemoveArgNotFound"));
            OnRemove(index, value);
            InnerList.RemoveAt(index);
            try{
                OnRemoveComplete(index, value);
            }
            catch {
                InnerList.Insert(index, value);
                throw;
            }
        }

        int IList.IndexOf(Object value) {
            return InnerList.IndexOf(value);
        }

        void IList.Insert(int index, Object value) {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException("index", Environment_.GetResourceString("ArgumentOutOfRange_Index"));
            Contract.EndContractBlock();
            OnValidate(value);
            OnInsert(index, value);
            InnerList.Insert(index, value);
            try {
                OnInsertComplete(index, value);
            }
            catch {
                InnerList.RemoveAt(index);
                throw;
            }
        }

        public IEnumerator GetEnumerator() {
            return InnerList.GetEnumerator();
        }

        protected virtual void OnSet(int index, Object oldValue, Object newValue) { 
        }

        protected virtual void OnInsert(int index, Object value) { 
        }

        protected virtual void OnClear() { 
        }

        protected virtual void OnRemove(int index, Object value) { 
        }

        protected virtual void OnValidate(Object value) { 
            if (value == null) throw new ArgumentNullException("value");
            Contract.EndContractBlock();
        }

        protected virtual void OnSetComplete(int index, Object oldValue, Object newValue) { 
        }

        protected virtual void OnInsertComplete(int index, Object value) { 
        }

        protected virtual void OnClearComplete() { 
        }

        protected virtual void OnRemoveComplete(int index, Object value) { 
        }
    
    }

}
