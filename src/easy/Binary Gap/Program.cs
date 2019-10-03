using System;
using System.Collections.Generic;

namespace Binary_Gap
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.BinaryGap(22));//2
            Console.WriteLine(program.BinaryGap(5));//2
            Console.WriteLine(program.BinaryGap(6));//1
            Console.WriteLine(program.BinaryGap(8));//0
            Console.WriteLine("Hello World!");
        }
        public int BinaryGap(int N)
        {
            int ret = 0;
            //cnt==0は初回判定に使う
            int cnt = 0;
            while (N > 0)
            {
                if ((N & 1) == 1)
                {
                    //初回は不要
                    if (cnt > 0)
                    {
                        ret = Math.Max(cnt, ret);
                    }
                    cnt = 1;
                }
                //初回は不要
                else if (cnt > 0)
                {
                    cnt++;
                }
                N >>= 1;
            }
            return ret;
        }
        public int BinaryGapSlidingWindow(int N)
        {
            List<int> wk = new List<int>();
            while (N > 0)
            {
                wk.Insert(0, N & 1);
                N >>= 1;
            }
            int ret = 0;
            int left = 0;
            int right = 1;
            while (left < right && right < wk.Count)
            {
                while (right < wk.Count && wk[right] == 0)
                    right++;

                if (right < wk.Count && wk[right] != 0)
                    ret = Math.Max(ret, right - left);
                left = right;
                right++;
            }
            return ret;
        }
    }
}
