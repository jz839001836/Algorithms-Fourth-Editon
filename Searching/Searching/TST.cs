using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 基于三向单词查找树的符号表
    /// </summary>
    /// <typeparam name="Value"></typeparam>
    class TST<Value>
    {
        private Node<Value> root;
        private class Node<T>
        {
            public char c;                 //字符
            public Node<T> left, mid, right;  //左中右子三向单词查找树
            public T val;              //和字符串相关联的值
        }
        public Value Get(String key)
        {
            Node<Value> x = Get(root, key, 0);
            if (x == null)
                return default(Value);
            return x.val;
        }
        private Node<Value> Get(Node<Value> x,String key,int d)
        {
            if (x == null)
                return null;
            char c = key[d];
            if (c < x.c)
                return Get(x.left, key, d);
            else if (c > x.c)
                return Get(x.right, key, d);
            else if (d < key.Length - 1)
                return Get(x.mid, key, d + 1);
            else
                return x;
        }
        public void Put(String key,Value val)
        { root = Put(root, key, val, 0); }
        private Node<Value> Put(Node<Value> x,String key,Value val,int d)
        {
            char c = key[d];
            if(x==null)
            {
                x = new Node<Value>();
                x.c = c;
            }
            if (c < x.c)
                x.left = Put(x.left, key, val, d);
            else if (c > x.c)
                x.right = Put(x.right, key, val, d);
            else if (d < key.Length - 1)
                x.mid = Put(x.mid, key, val, d + 1);
            else x.val = val;
            return x;
        }
        public Queue<String>Keys()
        { return KeysWithPrefix(""); }
        public Queue<String> KeysWithPrefix(String pre)
        {
            Queue<String> q = new Queue<string>();
            Collect(Get(root, pre, 0), pre, q);
            return q;
        }//所有以s为前缀的键
        private void Collect(Node<Value> x, String pre, Queue<String> q)
        {
            if (x == null)
                return;
            if (x.val != null)
                q.enqueue(pre);
            if (x.left != null)
                Collect(x.left, pre, q);
            else if (x.right != null)
                Collect(x.right, pre, q);
            else
                Collect(x.mid, pre + x.c, q);
        }
        public Queue<String> KeysThatMatch(String pat)
        {
            Queue<String> q = new Queue<string>();
            Collect(root, "", pat,0, q);
            return q;
        }//所有和s匹配的键（其中“.”能够匹配任意字符
        private void Collect(Node<Value> x,String pre,String pat,int i,Queue<String> q)
        {
            if (x == null)
                return;
            char c = pat[i];
            if (c == '.' || c < x.c)
                Collect(x.left, pre, pat, i, q);
            if(c=='.'||c==x.c)
            {
                if (i == pat.Length - 1 && x.val != null)
                    q.enqueue(pre + x.c);
                if (i < pat.Length - 1)
                    Collect(x.mid, pre + x.c, pat, i + 1, q);
            }
            if (c == '.' || c > x.c)
                Collect(x.right, pre, pat, i, q);
        }
        public String LongestPrefixOf(String s)
        {
            if (s.Length == 0)
                return null;
            int length = 0;
            Node<Value> x = root;
            int i = 0;
            while(x!=null&&i<s.Length)
            {
                char c = s[i];
                if (c < x.c)
                    x = x.left;
                else if (c > x.c)
                    x = x.right;
                else
                {
                    i++;
                    if (x.val != null)
                        length = i;
                    x = x.mid;
                }
            }
            return s.Substring(0, length);
        }//s的前缀中最长的键

    }
}
