using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 有向图的传递闭包
    /// </summary>
    class TransitiveClosure
    {
        private DirectedDFS[] all;
        TransitiveClosure(Digraph G)
        {
            all = new DirectedDFS[G.VNumber()];
            for (int v = 0; v < G.VNumber(); v++)
                all[v] = new DirectedDFS(G, v);
        }
       public bool Reachable(int v,int w)
        { return all[v].Marked(w); }
    }
}
