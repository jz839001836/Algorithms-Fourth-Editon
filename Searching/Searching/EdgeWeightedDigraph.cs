using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 加权有向图的数据类型(生成加权有向图)
    /// </summary>
    class EdgeWeightedDigraph
    {
        private readonly int V;           //顶点总数
        private int E;                    //边的总数
        private Bag<DirectedEdge>[] adj;  //邻接表
        public EdgeWeightedDigraph(int V)
        {
            this.V = V;
            this.E = 0;
            adj = new Bag<DirectedEdge>[V];
            for (int v = 0; v < V; v++)
                adj[v] = new Bag<DirectedEdge>();
        }
        public int VNumber()
        { return V; }
        public int ENumber()
        { return E; }
        public void AddEdge(DirectedEdge e)
        {
            adj[e.From()].Add(e); //只有起点才添加有向边
            E++;
        }
        public Bag<DirectedEdge> Adj(int v)
        { return adj[v]; }  //从V指出的边
        public Bag<DirectedEdge> Edges()
        {
            Bag<DirectedEdge> bag = new Bag<DirectedEdge>();
            for (int v = 0; v < V; v++)
                foreach (DirectedEdge e in adj[v])
                    bag.Add(e);
            return bag;
        }//该有向图中的所有边
        public override String ToString()
        {
            StringBuilder s = new StringBuilder();
            for(int v=0;v<V;v++)
            {
                s.Append(v + ": ");
                foreach (DirectedEdge e in adj[v])
                    s.Append(e + " ");
                s.AppendLine();
            }
            return s.ToString();
        }
    }
}
