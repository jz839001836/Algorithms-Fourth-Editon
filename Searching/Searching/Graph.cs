using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 无向图（生成一个无向图并提供无向图结构）
    /// </summary>
    class Graph
    {
        private readonly int V;  //顶点数目
        private int E;           //边的数目
        private Bag<int>[] adj;//邻接边
        public Graph(int V)
        {
            this.V = V;
            this.E = 0;
            adj = new Bag<int>[V];         //创建邻接表
            for (int v = 0; v < V; v++)    //将所有链表初始化为空
                adj[v] = new Bag<int>();
        }
        public Graph(Graph G)
        {
            this.V = G.VNumber();
            this.E = G.ENumber();
            for(int v=0;v<G.VNumber();v++)
            {
                Stack<int> reverse = new Stack<int>();
                foreach(int w in G.adj[v])
                {
                    reverse.Push(w);
                }
                foreach(int w in reverse)
                {
                    adj[v].Add(w);
                }
            }
        }//创建G的副本
        public int VNumber()
        { return V; }//返回顶点数目
        public int ENumber()
        { return E; }//返回边数目
        public void AddEdge(int v,int w)
        {
            adj[v].Add(w);   //将w添加到v的链表中
            adj[w].Add(v);   //将v添加到w的链表中
            E++;
        }
        public Bag<int> Adj(int v)
        { return adj[v]; }//返回v点的邻接边
        public override String ToString()
        {
            String s = V + " vertices, " + E + " edges\n";
            for (int v = 0; v < V; v++)
            {
                s += v + ": ";
                foreach (int w in adj[v])
                {
                    s += w + " ";
                }
            }
            return s;
        }
    }
}
