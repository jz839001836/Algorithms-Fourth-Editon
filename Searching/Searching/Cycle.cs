using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 检测环，G是无环图吗？（假设不存在自环或者平行边）
    /// </summary>
    class Cycle
    {
        private bool[] marked;
        private bool hasCycle;
        public Cycle(Graph G)
        {
            marked = new bool[G.VNumber()];
            for (int s = 0; s < G.VNumber(); s++)
                if (!marked[s])
                    Dfs(G, s, s);
        }
        private void Dfs(Graph G,int v,int u)
        {
            marked[v] = true;
            foreach(int w in G.Adj(v))
            {
                if (!marked[w])
                    Dfs(G, w, v);
                else if (w != u) hasCycle = true;
            }
        }
        public bool HasCycle()
        { return hasCycle; }
    }
}
