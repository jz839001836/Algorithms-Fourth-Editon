using System;

namespace Searching
{
    /// <summary>
    /// 基于二叉查找树的符号表
    /// </summary>
    /// <typeparam name="Key">键</typeparam>
    /// <typeparam name="Value">值</typeparam>
    class BST<Key, Value> where Key : IComparable<Key>
    {
        private Node root;
        private class Node
        {
            public Key key;           //键
            public Value val;         //值
            public Node left, right;  //指向子树的链接
            public int n;             //以该结点为根的子树中的节点总数
            public Node(Key key, Value val, int n)
            {
                this.key = key;
                this.val = val;
                this.n = n;
            }
        }//二叉树
        public int Size()
        { return Size(root); }
        private int Size(Node x)
        {
            if (x == null)
                return 0;
            else
                return x.n;
        }
        public Value Get(Key key)
        { return Get(root, key); }
        private Value Get(Node x, Key key)
        {
            if (x == null) return default(Value);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
                return Get(x.left, key);
            else if (cmp > 0)
                return Get(x.right, key);
            else return x.val;
        }//在以x为根节点的子树中查找并返回key所对应的值，如果找不到则返回null
        public void Put(Key key, Value val)
        { root = Put(root, key, val); }//查找key，找到则更新它的值，否则为它创建一个新的节点
        private Node Put(Node x, Key key, Value val)
        {
            if (x == null) return new Node(key, val, 1);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
                x.left = Put(x.left, key, val);
            else if (cmp > 0)
                x.right = Put(x.right, key, val);
            else
                x.val = val;
            x.n = Size(x.left) + Size(x.right) + 1;
            return x;
        }//如果Key存在于以x为根节点的子树中则更新它的值；否则将以key和val的键值对的新节点插入到该子树中
        public Key Min()
        { return Min(root).key; }//查找最小键
        private Node Min(Node x)
        {
            if (x.left == null) return x;
            return Min(x.left);
        }
        public Key Max()
        { return Max(root).key; }//查找最大键
        private Node Max(Node x)
        {
            if (x.right == null) return x;
            return Max(x.right);
        }
        public Key Floor(Key key)
        {
            Node x = Floor(root, key);
            if (x == null) return default(Key);
            return x.key;
        }//小于等于key的最大键
        private Node Floor(Node x, Key key)
        {
            if (x == null)
                return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0)
                return x;
            else if (cmp < 0)
                return Floor(x.left, key);
            Node t = Floor(x.right, key);
            if (t != null)
                return t;
            else
                return x;
        }
        public Key Ceiling(Key key)
        {
            Node x = Ceiling(root, key);
            if (x == null) return default(Key);
            return x.key;
        }//大于等于key的最小键
        private Node Ceiling(Node x, Key key)
        {
            if (x == null)
                return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0)
                return x;
            if (cmp > 0)
                return Ceiling(x.right, key);
            Node t = Ceiling(x.left, key);
            if (t != null)
                return t;
            else
                return x;
        }
        public Key Select(int k)
        { return Select(root, k).key; }//排名为k的键
        private Node Select(Node x,int k)
        {
            if (x == null) return null;
            int t = Size(x.left);
            if (t > k)
                return Select(x.left, k);
            else if (t < k)
                return Select(x.right, k - t - 1);
            else
                return x;
        }
        public int Rank(Key key)
        { return Rank(root,key); }//小于Key的键的数量
        private int Rank(Node x,Key key)
        {
            if (x == null)
                return 0;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
                return Rank(x.left, key);
            else if (cmp > 0)
                return 1 + Size(x.left) + Rank(x.right, key);
            else
                return Size(x.left);
        }
        public void DeleteMin()
        { root = DeleteMin(root); }//删除最小值
        private Node DeleteMin(Node x)
        {
            if (x.left == null)
                return x.right;
            x.left = DeleteMin(x.left);
            x.n = Size(x.left) + Size(x.right) + 1;
            return x;
        }
        public void DeleteMax()
        { root = DeleteMax(root); }//删除最大值
        private Node DeleteMax(Node x)
        {
            if (x.right == null)
                return x.left;
            x.right = DeleteMax(x.right);
            x.n = Size(x.left) + Size(x.right) + 1;
            return x;
        }
        public void Delete(Key key)
        { root = Delete(root, key); }//删除特定的节点
        private Node Delete(Node x, Key key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
                x.left = Delete(x.left, key);
            else if (cmp > 0)
                x.right = Delete(x.right, key);
            else
            {
                if (x.right == null) return x.left;
                if (x.left == null) return x.right;
                Node t = x;
                x = Min(t.right);
                x.right = DeleteMin(t.right);
                x.left = t.left;
            }
            x.n = Size(x.left) + Size(x.right) + 1;
            return x;
        }
        public void Print()
        { Print(root); }//顺序打印二叉树
        private void Print(Node x)
        {
            if (x == null) return;
            Print(x.left);
            Console.Write(x.key);
            Print(x.right);
        }//顺序遍历
        public Queue<Key> Keys()
        { return Keys(Min(), Max()); }//表中所有键的集合
        private Queue<Key> Keys(Key lo,Key hi)
        {
            Queue<Key> queue = new Queue<Key>();
            Keys(root, queue, lo, hi);
            return queue;
        }
        private void Keys(Node x,Queue<Key> queue,Key lo,Key hi)
        {
            if (x == null) return;
            int cmplo = lo.CompareTo(x.key);
            int cmphi = hi.CompareTo(x.key);
            if (cmplo < 0) Keys(x.left, queue, lo, hi);
            if (cmplo <= 0 && cmphi >= 0) queue.enqueue(x.key);
            if (cmphi > 0) Keys(x.right, queue, lo, hi);
        }
        public int Height()
        {
            return Height(root);
        }
        private int Height(Node x)
        {
            if (x == null) return 0;
            if (x.left == null && x.right == null)
                return 1;
            else
                return 1 + Math.Max(Height(x.right),Height(x.left));
        }
    }
}
