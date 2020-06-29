using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 基于红黑树的符号表
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    class ST<Key,Value>where Key:IComparable<Key>
    {
        private RedBlackBST<Key, Value> st;
        public ST()
        { st = new RedBlackBST<Key, Value>(); }
        public Value Get(Key key)
        { return st.Get(key); }
        public void Put(Key key,Value val)
        {
            if (val == null)
                st.Delete(key);
            else
                st.Put(key, val);
        }
        public void Delete(Key key)
        { st.Delete(key); }
        public bool Contains(Key key)
        {
            return st.Contains(key);
        }
        public int Size()
        { return st.Size(); }
        public bool IsEmpty()
        { return Size() == 0; }
        public Queue<Key> Keys()
        { return st.Keys(); }
        public Key Min()
        { return st.Min(); }
        public Key Max()
        { return st.Max(); }
        public Key Ceiling(Key key)
        { return st.Ceiling(key); }
        public Key Floor(Key key)
        { return st.Floor(key); }
    }
}
