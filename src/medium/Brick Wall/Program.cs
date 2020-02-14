using System;
using System.Collections.Generic;
using System.Linq;

namespace Brick_Wall
{
    class GridCreator
    {
        /*
        入力サンプル
        [[3,0,8,4],[2,4,5,7],[9,2,6,3],[0,3,1,0]]
        ↓
        [3,0,8,4]
        [2,4,5,7]
        [9,2,6,3]
        [0,3,1,0]
        */
        public static int[][] CreateGrid(string a)
        {
            string[] wk = a.Replace("[[", "").Replace("]]", "").Split("],[");
            int[][] grid = new int[wk.Length][];
            for (int i = 0; i < wk.Length; i++)
            {
                string[] tmp = wk[i].Split(",");
                grid[i] = tmp.Select(x => int.Parse(x)).ToArray();
            }
            return grid;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //2
            var wall1 = GridCreator.CreateGrid("[[1,2,2,1],[3,1,2],[1,3,2],[2,4],[3,1,2],[1,3,1,1]]");
            Console.WriteLine(program.LeastBricks(wall1));
            var wall2 = GridCreator.CreateGrid("[[1,2,2,1],[3,1,2],[1,3,2],[2,4],[3,1,2],[1,3,1,1]]");
            Console.WriteLine(program.LeastBricks(wall2));
            Console.WriteLine("Hello World!");
        }
        public int LeastBricks(IList<IList<int>> wall)
        {
            if (wall == null || wall.Count == 0)
                return 0;
            long length = wall[0].Sum();
            Dictionary<long, long> memo = new Dictionary<long, long>();
            foreach (var item in wall)
            {
                long cnt = 0;
                foreach (var inner in item)
                {
                    cnt += inner;
                    memo.TryAdd(cnt, 0);
                    memo[cnt]++;
                }
            }
            memo.Remove(length);
            long max = 0;
            foreach (var item in memo.Values)
            {
                max = Math.Max(max, item);
            }
            return (int)(wall.Count - max);
        }
        public int LeastBricksTLE(IList<IList<int>> wall)
        {
            int length = wall.Select(x => x.Sum()).Max();
            int[] memo = new int[length + 1];
            foreach (var item in wall)
            {
                int cnt = 0;
                foreach (var inner in item)
                {
                    cnt += inner;
                    memo[cnt]++;
                }
            }
            int max = memo.Where((x, i) => i != length).Max();
            return wall.Count - max;
        }
    }
}
