using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Searching
{
    class Test
    {
        public static void Main(string[] args)
        {
            ////加权无向图
            //EdgeWeightedGraph edgGrap = new EdgeWeightedGraph(8);
            //Edge e;
            //int[] a = { 4, 4, 5, 0, 1, 0, 2, 1, 0, 1, 1, 2, 6, 3, 6, 6 };
            //int[] b = { 5, 7, 7, 7, 5, 4, 3, 7, 2, 2, 3, 7, 2, 6, 0, 4 };
            //double[] c = { 0.35, 0.37, 0.28, 0.16, 0.32, 0.38, 0.17, 0.19, 0.26, 0.36, 0.29, 0.34, 0.40, 0.52, 0.58, 0.93 };
            //for (int i = 0; i < a.Length; i++)
            //{
            //    e = new Edge(a[i], b[i], c[i]);
            //    edgGrap.AddEdge(e);
            //}
            //string j = edgGrap.ToString();
            //Console.WriteLine(j);
            //PrimMST mst = new PrimMST(edgGrap);
            //double weight = mst.Weight();

            ////加权有向图
            //int[] a = { 5, 4, 5, 5, 4, 0, 3, 1, 7, 6, 3, 6, 6 };
            //int[] b = { 4, 7, 7, 1, 0, 2, 7, 3, 2, 2, 6, 0, 4 };
            //double[] c = { 0.35, 0.37, 0.28, 0.32, 0.28, 0.26, 0.39, 0.29, 0.34, 0.40, 0.52, 0.58, 0.93 };
            //DirectedEdge edge;
            //EdgeWeightedDigraph g = new EdgeWeightedDigraph(8);
            //for (int i = 0; i < a.Length; i++)
            //{
            //    edge = new DirectedEdge(a[i], b[i], c[i]);
            //    g.AddEdge(edge);
            //}
            //AcyclicLP sp = new AcyclicLP(g);

            ////一般加权有向图(含负权重边）
            //int[] a = { 4, 5, 4, 5, 7, 5, 0, 0, 7, 1, 2, 6, 3, 6, 6 };
            //int[] b = { 5, 4, 7, 7, 5, 1, 4, 2, 3, 3, 7, 2, 6, 0, 4 };
            //double[] c = { 0.35, 0.35, 0.37, 0.28, 0.28, 0.32, 0.38, 0.26, 0.39, 0.29, 0.34, -1.20, 0.52, -1.40, -1.25 };
            //DirectedEdge edge;
            //EdgeWeightedDigraph g = new EdgeWeightedDigraph(8);
            //for(int i=0;i<a.Length;i++)
            //{
            //    edge = new DirectedEdge(a[i], b[i], c[i]);
            //    g.AddEdge(edge);
            //}
            //BellmanFordSP sp = new BellmanFordSP(g, 0);

            ////含负环的有向加权图的BellmanFordSP测试
            //int[] a = { 4, 5, 4, 5, 7, 5, 0, 0, 7, 1, 2, 6, 3, 6, 6 };
            //int[] b = { 5, 4, 7, 7, 5, 1, 4, 2, 3, 3, 7, 2, 6, 0, 4 };
            //double[] c = { 0.35, -0.66, 0.37, 0.28, 0.28, 0.32, 0.38, 0.26, 0.39, 0.29, 0.34, 0.40, 0.52, 0.58, 0.93 };
            //DirectedEdge edge;
            //EdgeWeightedDigraph g = new EdgeWeightedDigraph(8);
            //for(int i=0;i<a.Length;i++)
            //{
            //    edge = new DirectedEdge(a[i], b[i], c[i]);
            //    g.AddEdge(edge);
            //}
            //BellmanFordSP sp = new BellmanFordSP(g, 0);

            ////字母表测试--失败
            //Alphabet alpha = new Alphabet(65535);
            //int R = alpha.R();
            //int[] count = new int[R];
            //String s = Console.ReadLine();
            //int N = s.Length;
            //for (int i = 0; i < N; i++)
            //    if (alpha.Contains(s[i]))
            //        count[alpha.ToIndex(s[i])]++;
            //for (int c = 0; c < R; c++)
            //    Console.WriteLine("{0} {1}", alpha.ToChar(c), count[c]);

            //String[] a = { "4PGC938", "2IYE230", "3CIO720", "1ICK750", "10HV845", "4JZY524", "1ICK750", "3CI0720", "10HV845", "10HV845", "2RLA629", "2RLA629", "3ATW723" };
            //LSD.Sort(a, 7);

            //String[] a = { "by", "sea", "sells", "she", "shells", "shore", "the" };
            //TrieST<int> st = new TrieST<int>();
            //st.Put(a[1], 4);
            //Queue<String> s = st.Keys();
            //int i = st.Get("sea");

            string s = "";
            Console.WriteLine(s.Length);
        }
    }
}
