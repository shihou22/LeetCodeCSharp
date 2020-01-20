using System;
using System.Linq;

namespace Contains_Duplicate_III
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // Console.WriteLine(program.ContainsNearbyAlmostDuplicate(new int[] { 1, 2, 3, 1 }, 3, 0));
            // Console.WriteLine(program.ContainsNearbyAlmostDuplicate(new int[] { 1, 0, 1, 1 }, 1, 2));
            // Console.WriteLine(program.ContainsNearbyAlmostDuplicate(new int[] { -1, 2147483647 }, 1, 2147483647));
            // Console.WriteLine(program.ContainsNearbyAlmostDuplicate(new int[] { 1, 5, 9, 1, 5, 9 }, 2, 3));
            // Console.WriteLine(program.ContainsNearbyAlmostDuplicateSort(new int[] { 1, 5, 9, 1, 5, 9 }, 2, 3));
            Console.WriteLine("Hello World!");
        }

        public int lowerBound(int[][] nums, int val)
        {
            int left = -1;
            int right = nums.Length;
            while (right - left > 1)
            {
                int mid = left + (right - left) / 2;
                if (val < nums[mid][0])
                    right = mid;
                else
                    left = mid;
            }
            return left;
        }

        public bool ContainsNearbyAlmostDuplicateSort(int[] nums, int k, int t)
        {
            int max = nums.Length;
            var wk = nums.Select((num, i) => new { num, i }).OrderBy(n => n.num).ToArray();
            for (int i = 0; i < max; i++)
            {
                for (int j = i + 1; j < max && (long)wk[j].num - (long)wk[i].num <= t; j++)
                {
                    if (Math.Abs(wk[i].i - wk[j].i) <= k)
                        return true;
                }
            }
            return false;
        }
        public bool ContainsNearbyAlmostDuplicateTLE(int[] nums, int k, int t)
        {

            int right = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (right >= nums.Length || i == right || right <= i)
                    right = i + 1;
                while (right < nums.Length)
                {
                    if (Math.Abs((long)nums[right] - (long)nums[i]) <= t && right - i <= k)
                        return true;
                    right++;
                }

            }
            return false;
        }
        public bool ContainsNearbyAlmostDuplicateTLELoop(int[] nums, int k, int t)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int max = Math.Min(i + k, nums.Length - 1);
                for (int j = i + 1; j <= max; j++)
                {
                    if (Math.Abs((long)nums[j] - (long)nums[i]) <= t)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
