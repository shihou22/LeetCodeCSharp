using System;

namespace Distribute_Candies_to_People
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var res = new int[2];
            res = solution.DistributeCandies(7, 4);// [1,2,3,1]
            Console.WriteLine("Hello World!");
        }
        public int[] DistributeCandies(int candies, int num_people)
        {
            if (num_people == 0)
                return new int[0];

            int[] res = new int[num_people];
            int cnt = 0;
            int currCandies = 1;
            while (candies - currCandies >= 0)
            {
                res[cnt] += currCandies;
                candies -= currCandies;
                currCandies++;
                cnt++;
                if (cnt >= num_people)
                    cnt = 0;
            }
            res[cnt] += candies;
            return res;
        }
    }
}
