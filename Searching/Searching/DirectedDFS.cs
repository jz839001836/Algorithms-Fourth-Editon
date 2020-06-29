using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 有向图的可达性（使用深度优先搜索）
    /// </summary>
    class DirectedDFS
    {
        private bool[] marked;
        public DirectedDFS(Digraph G,int s)
        {
            marked = new bool[G.VNumber()];
            Dfs(G, s);
        }
        public DirectedDFS(Digraph G,Bag<int> sources)
        {
            marked = new bool[G.VNumber()];
            foreach(int s in sources)
            {
                if (!marked[s])
                    Dfs(G, s);
            }
        }
        private void Dfs(Digraph G,int v)
        {
            marked[v] = true;
            foreach(int w in G.Adj(v))
            {
                if (!marked[w])
                    Dfs(G, w);
            }
        }
        public bool Marked(int v)
        { return marked[v]; }
    }
}
