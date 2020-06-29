using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    class UF
    {
        /// <summary>
        /// union-find算法的实现（加权quick-union算法）
        /// </summary>
        private int[] id;   //父链接数组（由触点索引）
        private int[] sz;   //(由触点索引的）各个根节点所对应的分量的大小
        private int count;  //分量数量
        public UF(int N)
        {
            count = N;
            id = new int[N];
            for (int i = 0; i < N; i++)
                id[i] = i;
            sz = new int[N];
            for (int i = 0; i < N; i++)
                sz[i] = 1;
        }
        public int Count()
        { return count; }
        public bool Connected(int p,int q)
        { return Find(p) == Find(q); }
        private int Find(int p)
        {
            while (p != id[p])
                p = id[p];
            return p;
        }//找出分量的名称
        public void Union(int p,int q)
        {
            int i = Find(p);
            int j = Find(q);
            if (i == j) return;
            //将小树的根节点连接到大树的根节点
            if(sz[i]<sz[j])
            {
                id[i] = j;
                sz[j] += sz[i];
            }
            else
            {
                id[j] = i;
                sz[i] += sz[j];
            }
            count--;
        }//将p和q的根节点统一
    }
}
