using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 基于二分查找的符号表
    /// </summary>
    /// <typeparam name="Key">键</typeparam>
    /// <typeparam name="Value">值</typeparam>
    class BinarySearchST<Key,Value> where Key:IComparable<Key>
    {
        private Key[] keys;
        private Value[] vals;
        private int n = 0;
        public BinarySearchST(int capacity)
        {
            keys = new Key[capacity];
            vals = new Value[capacity];
        }
        public int Size()
        { return n; }//表中键值对的数量
        public int Size(Key lo,Key hi)
        {
            if (lo.CompareTo(hi) > 0) return 0;
            if (Contains(hi))
                return Rank(hi) - Rank(lo) + 1;
            else
                return Rank(hi) - Rank(lo);
        }
        public bool IsEmpty()
        { return Size() == 0; }
        private void Resize(int max)//调整数组大小
        {
            Key[] temp01 = new Key[max];
            Value[] temp02 = new Value[max];
            for(int i=0;i<n;i++)
            {
                temp01[i] = keys[i];
                temp02[i] = vals[i];
            }
            keys = temp01;
            vals = temp02;
        }
        public Value Get(Key key)
        {
            if (IsEmpty()) return default(Value);
            int i = Rank(key);
            if (i < n && keys[i].CompareTo(key) == 0) return vals[i];
            else return default(Value);
        }//获取键key对应的值（若键key不存在则返回空）
        public int Rank(Key key)//基于有序数组的二分查找(迭代）
        {
            int lo = 0,hi = n - 1;
            while(lo<=hi)
            {
                int mid = lo + (hi - lo) / 2;
                int cmp = key.CompareTo(keys[mid]);
                if (cmp < 0) hi = mid - 1;
                else if (cmp > 0) lo = mid + 1;
                else return mid;
            }
            return lo;
        }
        public int Rank(Key key,int lo,int hi)
        {
            if (hi < lo) return lo;
            int mid = lo + (hi - lo) / 2;
            int cmp = key.CompareTo(keys[mid]);
            if (cmp < 0)
                return Rank(key, lo, mid - 1);
            else if (cmp > 0)
                return Rank(key, mid + 1, hi);
            else return mid;
        }//递归的二次查找
        public void Put(Key key,Value val)//查找键，找到则更新值，否则创建新的元素
        {
            int i = Rank(key);
            if(i<n&&keys[i].CompareTo(key)==0)
            { vals[i] = val;return; }
            if (n == keys.Length) Resize(2 * keys.Length);
            for(int j=n;j>i;j--)
            {
                keys[j] = keys[j - 1];
                vals[j] = vals[j - 1];
            }
            keys[i] = key;
            vals[i] = val;
            n++;
        }
        public Key Min()
        { return keys[0]; }
        public Key Max()
        { return keys[n - 1]; }
        public Key Select(int k)
        { return keys[k]; }
        public Key Ceiling(Key key)
        {
            int i = Rank(key);
            return keys[i];
        }//大于等于键的最小值
        public Key Floor(Key key)
        {
            int i = Rank(key);
            if (i < n && key.CompareTo(keys[i]) == 0)
                return keys[i];
            if (i == 0)
                return default(Key);
            else return keys[i - 1];
        }//小于等于键的最大值
        public void Delete(Key key)
        {
            //需要抛出没有输入key的异常
            if (IsEmpty()) return;
            int i = Rank(key);
            if (i == n || key.CompareTo(keys[i]) != 0)
                return;
            for(int j=i;j<n-1;j++)
            {
                keys[j] = keys[j + 1];
                vals[j] = vals[j + 1];
            }
            n--;
            keys[n] = default(Key);
            vals[n] = default(Value);
            if (n > 0 && n == keys.Length / 4) Resize(keys.Length / 2);
        }//从表中删除键key（及其对应的值）
        public bool Contains(Key key)
        {
            if (IsEmpty()) return false;
            int i = Rank(key);
            if (i < n && keys[i].CompareTo(key) == 0) return true;
            else return false;
        }
        public Queue<Key> Keys(Key lo,Key hi)
        {
            Queue<Key> q = new Queue<Key>();
            for (int i = Rank(lo); i < Rank(hi); i++)
                q.enqueue(keys[i]);
            if (Contains(hi))
                q.enqueue(keys[Rank(hi)]);
            return q;
        }
    }
}
