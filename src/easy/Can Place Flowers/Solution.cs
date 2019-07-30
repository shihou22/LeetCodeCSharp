using System;
using System.Collections.Generic;

namespace Can_Place_Flowers
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution soluton = new Solution();
            Console.WriteLine(soluton.CanPlaceFlowers(new int[] { 1, 0, 0, 0, 1 }, 1));//true
            Console.WriteLine(soluton.CanPlaceFlowers(new int[] { 1, 0, 0, 0, 1 }, 2));//false
            Console.WriteLine(soluton.CanPlaceFlowers(new int[] { 0, 0, 1, 0, 1 }, 1));//true
            Console.WriteLine(soluton.CanPlaceFlowers(new int[] { 0, 0, 0, 0, 1, 0, 1, 0, 0 }, 3));//true
            Console.WriteLine(soluton.CanPlaceFlowers(new int[] { 0 }, 1));//true
            Console.WriteLine(soluton.CanPlaceFlowers(new int[] { 1, 0, 1, 0, 0, 1, 0 }, 1));//false
            Console.WriteLine("Hello World!");
        }
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (flowerbed == null || flowerbed.Length == 0)
                return false;

            IList<int> rui = new List<int>();
            int cnt = 0;
            for (int i = 0; i < flowerbed.Length; i++)
            {
                if (flowerbed[i] == 0)
                {
                    cnt++;
                }
                else
                {
                    if (cnt != 0)
                        rui.Add(cnt);
                    cnt = 0;
                }
            }
            if (cnt != 0)
                rui.Add(cnt);


            bool first = flowerbed[0] == 0;
            bool last = flowerbed[flowerbed.Length - 1] == 0;

            if (rui.Count == 1 && first && last)
                return ((rui[0] + 1) / 2) >= n;

            int plotsCnt = 0;
            for (int i = 0; i < rui.Count; i++)
            {
                if (i == 0 && first || i == rui.Count - 1 && last)
                    plotsCnt += rui[i] / 2;
                else
                    plotsCnt += ((rui[i] - 2) + 1) / 2;
            }
            return plotsCnt >= n;
        }
    }
}
