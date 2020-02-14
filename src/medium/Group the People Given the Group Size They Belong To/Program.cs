using System;
using System.Collections.Generic;
using System.Linq;

namespace Group_the_People_Given_the_Group_Size_They_Belong_To
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Dictionary<int, IList<int>> tmp = new Dictionary<int, IList<int>>();
            for (int i = 0; i < groupSizes.Length; i++)
            {
                int wk = groupSizes[i];
                if (!tmp.ContainsKey(wk))
                    tmp.Add(wk, new List<int>());
                tmp[wk].Add(i);
                if (tmp[wk].Count == wk)
                {
                    res.Add(tmp[wk]);
                    tmp.Remove(wk);
                }
            }
            return res;

        }
    }
}
