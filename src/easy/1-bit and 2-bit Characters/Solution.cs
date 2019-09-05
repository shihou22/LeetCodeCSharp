using System;

namespace _1_bit_and_2_bit_Characters
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool IsOneBitCharacter(int[] bits)
        {

            for (int i = 0; i < bits.Length;)
            {
                if (bits[i] == 1)
                {
                    i += 2;
                    if (i >= bits.Length)
                    {
                        return false;
                    }
                }
                else
                {
                    i++;
                }
            }
            return true;
        }
    }
}
