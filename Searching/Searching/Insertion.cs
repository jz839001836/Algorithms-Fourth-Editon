﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 插入排序
    /// </summary>
    /// <typeparam name="Item"></typeparam>
    class Insertion<Item> where Item:IComparable<Item>
    {
        public static void Sort(Item[] a)
        {
            int N = a.Length;
            for(int i=0;i<N;i++)
            {
                for (int j = i; j > 0 && Less(a[j], a[j - 1]); j--)
                    Exch(a, j, j - 1);
            }
        }
        private static void Exch(Item[] a, int i, int j)
        {
            Item t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
        private static bool Less(Item v, Item w)
        {
            return v.CompareTo(w) < 0;
        }
        public static void Show(Item[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.ReadKey();
        }
        public static bool IsSorted(Item[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (Less(a[i], a[i - 1]))
                    return false;
            }
            return true;
        }
    }
}
