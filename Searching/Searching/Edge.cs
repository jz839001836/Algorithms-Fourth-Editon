using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 带权重的边的数据结构
    /// </summary>
    class Edge:IComparable<Edge>
    {
        private readonly int v;         //顶点之一
        private readonly int w;         //另一个顶点
        private readonly double weight; //边的权重

        public Edge(int v,int w,double weight)
        {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }
        public double Weight
        {
            get { return weight; }
        }
        public int Either
        {
            get { return v; }
        }
        public int Other(int vertex)
        {
            if (vertex == v) return w;
            else if (vertex == w) return v;
            else throw new ArgumentException("vertex不存在");
        }
        public int CompareTo(Edge that)
        {
            if (this.Weight < that.Weight)
                return -1;
            else if (this.Weight > that.Weight)
                return +1;
            else
                return 0;
        }
        public override string ToString()
        { return String.Format("{0}-{1}: {2}", v, w, weight); }
    }
}
