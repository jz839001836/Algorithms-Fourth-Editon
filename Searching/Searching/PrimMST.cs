using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 最小生成树的Prim算法（即时版本）
    /// </summary>
    class PrimMST
    {
        private Edge[] edgeTo;         //距离树最近的边
        private double[] distTo;       //distTo[w]=edgeTo[w].weight()，存放最小生成树到w点的最小权重
        private bool[] marked;         //如果v在树中则为true
        private IndexMinPQ<Double> pq; //有效的横切边
        public PrimMST(EdgeWeightedGraph G)
        {
            edgeTo = new Edge[G.VNumber];
            distTo = new double[G.VNumber];
            marked = new bool[G.VNumber];
            for (int v = 0; v < G.VNumber; v++)
                distTo[v] = Double.PositiveInfinity;
            pq = new IndexMinPQ<double>(G.VNumber);
            distTo[0] = 0.0;
            pq.Insert(0, 0.0);         //用顶点0和权重0初始化pq
            while (!pq.IsEmpty())
                Visit(G, pq.DelMin()); //将最近的顶点添加到树中
        }
        private void Visit(EdgeWeightedGraph G,int v)
        {
            marked[v] = true;
            foreach(Edge e in G.Adj(v))
            {
                int w = e.Other(v);
                if (marked[w]) continue;   //v-w失效
                if(e.Weight<distTo[w])
                {//连接w和树的最佳边Edge变为e
                    edgeTo[w] = e;       //保存w和最小生成树相连的边
                    distTo[w] = e.Weight;//即w和最小生成树最近的距离为e.Weight
                    if (pq.Contains(w))
                        pq.Change(w, distTo[w]);
                    else
                        pq.Insert(w, distTo[w]);
                }
            }
        }//将顶点v添加到树中，更新数据
        public Bag<Edge> Edges()
        {
            Bag<Edge> mst = new Bag<Edge>();
            for (int v = 1; v < edgeTo.Length; v++)
                mst.Add(edgeTo[v]);
            return mst;
        }
        public double Weight()
        {
            double weight = 0.0;
            for(int i=0;i<edgeTo.Length;i++)
            {
                weight += distTo[i];
            }
            return weight;
        }
    }
}
