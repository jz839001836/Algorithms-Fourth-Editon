using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 使用广度优先搜索查找图中的路径
    /// </summary>
    class BreadthFirstPaths
    {
        private bool[] marked;  //到达该顶点的最短路径已知吗？
        private int[] edgeTo;   //到达该顶点的已知路径上的最后一个顶点
        private readonly int s; //起点
        public BreadthFirstPaths(Graph G,int s)
        {
            marked = new bool[G.VNumber()];
            edgeTo = new int[G.VNumber()];
            this.s = s;
            Bfs(G, s);
        }
        private void Bfs(Graph G,int s)
        {
            Queue<int> queue = new Queue<int>();
            marked[s] = true;                 //标记起点
            queue.enqueue(s);                 //将起点加入队列
            while(!queue.IsEmpty())
            {
                int v = queue.dequeue();      //从队列中删去下一个顶点
                foreach(int w in G.Adj(v))
                {
                    if(!marked[w])            //对于每个未被标记的相邻顶点
                    {
                        edgeTo[w] = v;        //保存最短路径的最后一条边
                        marked[w] = true;     //标记它，因为最短路径已知
                        queue.enqueue(w);     //并将它添加到队列中
                    }
                }
            }
        }
        public bool HasPathTo(int v)
        {
            return marked[v];
        }
        public Stack<int> PathTo(int v)   //返回从起点s到顶点v的路径，以栈形式保存
        {
            if (!HasPathTo(v)) return null;
            Stack<int> path = new Stack<int>();
            for(int x=v;x!=s;x=edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(s);
            return path;
        }
        public int DistTo(int w)
        {
            return this.PathTo(w).Size();
        }
    }
}
