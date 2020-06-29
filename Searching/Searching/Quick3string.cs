using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 三向字符串快速排序
    /// </summary>
    class Quick3string
    {
        private static int CharAt(String s,int d)
        {
            if (d < s.Length)
                return s[d];
            else
                return -1;
        }
        public static void Sort(String[] a)
        {
            Sort(a, 0, a.Length - 1, 0);
        }
        private static void Sort(String[] a,int lo,int hi,int d)
        {
            if (hi <= lo)
                return;
            int lt = lo, gt = hi;
            int v = CharAt(a[lo], d);
            int i = lo + 1;
            while(i<=gt)
            {
                int t = CharAt(a[i], d);
                if (t < v)
                    Exch(a, lt++, i++);
                else if (t > v)
                    Exch(a, i, gt--);
                else
                    i++;
            }//三向切分
            Sort(a, lo, lt - 1, d);
            if (v >= 0)
                Sort(a, lt, gt, d + 1);
            Sort(a, gt + 1, hi, d);
        }
        private static void Exch(String[] a, int i, int j)
        {
            string t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }
}
