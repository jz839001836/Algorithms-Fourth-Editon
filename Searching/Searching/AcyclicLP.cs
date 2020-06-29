using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    class AcyclicLP
    {
        private DirectedEdge[] edgeTo;
        private double[] distTo;
        public AcyclicLP(EdgeWeightedDigraph G)
        {
            edgeTo = new DirectedEdge[G.VNumber()];
            distTo = new double[G.VNumber()];
            for (int v = 0; v < G.VNumber(); v++)
                distTo[v] = Double.NegativeInfinity;
            Topological top = new Topological(G);
            /*起先并不知道图的拓扑排序顺序，因此无法得知起点位置，
             * 因此引入计数器n，判定拓扑排序起点，并将起点的distTo[]设置为0。
             */
            int n = 0;
            foreach (int v in top.Order())
            {
                if (n == 0)
                    distTo[v] = 0.0;
                Relax(G, v);
                n++;
            }
        }
        private void Relax(EdgeWeightedDigraph G, int v)
        {
            foreach (DirectedEdge e in G.Adj(v))
            {
                int w = e.To();
                if (distTo[w] < distTo[v] + e.Weight())
                {
                    distTo[w] = distTo[v] + e.Weight();
                    edgeTo[w] = e;
                }
            }
        }
        public double DistTo(int v)
        { return distTo[v]; }
        public bool HasPathTo(int v)
        { return distTo[v] > Double.NegativeInfinity; }
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
