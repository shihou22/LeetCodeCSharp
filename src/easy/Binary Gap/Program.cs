using System;

namespace Binary_Gap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int BinaryGap(int N)
        {
            List<int> wk = new List<int>();
            while (N > 0)
            {
                wk.Add(N & 1);
                N >>= 1;
            }
            int ret = 0;
            int left = 0;
            int right = 1;
            while (left < right && left < wk.Count - 1)
            {
                while (right < wk.Count && wk[right] == 1)
                    right++;

                ret = Math.Max(ret, right - left);
                left = right;
                right++;
            }
            return ret;
        }
    }
}
