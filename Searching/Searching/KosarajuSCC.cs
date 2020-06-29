using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 计算强连通分量的KosarajuSCC算法
    /// </summary>
    class KosarajuSCC
    {
        private bool[] marked; //已访问过的点
        private int[] id;      //强连通分量的标识符
        private int count;     //强连通分量的数量
        public KosarajuSCC(Digraph G)
        {
            marked = new bool[G.VNumber()];
            id = new int[G.VNumber()];
            //第一次深度优先，得到反向有向图顶点的逆后序排列
            DepthFirstOrder order = new DepthFirstOrder(G.Reverse());
            foreach(int s in order.ReversePost())
            {
                if(!marked[s])
                {
                    Dfs(G, s);//第二次深度优先搜索，得到有向图的强连通分量
                    count++;
                }
            }
        }
        private void Dfs(Digraph G,int v)
        {
            marked[v] = true;
            id[v] = count;
            foreach(int w in G.Adj(v))
            {
                if (!marked[w])
                    Dfs(G, w);
            }
        }
        public bool StronglyConnected(int v,int w)
        { return id[v] == id[w]; }
        public int Id(int v)
        { return id[v]; }
        public int Count()
        { return count; }

    }
}
