using System;
using System.Collections.Generic;
using System.Linq;

namespace Single_Number_II
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wk = new List<int>() { 1, 2, 3, 4, 1, 2, 3 };
            Program program = new Program();
            int[] tmp = new int[] { 2, 2, 3, 2 };
            Console.WriteLine(program.SingleNumber(tmp));
            Console.WriteLine("Hello World!");
        }
        public int SingleNumber(int[] nums)
        {
            int res = 0;
            //32bit確認
            for (int i = 0; i < 32; i++)
            {
                int sum = 0;
                //全ての値のbitを順に調べていく
                foreach (var item in nums)
                {
                    if (((item >> i) & 1) == 1)
                        sum++;
                }
                //3の倍数でまとめることができる
                if (sum % 3 != 0)
                    res |= (1 << i);
            }
            return res;
        }
    }
}
