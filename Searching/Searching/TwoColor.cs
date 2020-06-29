using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// G是二分图吗？（双色问题）
    /// </summary>
    class TwoColor
    {
        private bool[] marked;
        private bool[] color;
        private bool isTwoColorable = true;
        public TwoColor(Graph G)
        {
            marked = new bool[G.VNumber()];
            color = new bool[G.VNumber()];
            for (int s = 0; s < G.VNumber(); s++)
                if (!marked[s])
                    Dfs(G, s);
        }
        private void Dfs(Graph G,int v)
        {
            marked[v] = true;
            foreach(int w in G.Adj(v))
            {
                if (!marked[w])
                {
                    color[w] = !color[v];
                    Dfs(G, w);
                }
                else if (color[w] == color[v]) isTwoColorable = false;
            }
        }
        public bool IsBipartite()
        { return isTwoColorable; }
    }
}
