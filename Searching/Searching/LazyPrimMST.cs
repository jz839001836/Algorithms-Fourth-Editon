using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 最小生成树的Prim算法的延时实现
    /// </summary>
    class LazyPrimMST
    {
        private bool[] marked;      //最小生成树的顶点
        private Queue<Edge> mst;    //最小生成树的边 
        private MinPQ<Edge> pq;     //横切边（包括失效的边）
        public LazyPrimMST(EdgeWeightedGraph G)
        {
            pq = new MinPQ<Edge>();
            marked = new bool[G.VNumber];
            mst = new Queue<Edge>();
            Visit(G, 0);
            while(!pq.IsEmpty())
            {
                Edge e = pq.DelMin();                //从pq中得到权重最小的边
                int v = e.Either;
                int w = e.Other(v);
                if (marked[v] && marked[w]) continue;//跳过失效的边
                mst.enqueue(e);                      //将边添加到树中
                if (!marked[v]) Visit(G, v);         //将顶点（v或w）添加到树中
                if (!marked[w]) Visit(G, w);
            }
        }
        private void Visit(EdgeWeightedGraph G,int v)
        {
            marked[v] = true;
            foreach(Edge e in G.Adj(v))
            {
                if (!marked[e.Other(v)])
                    pq.Insert(e);
            }
        }//标记顶点v并将所有连接v和未被标记顶点的边加入pq
        public Queue<Edge> Edges()
        { return mst; }
        public double Weight()
        {
            double weight = 0.0;
            foreach(Edge e in mst)
            {
                weight += e.Weight;
            }
            return weight;
        }//最小生成树的权重之和
    }
}
