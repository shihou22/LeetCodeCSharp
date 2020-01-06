using System;
using System.Linq;

namespace Find_Numbers_with_Even_Number_of_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int FindNumbers(int[] nums)
        {
            // var res = nums.Where(x => EvenDigit(x)).Count();
            var res = nums.Where(x => x.ToString().Length % 2 == 0).Count();
            return res;
        }
        private bool EvenDigit(int nums)
        {
            int cnt = 0;
            while (nums > 0)
            {
                nums /= 10;
                cnt++;
            }
            return cnt % 2 == 0;
        }
    }
}
