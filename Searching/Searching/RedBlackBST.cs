using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 红黑树
    /// </summary>
    /// <typeparam name="Key">键</typeparam>
    /// <typeparam name="Value">值</typeparam>
    class RedBlackBST<Key, Value> where Key : IComparable<Key>
    {
        private Node root;
        private const bool RED = true;
        private const bool BLACK = false;
        private class Node
        {
            public Key key;         //键
            public Value val;       //相关联的值
            public Node left, right;//左右子树
            public int n;           //这棵子树中的结点总数
            public bool color;      //由其父结点指向它的链接的颜色
            public Node(Key key, Value val, int n, bool color)
            {
                this.key = key;
                this.val = val;
                this.n = n;
                this.color = color;
            }
        }
        private bool IsRed(Node x)
        {
            if (x == null) return false;
            return x.color == RED;
        }
        public bool IsEmpty()
        { return root == null; }
        public int Size()
        { return Size(root); }
        private int Size(Node x)
        {
            if (x == null)
                return 0;
            else
                return x.n;
        }
        public bool Contains(Key key)
        { return Get(key) != null; }//是否包含这个键
        private Node RotateLeft(Node h)
        {
            Node x = h.right;
            h.right = x.left;
            x.left = h;
            x.color = h.color;
            h.color = RED;
            x.n = h.n;
            h.n = 1 + Size(h.left) + Size(h.right);
            return x;
        }//左旋转h的右链接
        private Node RotateRight(Node h)
        {
            Node x = h.left;
            h.left = x.right;
            x.right = h;
            x.color = h.color;
            h.color = RED;
            x.n = h.n;
            h.n = 1 + Size(h.left) + Size(h.right);
            return x;
        }//右旋转h的左链接
        private void FlipColors(Node h)
        {
            h.color = !h.color;
            h.left.color = !h.left.color;
            h.right.color = !h.right.color;
        }//将一个结点的两个红色子结点转换成黑色
        public void Put(Key key, Value val)
        {
            root = Put(root, key, val);
            root.color = BLACK;
        }//查找key，找到则更新其值，否则为他创建一个结点
        private Node Put(Node h, Key key, Value val)
        {
            if (h == null)
                return new Node(key, val, 1, RED);
            int cmp = key.CompareTo(h.key);
            if (cmp < 0)
                h.left = Put(h.left, key, val);
            else if (cmp > 0)
                h.right = Put(h.right, key, val);
            else
                h.val = val;
            if (IsRed(h.right) && !IsRed(h.left)) h = RotateLeft(h);
            if (IsRed(h.left) && IsRed(h.left.left)) h = RotateRight(h);
            if (IsRed(h.left) && IsRed(h.right)) FlipColors(h);
            h.n = Size(h.left) + Size(h.right) + 1;
            return h;
        }
        public Value Get(Key key)
        { return Get(root, key); }//在以x为根节点的子树中查找并返回key所对应的值，如果找不到则返回null
        private Value Get(Node x, Key key)
        {
            if (x == null) return default(Value);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
                return Get(x.left, key);
            else if (cmp > 0)
                return Get(x.right, key);
            else
                return x.val;
        }
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
        public Key Select(int k)
        { return Select(root, k).key; }//返回排名为k的键
        private Node Select(Node x, int k)
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
        { return Rank(key, root); }
        private int Rank(Key key, Node x)
        {
            if (x == null)
                return 0;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
                return Rank(key, x.left);
            else if (cmp > 0)
                return 1 + Size(x.left) + Rank(key, x.right);
            else
                return Size(x.left);
        }//返回以x为根结点的子树中小于x.key的键的数量
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
        public Queue<Key> Keys()
        { return Keys(Min(), Max()); }//表中所有键的集合
        private Queue<Key> Keys(Key lo, Key hi)
        {
            Queue<Key> queue = new Queue<Key>();
            Keys(root, queue, lo, hi);
            return queue;
        }
        private void Keys(Node x, Queue<Key> queue, Key lo, Key hi)
        {
            if (x == null) return;
            int cmplo = lo.CompareTo(x.key);
            int cmphi = hi.CompareTo(x.key);
            if (cmplo < 0) Keys(x.left, queue, lo, hi);
            if (cmplo <= 0 && cmphi >= 0) queue.enqueue(x.key);
            if (cmphi > 0) Keys(x.right, queue, lo, hi);
        }
        public void Print()
        { Print(root); }//顺序打印红黑树
        private void Print(Node x)
        {
            if (x == null) return;
            Print(x.left);
            Console.Write(x.key);
            Print(x.right);
        }//顺序遍历
        public bool Is23()
        { return Is23(root); }//检查是否存在同时和两条红链接相连的结点和红色右链接
        private bool Is23(Node x)
        {
            if (x == null)
                return true;
            if (IsRed(x.right))
                return false;
            if (x != root && IsRed(x) && IsRed(x.left))
                return false;
            return Is23(x.left) && Is23(x.right);
        }
        public bool IsBalanced()
        {
            int black = 0;
            Node x = root;
            while (x != null)
            {
                if (!IsRed(x))
                    black++;
                x = x.left;
            }
            return IsBalanced(root, black);
        }//检查从根节点到所有空链接的路径上的黑链接的数量是否相等
        private bool IsBalanced(Node x, int black)
        {
            if (x == null) return black == 0;
            if (!IsRed(x))
                black--;
            return IsBalanced(x.left, black) && IsBalanced(x.right, black);
        }
        private bool IsBST(Node x, Key min, Key max)
        {
            if (x == null) return true;
            if (min != null && x.key.CompareTo(min) <= 0) return false;
            if (max != null && x.key.CompareTo(max) >= 0) return false;
            return IsBST(x.left, min, x.key) && IsBST(x.right, x.key, max);
        }
        private Node Balance(Node h)
        {
            if (IsRed(h.right)) h = RotateLeft(h);
            if (IsRed(h.left) && IsRed(h.left.left)) h = RotateRight(h);
            if (IsRed(h.left) && IsRed(h.right)) FlipColors(h);
            h.n = Size(h.left) + Size(h.right) + 1;
            return h;
        }//向上分解临时的4-结点
        private Node MoveRedLeft(Node h)
        {
            FlipColors(h);
            if(IsRed(h.right.left))
            {
                h.right = RotateRight(h.right);
                h = RotateLeft(h);
                FlipColors(h);
            }
            return h;
        }//将2-结点转换为3-结点
        public void DeleteMin()
        {
            if (!IsRed(root.left) && !IsRed(root.right))
                root.color = RED;//在后续使用FlipColors()后保证根节点为黑结点
            root = DeleteMin(root);
            if (!IsEmpty()) root.color = BLACK;
        }
        private Node DeleteMin(Node h)
        {
            if (h.left == null)
                return null;
            if (!IsRed(h.left) && !IsRed(h.left.left))
                h = MoveRedLeft(h);
            h.left = DeleteMin(h.left);
            return Balance(h);
        }
        private Node MoveRedRight(Node h)
        {
            FlipColors(h);
            if(IsRed(h.left.left))
            {
                h = RotateRight(h);
                FlipColors(h);
            }
            return h;
        }
        public void DeleteMax()
        {
            if (!IsRed(root.left) && IsRed(root.right))
                root.color = RED;
            root = DeleteMax(root);
            if (!IsEmpty()) root.color = BLACK;
        }
        private Node DeleteMax(Node h)
        {
            if (IsRed(h.left))
                h = RotateRight(h);
            if (h.right == null)
                return null;
            if (!IsRed(h.right) && !IsRed(h.right.left))
                h = MoveRedRight(h);
            h.right = DeleteMax(h.right);
            return Balance(h);
        }//将大的值放到结点右侧
        public void Delete(Key key)
        {
            if (!IsRed(root.left) && !IsRed(root.right))
                root.color = RED;
            root = Delete(root, key);
            if (!IsEmpty()) root.color = BLACK;
        }
        private Node Delete(Node h,Key key)
        {
            if (key.CompareTo(h.key) < 0)
            {
                if (!IsRed(h.left) && !IsRed(h.left.left))
                    h = MoveRedLeft(h);
                h.left = Delete(h.left, key);
            }
            else
            {
                if (IsRed(h.left))
                    h = RotateRight(h);
                if (key.CompareTo(h.key) == 0 && h.right == null)
                    return null;
                if (!IsRed(h.right) && !IsRed(h.right.left))
                    h = MoveRedRight(h);
                if (key.CompareTo(h.key) == 0)
                {
                    h.val = Get(h.right, Min(h.right).key);
                    h.key = Min(h.right).key;
                    h.right = DeleteMin(h.right);
                }
                else h.right = Delete(h.right, key);
            }
            return Balance(h);
        }
    }
}
