using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 加权无向图数据类型
    /// </summary>
    class EdgeWeightedGraph
    {
        private readonly int V;    //顶点总数
        private int E;             //边的总数      
        private Bag<Edge>[] adj;   //邻接表
        public EdgeWeightedGraph(int V)
        {
            this.V = V;
            this.E = 0;
            adj = new Bag<Edge>[V];
            for (int v = 0; v < V; v++)
                adj[v] = new Bag<Edge>();
        }
        public int VNumber
        {
            get { return V; }
        }
        public int ENumber
        {
            get { return E; }
        }
        public void AddEdge(Edge e)
        {
            int v = e.Either;
            int w = e.Other(v);
            adj[v].Add(e);
            adj[w].Add(e);
            E++;
        }
        public Bag<Edge> Adj(int v)
        { return adj[v]; }//返回v点的邻接边
        public Bag<Edge> Edges()
        {
            Bag<Edge> b = new Bag<Edge>();
            for(int v=0;v<V;v++)
                foreach(Edge e in adj[v])
                {
                    if (e.Other(v) > v)
                        b.Add(e);
                }
            return b;
        }//返回加权无向图的所有边
        public override String ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(V + " " + E);
            s.AppendLine();
            for(int v=0;v<V;v++)
            {
                s.Append(v + ": ");
                foreach(Edge e in adj[v])
                {
                    s.Append(e + " ");
                }
                s.AppendLine();
            }
            return s.ToString();
        }
    }
}
