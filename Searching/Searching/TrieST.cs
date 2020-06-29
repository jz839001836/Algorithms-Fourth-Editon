using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 基于R向单词查找树的符号表
    /// </summary>
    /// <typeparam name="Value">值</typeparam>
    class TrieST<Value>
    {
        private static int R = 256;  //基数
        private Node root;           //单词查找树的根结点
        private class Node
        {
            public Value val;
            public Node[] next = new Node[R];
        }
        public Value Get(String key)
        {
            Node x = Get(root, key, 0);
            if (x == null)
                return default(Value);
            return x.val;
        }
        private Node Get(Node x,String key,int d)
        {  //返回以x作为根节点的子单词查找树中于key相关联的值
            if (x == null)
                return null;
            if (d == key.Length)
                return x;
            char c = key[d];   //找到第d个字符所对应的子单词查找树
            return Get(x.next[c], key, d + 1);
        }
        public void Put(String key,Value val)
        {
            root = Put(root, key, val, 0);
        }
        private Node Put(Node x,String key,Value val,int d)
        {  //如果key存在于x为根节点的子单词查找树中则更新与它相关联的值
            if (x == null)
                x = new Node();
            if(d==key.Length)
            {
                x.val = val;
                return x;
            }
            char c = key[d];    //找到第d个字符所对应的子单词查找树
            x.next[c] = Put(x.next[c], key, val, d + 1);
            return x;
        }
        public int Size()
        { return Size(root); }
        private int Size(Node x)
        { //单词查找树的延时递归方法
            if (x == null)
                return 0;
            int cnt = 0;
            if (x.val != null)
                cnt++;
            for (char c = (char)0; c < R; c++)
                cnt += Size(x.next[c]);
            return cnt;
        }
        public Queue<String> Keys()
        { //符号表中的所有键
            return KeysWithPrefix("");
        }
        public Queue<String> KeysWithPrefix(String pre)
        { //所有以s为前缀的键
            Queue<String> q = new Queue<String>();
            Collect(Get(root, pre, 0), pre, q);
            return q;
        }
        private void Collect(Node x, String pre, Queue<String> q)
        {
            if (x == null)
                return;
            if (x.val != null)
                q.enqueue(pre);
            for (char c = (char)0; c < R; c++)
                Collect(x.next[c], pre + c, q);
        }
        public Queue<String> KeysThatMatch(String pat)
        {  //所有和s匹配的键（其中"."能够匹配任意字符）
            Queue<String> q = new Queue<string>();
            Collect(root, "", pat, q);
            return q;
        }
        private void Collect(Node x,String pre,String pat,Queue<String> q)
        { //pre:正在匹配中的字符串，pat:需要匹配的字符串
            int d = pre.Length;
            if (x == null)
                return;
            if (d == pat.Length && x.val != null)
                q.enqueue(pre);
            if (d == pat.Length)
                return;
            char next = pat[d];
            for (char c = (char)0; c < R; c++)
                if (next == '.' || next == c)
                    Collect(x.next[c], pre + c, pat, q);
        }
        public String LongestPrefixOf(String s)
        {  //对给定字符串的最长前缀进行匹配
            int length = Search(root, s, 0, 0);
            return s.Substring(0, length);
        }
        private int Search(Node x,String s,int d,int length)
        {
            if (x == null)
                return length;
            if (x.val != null)
                length = d;
            if (d == s.Length)
                return length;
            char c = s[d];
            return Search(x.next[c], s, d + 1, length);
        }
        public void Delete(String key)
        { root = Delete(root, key, 0); }
        private Node Delete(Node x,String key,int d)
        { //从单词查找树中删除一个键
            if (x == null)
                return null;
            if (d == key.Length)
                x.val = default(Value);
            else
            {
                char c = key[d];
                x.next[c] = Delete(x.next[c], key, d + 1);
            }
            if (x.val != null)
                return x;
            for (char c = (char)0; c < R; c++)
                if (x.next[c] != null)
                    return x;
            return null;
        }
    }
}
