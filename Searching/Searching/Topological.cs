using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 拓扑排序
    /// </summary>
    class Topological
    {
        private Stack<int> order;  //顶点的拓扑排序
        public Topological(Digraph G)
        {
            DirectedCycle cycleFinder = new DirectedCycle(G);//用于判断有向图G是否有环
            if(!cycleFinder.HasCycle())
            {
                DepthFirstOrder dfs = new DepthFirstOrder(G);
                order = dfs.ReversePost();
            }
        }
        public Topological(EdgeWeightedDigraph G)
        {
            DirectedCycle cycleFinder = new DirectedCycle(G);
            if(!cycleFinder.HasCycle())
            {
                DepthFirstOrder dfs = new DepthFirstOrder(G);
                order = dfs.ReversePost();
            }
        }
        public Stack<int> Order()
        { return order; } 
        public bool IsDAG()
        { return order != null; }
    }
}
