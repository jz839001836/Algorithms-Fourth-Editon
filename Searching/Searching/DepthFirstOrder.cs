using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 有向图中基于深度优先搜索的顶点排序
    /// </summary>
    class DepthFirstOrder
    {
        private bool[] marked;
        private Queue<int> pre;        //所有顶点的前序排列
        private Queue<int> post;       //所有顶点的后序排列
        private Stack<int> reversePost;//所有顶点的逆后序排列
        public DepthFirstOrder(Digraph G)
        {
            pre = new Queue<int>();
            post = new Queue<int>();
            reversePost = new Stack<int>();
            marked = new bool[G.VNumber()];
            for (int v = 0; v < G.VNumber(); v++)
                if (!marked[v])
                    Dfs(G, v);
        }
        public DepthFirstOrder(EdgeWeightedDigraph G)
        {
            pre = new Queue<int>();
            post = new Queue<int>();
            reversePost = new Stack<int>();
            marked = new bool[G.VNumber()];
            for (int v = 0; v < G.VNumber(); v++)
                if (!marked[v])
                    Dfs(G, v);
        }
        private void Dfs(Digraph G,int v)
        {
            pre.enqueue(v);
            marked[v] = true;
            foreach(int w in G.Adj(v))
            {
                if (!marked[w])
                    Dfs(G, w);
            }
            post.enqueue(v);
            reversePost.Push(v);
        }
        private void Dfs(EdgeWeightedDigraph G, int v)
        {
            pre.enqueue(v);
            marked[v] = true;
            foreach (DirectedEdge w in G.Adj(v))
            {
                if (!marked[w.To()])
                    Dfs(G, w.To());
            }
            post.enqueue(v);
            reversePost.Push(v);
        }
        public Queue<int> Pre()
        { return pre; }
        public Queue<int> Post()
        { return post; }
        public Stack<int> ReversePost()
        { return reversePost; }
    }
}
