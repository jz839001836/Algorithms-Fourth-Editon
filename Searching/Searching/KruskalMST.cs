using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 最小生成树的Kruskal算法
    /// </summary>
    class KruskalMST
    {
        private Queue<Edge> mst;
        public KruskalMST(EdgeWeightedGraph G)
        {
            mst = new Queue<Edge>();
            MinPQ<Edge> pq = new MinPQ<Edge>();
            foreach(Edge e in G.Edges())
            {
                pq.Insert(e);
            }
            UF uf = new UF(G.VNumber);
            while(!pq.IsEmpty()&&mst.Size()<G.VNumber-1)
            {
                Edge e = pq.DelMin();  //从pq得到权重最小的边和它的顶点
                int v = e.Either, w = e.Other(v);
                if (uf.Connected(v, w))
                    continue;
                uf.Union(v, w);   //合并分量
                mst.enqueue(e);   //将边添加到最小生成树中
            } 
        }
        public Queue<Edge> Edges()
        { return mst; }
        public double Weight()
        {
            double totalWeight = 0.0;
            foreach (Edge e in mst)
            {
                totalWeight += e.Weight;
            }
            return totalWeight;
        }
    }
}
