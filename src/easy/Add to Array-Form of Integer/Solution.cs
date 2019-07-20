using System;
using System.Linq;
using System.Collections.Generic;

namespace Add_to_Array_Form_of_Integer
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution solution = new Solution();
            solution.AddToArrayForm(new int[]{1,2,0,0},34);

        }
        public IList<int> AddToArrayForm(int[] A, int K)
        {

            IList<int> res = new List<int>();
            int index = A.Length - 1;
            int carry = 0;
            while (index >= 0 || K != 0)
            {
                if (index >= 0)
                {
                    carry += A[index];
                    index--;
                }
                    
                carry += K % 10;
                K /= 10;
                res.Add(carry % 10);
                carry /= 10;
            }
            if (carry != 0)
            {
                res.Add(carry);
            }
            return Enumerable.Reverse(res).ToList();
        }
    }
}