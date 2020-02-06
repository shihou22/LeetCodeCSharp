using System;

namespace H_Index
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.HIndex(new int[] { 3, 0, 6, 1, 5 }));
            Console.WriteLine("Hello World!");
        }
        public int HIndex(int[] citations)
        {
            if (citations.Length == 0)
                return 0;
            Array.Sort(citations, (x, y) => -x.CompareTo(y));
            int res = 0;
            int n = citations.Length;
            for (int i = 0; i < citations.Length; i++)
            {
                if ((i + 1) <= citations[i])
                    res = i + 1;
            }
            return res;
        }
    }
}
