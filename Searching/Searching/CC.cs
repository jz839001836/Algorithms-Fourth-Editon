using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 使用深度优先搜索找出图中的所有连通分量
    /// </summary>
    class CC
    {
        private bool[] marked;
        private int[] id;
        private int count;
        public CC(Graph G)
        {
            marked = new bool[G.VNumber()];
            id = new int[G.VNumber()];
            for(int s=0;s<G.VNumber();s++)
            {
                if(!marked[s])
                {
                    Dfs(G, s);
                    count++;
                }
            }
        }
        private void Dfs(Graph G,int v)
        {
            marked[v] = true;
            id[v] = count;
            foreach(int w in G.Adj(v))
            {
                if (!marked[w])
                    Dfs(G, w);
            }
        }
        public bool Connected(int v,int w)
        { return id[v] == id[w]; }
        public int Id(int v)
        { return id[v]; }//v所在的连通分量的标识符（0-count()-1)
        public int Count()
        { return count; }//连通分量数
    }
}
