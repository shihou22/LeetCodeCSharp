using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Base_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // Console.WriteLine(program.ConvertToBase7(100));//202
            Console.WriteLine(program.ConvertToBase7(-7));//-10
            Console.WriteLine("Hello World!");
        }
        public String ConvertToBase7(int num)
        {
            if (num < 0) return "-" + ConvertToBase7(-num);
            if (num < 7) return num.ToString();
            return ConvertToBase7(num / 7) + (num % 7).ToString();
        }
        public string ConvertToBase7Iterate(int num)
        {
            long n = num;
            if (n == 0)
                return "0";
            List<long> res = new List<long>();
            bool isMinus = n < 0;
            while (n != 0)
            {
                res.Add(Math.Abs(n % 7));
                n /= 7;
            }
            res.Reverse();
            return (isMinus ? "-" : "") + string.Join("", res.ToArray());
        }
    }
}
