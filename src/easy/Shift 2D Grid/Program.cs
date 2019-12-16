using System;
using System.Collections.Generic;

namespace Shift_2D_Grid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            int row = grid.Length;
            int col = grid[0].Length;
            int baseIndex = row * col - k % (row * col);
            Console.WriteLine("totalNum : " + baseIndex);
            IList<int> wk = new List<int>();
            foreach (var item in grid)
            {
                foreach (var item2 in item)
                    wk.Add(item2);
            }
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < row; i++)
            {
                IList<int> tmp = new List<int>();
                int cnt = 0;
                while (cnt < col)
                {
                    if (baseIndex > row * col - 1)
                        baseIndex = 0;
                    cnt++;
                    tmp.Add(wk[baseIndex++]);
                }
                res.Add(tmp);
            }
            return res;
        }
    }
}
