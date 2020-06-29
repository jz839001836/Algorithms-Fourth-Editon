using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 基于队列的Bellman-Ford算法
    /// </summary>
    class BellmanFordSP
    {
        private double[] distTo;        //从起点到某个顶点的路径长度
        private DirectedEdge[] edgeTo;  //从起点到某个顶点的最后一条边
        private bool[] onQ;             //该顶点是否存在于队列中
        private Queue<int> queue;       //正在被放松的顶点
        private int cost;               //Relax()的调用次数
        private Stack<int> cycle;       //edgeTo[]中的是否有负权重环  
        public BellmanFordSP(EdgeWeightedDigraph G,int s)
        {
            distTo = new double[G.VNumber()];
            edgeTo = new DirectedEdge[G.VNumber()];
            onQ = new bool[G.VNumber()];
            queue = new Queue<int>();
            for (int v = 0; v < G.VNumber(); v++)
                distTo[v] = Double.PositiveInfinity;
            distTo[s] = 0.0;
            queue.enqueue(s);
            onQ[s] = true;
            while(!queue.IsEmpty()&&!HasNegativeCycle())
            {
                int v = queue.dequeue();
                onQ[v] = false;
                Relax(G, v);
            }
        }
        private void Relax(EdgeWeightedDigraph G,int v)
        {
            foreach(DirectedEdge e in G.Adj(v))
            {
                int w = e.To();
                if(distTo[w]>distTo[v]+e.Weight())
                {
                    distTo[w] = distTo[v] + e.Weight();
                    edgeTo[w] = e;
                    if(!onQ[w])
                    {
                        queue.enqueue(w);
                        onQ[w] = true;
                    }
                }
                if (cost++ % G.VNumber() == 0)
                    FindNegativeCycle();//寻找有向图中是否有负权重环，以保证循环能够结束
            }
        }
        private void FindNegativeCycle()
        {
            int V = edgeTo.Length;
            EdgeWeightedDigraph spt = new EdgeWeightedDigraph(V);
            for (int v = 0; v < V; v++)
                if (edgeTo[v] != null)
                    spt.AddEdge(edgeTo[v]);
            DirectedCycle cf = new DirectedCycle(spt);
            cycle = cf.Cycle();
        }
        public bool HasNegativeCycle()
        { return cycle != null; }
        public Stack<int> NegativeCycle()
        { return cycle; }
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
