using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 有向图（生成一个有向图）
    /// </summary>
    class Digraph
    {
        private readonly int V;
        private int E;         //与起点相连的所有顶点的数量
        public Bag<int>[] adj;//存储该点可以到达的顶点包（以链表实现）
        public Digraph(int V)
        { 
            this.V = V;
            this.E = 0;
            adj = new Bag<int>[V];
            for (int i = 0; i < V; i++)
                adj[i] = new Bag<int>();
        }
        public int VNumber()
        { return V; }
        public int ENumber()
        { return E; }
        public void AddEdge(int v,int w)
        {
            adj[v].Add(w);
            E++;
        }//向v包中添加w，指的是添加有个v->w的有向线段
        public Bag<int> Adj(int v)  
        { return adj[v]; }//返回v点可以达到的顶点包
        public Digraph Reverse()
        {
            Digraph R = new Digraph(V);
            for (int v = 0; v < V; v++)
                foreach (int w in Adj(v))
                    R.AddEdge(w, v);
            return R;
        }//有向图取反
        public override string ToString()
        {
            string s = V + " vertices, " + E + " edge\n";
            for(int v=0;v<V;v++)
            {
                s += v + ": ";
                foreach (int w in this.Adj(v))
                    s += w + " ";
                s += "\n";
            }
            return s;
        }
    }
}
