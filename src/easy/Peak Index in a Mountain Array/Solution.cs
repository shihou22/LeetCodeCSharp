using System;
using System.Linq;

namespace Peak_Index_in_a_Mountain_Array
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            // Console.WriteLine(solution.PeakIndexInMountainArray(new int[] { 0, 1, 0 }));
            // Console.WriteLine(solution.PeakIndexInMountainArray(new int[] { 0, 2, 1, 0 }));
            // Console.WriteLine(solution.PeakIndexInMountainArrayFor(new int[] { 0, 1, 0 }));
            Console.WriteLine(solution.PeakIndexInMountainArrayFor(new int[] { 0, 2, 1, 0 }));
            // Console.WriteLine(solution.PeakIndexInMountainArrayOld(new int[] { 0, 1, 0 }));
            // Console.WriteLine(solution.PeakIndexInMountainArrayOld(new int[] { 0, 2, 1, 0 }));
            Console.WriteLine("Hello World!");
        }

        public int PeakIndexInMountainArray(int[] A)
        {
            return Array.IndexOf(A,A.Max());
        }
        public int PeakIndexInMountainArrayFor(int[] A)
        {
            for (int i = 0; i < A.Length - 1; i++)
            {
                if (A[i] > A[i + 1])
                {
                    return i;
                }
            }

            return -1;
        }

        public int PeakIndexInMountainArrayOld(int[] A)
        {
            int left = 0;
            int right = A.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (A[mid] < A[mid + 1])
                {
                    left = mid + 1;
                }
                else if (A[mid] < A[mid - 1])
                {
                    right = mid;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }
    }
}
