using System;
using System.Collections.Generic;
using System.Linq;

namespace Minimum_Index_Sum_of_Two_Lists
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string[] list1 = null;
            string[] list2 = null;
            list1 = new string[] { "Shogun", "Tapioca Express", "Burger King", "KFC" };
            list2 = new string[] { "Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun" };
            Console.WriteLine(solution.FindRestaurant(list1, list2));//Shogun
            list1 = new string[] { "Shogun", "Tapioca Express", "Burger King", "KFC" };
            list2 = new string[] { "KFC", "Shogun", "Burger King" };
            Console.WriteLine(solution.FindRestaurant(list1, list2));//Shogun
            list1 = new string[] { "Shogun", "Tapioca Express", "Burger King", "KFC" };
            list2 = new string[] { "KFC", "Shogun", "Burger King" };
            Console.WriteLine(solution.FindRestaurant(list1, list2));//Shogun
            Console.WriteLine("Hello World!");
        }
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            string[] wk1 = list1;
            string[] wk2 = list2;
            if (list1.Length > list2.Length)
            {
                wk1 = list2;
                wk2 = list1;
            }

            SortedDictionary<int, IList<string>> resMap = new SortedDictionary<int, IList<string>>();
            for (int wk1I = 0; wk1I < wk1.Length; wk1I++)
            {
                int wk2I = Array.IndexOf(wk2, wk1[wk1I]);
                if (wk2I >= 0)
                {
                    if (resMap.ContainsKey(wk1I + wk2I))
                        resMap[wk1I + wk2I].Add(wk1[wk1I]);
                    else
                    {
                        IList<string> res = new List<string>();
                        res.Add(wk1[wk1I]);
                        resMap.Add(wk1I + wk2I, res);
                    }
                }
            }
            foreach (var item in resMap)
            {
                return item.Value.ToArray();
            }
            return null;
        }
    }
}
