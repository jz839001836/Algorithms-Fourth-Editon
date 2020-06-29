using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 寻找有向环（通过深度优先搜索实现）
    /// </summary>
    class DirectedCycle
    {
        private bool[] marked;
        private int[] edgeTo;  
        private Stack<int> cycle;  //有向环中的所有顶点（如果存在）
        private bool[] onStack;    //用于保存递归调用栈上的所有顶点
        public DirectedCycle(Digraph G)
        {
            onStack = new bool[G.VNumber()];
            edgeTo = new int[G.VNumber()];
            marked = new bool[G.VNumber()];
            for (int v = 0; v < G.VNumber(); v++)
                if (!marked[v]) Dfs(G, v);
        }
        public DirectedCycle(EdgeWeightedDigraph G)
        {
            onStack = new bool[G.VNumber()];
            edgeTo = new int[G.VNumber()];
            marked = new bool[G.VNumber()];
            for (int v = 0; v < G.VNumber(); v++)
                if (!marked[v]) Dfs(G, v);
        }
        private void Dfs(Digraph G,int v)//寻找相连的顶点
        {
            onStack[v] = true;
            marked[v] = true;
            foreach(int w in G.Adj(v))
            {
                if (this.HasCycle()) return;
                else if(!marked[w])
                {
                    edgeTo[w] = v;//存储最先到达w点的v点
                    Dfs(G, w);
                }
                else if(onStack[w])
                {
                    cycle = new Stack<int>();
                    for (int x = v; x != w; x = edgeTo[x])
                        cycle.Push(x);
                    cycle.Push(w);
                    cycle.Push(v);
                }
            }
            onStack[v] = false;
        }
        private void Dfs(EdgeWeightedDigraph G, int v)//(加权有向图)寻找相连的顶点
        {
            onStack[v] = true;
            marked[v] = true;
            foreach (DirectedEdge w in G.Adj(v))
            {
                if (this.HasCycle()) return;
                else if (!marked[w.To()])
                {
                    edgeTo[w.To()] = v;//存储最先到达w.To()点的v点
                    Dfs(G, w.To());
                }
                else if (onStack[w.To()])
                {
                    cycle = new Stack<int>();
                    for (int x = v; x != w.To(); x = edgeTo[x])
                        cycle.Push(x);
                    cycle.Push(w.To());
                    cycle.Push(v);
                }
            }
            onStack[v] = false;
        }
        public bool HasCycle()//有-true，没有-false
        { return cycle != null; }
        public Stack<int> Cycle()
        { return cycle; }
    }
}
