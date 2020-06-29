using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 字母表
    /// </summary>
    class Alphabet
    {
        public static readonly Alphabet BINARY = new Alphabet("01");
        public static readonly Alphabet OCTAL = new Alphabet("01234567");
        public static readonly Alphabet DECIMAL = new Alphabet("0123456789");
        public static readonly Alphabet HEXADECIMAL = new Alphabet("0123456789ABCDEF");
        public static readonly Alphabet DNA = new Alphabet("ACGT");
        public static readonly Alphabet LOWERCASE = new Alphabet("abcdefghijklmnopqrstuvwxyz");
        public static readonly Alphabet UPPERCASE = new Alphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        public static readonly Alphabet PROTEIN = new Alphabet("ACDEFGHIKLMNPQRSTVWY");
        public static readonly Alphabet BASE64 = new Alphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/");
        public static readonly Alphabet ASCII = new Alphabet(128);
        public static readonly Alphabet EXTENDED_ASCII = new Alphabet(256);
        public static readonly Alphabet UNICODE16 = new Alphabet(65536);

        private char[] alphabet;  //字母表中的字符
        private int[] inverse;    //指数
        private readonly int r;   //字母表的基数

        public Alphabet(String alpha)
        {
            bool[] unicode = new bool[65535];
            for(int i=0;i<alpha.Length;i++)
            {
                char c = alpha[i];
                unicode[c] = true;
            }
            alphabet = alpha.ToCharArray();
            r = alpha.Length;
            inverse = new int[65535];
            for (int i = 0; i < inverse.Length; i++)
                inverse[i] = -1;
            for (int c = 0; c < r; c++)
                inverse[alphabet[c]] = c;
        }

        public Alphabet(int radix)
        {
            r = radix;
            alphabet = new char[r];
            inverse = new int[r];
            //不能使用char，因为R可达65536
            for (int i = 0; i < r; i++)
                alphabet[i] = (char)i;
            for (int i = 0; i < r; i++)
                inverse[i] = i;
        }
        public Alphabet():this(256)
        { }
        public bool Contains(char c)
        { return inverse[c] != -1; }
        public int R()
        { return r; }
        public int Radix()
        { return r; }
        public int LgR()
        {
            int lgR = 0;
            for (int t = r - 1; t >= 1; t /= 2)
                lgR++;
            return lgR;
        }
        public int ToIndex(char c)
        { return inverse[c]; }
        public int[] ToIndices(String s)
        {
            char[] source = s.ToCharArray();
            int[] target = new int[s.Length];
            for (int i = 0; i < source.Length; i++)
                target[i] = ToIndex(source[i]);
            return target;
        }
        public char ToChar(int index)
        { return alphabet[index]; }
        public String ToChars(int[] indices)
        {
            StringBuilder s = new StringBuilder(indices.Length);
            for (int i = 0; i < indices.Length; i++)
                s.Append(ToChar(indices[i]));
            return s.ToString();
        }
    }
}
