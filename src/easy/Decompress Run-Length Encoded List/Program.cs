using System;
using System.Linq;
using System.Collections.Generic;

namespace Decompress_Run_Length_Encoded_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.DecompressRLElist(new int[] { 1, 2, 3, 4 }));
            Console.WriteLine("Hello World!");
        }
        public int[] DecompressRLElist(int[] nums)
        {
            IList<int> res = new List<int>();
            int cnt = 0;
            while (cnt < nums.Length)
            {
                int a = nums[cnt];
                int b = nums[cnt + 1];
                for (int i = 0; i < a; i++)
                {
                    res.Add(b);
                }
                cnt += 2;
            }
            return res.ToArray();
        }
    }
}
