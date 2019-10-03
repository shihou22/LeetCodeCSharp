using System;

namespace Binary_Number_with_Alternating_Bits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool HasAlternatingBits(int n)
        {
            int ret = (n & 1);
            n >>= 1;
            while (n > 0)
            {
                if (ret == (n & 1))
                    return false;
                ret = (n & 1);
                n >>= 1;
            }
            return true;
        }
    }
}
