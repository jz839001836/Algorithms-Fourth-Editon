using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 使用深度优先搜索查找图中的路径
    /// </summary>
    class DepthFirstPaths
    {
        private bool[] marked;
        private int[] edgeTo;//从起点到一个顶点的已知路径上的最后一个顶点 
        private readonly int s;
        public DepthFirstPaths(Graph G,int s)
        {
            marked = new bool[G.VNumber()];
            edgeTo = new int[G.VNumber()];
            this.s = s;
            Dfs(G, s);
        }
        private void Dfs(Graph G,int v)//搜索路径
        {
            marked[v] = true;
            foreach(int w in G.Adj(v))
            {
                if(!marked[w])
                {
                    edgeTo[w] = v;//即w点的上一个顶点为v
                    Dfs(G, w);
                }
            }
        }
        public bool HasPathTo(int v)
        { return marked[v]; }
        public Stack<int> PathTo(int v)
        {
            if (!HasPathTo(v)) return null;
            Stack<int> path = new Stack<int>();
            for(int x=v;x!=s;x=edgeTo[x])
            {
                path.Push(x);
            }
            return path;
        }
    }
}
