using System;

namespace Valid_Mountain_Array
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            //false;
            Console.WriteLine(solution.ValidMountainArray(new int[] { 2, 1, 0 }));
            //false
            Console.WriteLine(solution.ValidMountainArray(new int[] { 3, 5 }));
            //true
            Console.WriteLine(solution.ValidMountainArray(new int[] { 0, 3, 2, 1 }));
            Console.WriteLine("Hello World!");
        }
        public bool ValidMountainArray(int[] A)
        {
            int i = 0;
            while (i < A.Length - 1 && A[i] < A[i + 1])
                i++;

            if (i == 0 || i == A.Length - 1)
                return false;

            while (i < A.Length - 1 && A[i] > A[i + 1])
                i++;

            return i == A.Length - 1;
        }
    }
}
