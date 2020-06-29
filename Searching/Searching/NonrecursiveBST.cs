using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    class NonrecursiveBST<Key,Value>where Key:IComparable<Key>
    {
        private Node root;
        private class Node
        {
            public Key key;
            public Value val;
            public Node left, right;
            public Node(Key key,Value val)
            {
                this.key = key;
                this.val = val;
            }
        }
        public void Put(Key key,Value val)
        {
            Node z = new Node(key, val);
            if (root == null)
            {
                root = z;
                return;
            }
            Node parent = null, x = root;
            while(x!=null)
            {
                parent = x;
                int cmp = key.CompareTo(x.key);
                if (cmp < 0) x = x.left;
                else if (cmp > 0) x = x.right;
                else
                {
                    x.val = val;
                    return;
                }
            }
            int cmp1 = key.CompareTo(x.key);
            if (cmp1 < 0)
                parent.left = z;
            else
                parent.right = z;
        }
        public Value Get(Key key)
        {
            Node x = root;
            while(x!=null)
            {
                int cmp = key.CompareTo(x.key);
                if (cmp < 0) x = x.left;
                else if (cmp > 0) x = x.right;
                else return x.val;
            }
            return default(Value);
        }
    }
}
