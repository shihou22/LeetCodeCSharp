using System;

namespace Convert_a_Number_to_Hexadecimal
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            // Console.WriteLine(solution.ToHex(-1));
            // Console.WriteLine(solution.ToHex(-2));
            Console.WriteLine(solution.ToHex(26));
            Console.WriteLine("Hello World!");
        }
        public string ToHex(int num)
        {
            if (num == 0)
                return "0";

            string result = "";
            int cnt = 0;
            while (num != 0 && cnt < 8)
            {
                var tmp = num % 16 < 0 ? num % 16 + 16 : num % 16;
                var val = GetHex(tmp);
                result = val + result;
                num >>= 4;// ÷16を行うと、上位の符号のためのbitが消えてしまうため。
                cnt++;
            }
            return result;
        }

        public char GetHex(int num)
        {
            if (num >= 0 && num <= 9)
                return (char)(num + '0');
            else
                return (char)((num - 10) + 'a');
        }
    }
}
