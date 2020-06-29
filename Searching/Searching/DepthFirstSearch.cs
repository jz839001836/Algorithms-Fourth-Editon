using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 深度优先搜索
    /// </summary>
    class DepthFirstSearch
    {
        private bool[] marked;//该顶点是否被标记
        private int count;//与顶点相连的结点数
        public DepthFirstSearch(Graph G,int s)
        {
            marked = new bool[G.VNumber()];
            Dfs(G, s);
        }
        private void Dfs(Graph G,int v)
        {
            marked[v] = true;
            count++;
            foreach(int w in G.Adj(v))
            {
                if (!marked[w])
                    Dfs(G, w);
            }
        }
        public bool Marked(int w)
        {
            return marked[w];
        }
        public int Count()
        {
            return count;
        }
    }
}
