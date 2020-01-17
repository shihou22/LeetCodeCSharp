using System;

namespace Convert_Integer_to_the_Sum_of_Two_No_Zero_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            var res = program.GetNoZeroIntegers(11);
            Console.WriteLine("Hello World!");
        }
        public int[] GetNoZeroIntegers(int n)
        {
            for (int i = 1; i <= n / 2; i++)
            {
                // if (!chk(i))
                //     continue;
                // if (!chk(n - i))
                //     continue;
                if (!chkStr(i))
                    continue;
                if (!chkStr(n - i))
                    continue;
                return new int[] { i, n - i };
            }
            return new int[] { 1, n - 1 };
        }
        private bool chkStr(int wk)
        {
            return wk.ToString().IndexOf("0") < 0;
        }
        private bool chk(int wk)
        {
            while (wk != 0)
            {
                int tmp = wk % 10;
                if (tmp == 0)
                    return false;
                wk /= 10;
            }
            return true;
        }

    }

}
