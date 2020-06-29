using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 能够完成点乘的稀疏向量
    /// </summary>
    class SparseVector
    {
        private LinearProbingHashST<Int32, Double> st;
        public SparseVector(int m)
        {
            st = new LinearProbingHashST<Int32, Double>(m);
        }
        public int size()
        { return st.Size(); }
        public void Put(int i,double x)
        {
            st.Put(i, x);
        }
        public double Get(int i)
        {
            if (!st.Contains(i)) return 0.0;
            else return st.Get(i);
        }
        public double Dot(double[] that)
        {
            double sum = 0.0;
            Queue<int> queue = new Queue<int>();
            queue = st.Keys();
            int number = 0;
            int size = queue.Size();
            for(int i=0;i<size;i++)
            {
                number = queue.dequeue();
                sum += that[number] * this.Get(number);
            }
            return sum;
        }
    }
}
