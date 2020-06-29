using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 最短路径的Dijkstra算法
    /// </summary>
    class DijkstraSP
    {
        private DirectedEdge[] edgeTo;   //到达w点的上一条有权有向边
        private double[] distTo;         //到达w点的最短路径大小
        private IndexMinPQ<Double> pq;
        public DijkstraSP(EdgeWeightedDigraph G,int s)
        {
            edgeTo = new DirectedEdge[G.VNumber()];
            distTo = new double[G.VNumber()];
            pq = new IndexMinPQ<double>(G.VNumber());
            for(int v=0;v<G.VNumber();v++)
            {
                distTo[v] = Double.PositiveInfinity;
            }
            distTo[s] = 0.0;
            pq.Insert(s, 0.0);
            while (!pq.IsEmpty())
                Relax(G, pq.DelMin());
        }
        private void Relax(EdgeWeightedDigraph G,int v)
        {
            foreach(DirectedEdge e in G.Adj(v))
            {//  v->w   e:v和w相连的边
                int w = e.To();
                if(distTo[w]>distTo[v]+e.Weight())
                {// 起点到达w点的路径 > 起点到达v的路径+e的权重
                    distTo[w] = distTo[v] + e.Weight();
                    edgeTo[w] = e;
                    if (pq.Contains(w))
                        pq.Change(w, distTo[w]);
                    else
                        pq.Insert(w, distTo[w]);
                }
            }
        }
        public double DistTo(int v)
        { return distTo[v]; }
        public bool HasPathTo(int v)
        { return distTo[v] < Double.PositiveInfinity; }
        public Stack<DirectedEdge> PathTo(int v)
        {
            if (!HasPathTo(v)) return null;
            Stack<DirectedEdge> path = new Stack<DirectedEdge>();
            for (DirectedEdge e = edgeTo[v]; e != null; e = edgeTo[e.From()])
                path.Push(e);
            return path;
        }
    }
}
