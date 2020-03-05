using System;

namespace Circular_Array_Loop
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // true
            System.Console.WriteLine(program.CircularArrayLoop(new int[] { 2, -1, 1, 2, 2 }));
            // false
            System.Console.WriteLine(program.CircularArrayLoop(new int[] { -1, 2 }));
            // false
            System.Console.WriteLine(program.CircularArrayLoop(new int[] { -2, 1, -1, -2, -2 }));
            // false
            System.Console.WriteLine(program.CircularArrayLoop(new int[] { -1, -2, -3, -4, -5 }));
            Console.WriteLine("Hello World!");
        }
        public bool CircularArrayLoop(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                bool[] visited = new bool[n];
                int cnt = 0;
                int idex = i;
                bool isLoop = true;
                while (!visited[idex])
                {
                    visited[idex] = true;
                    if ((nums[i] >= 0) != (nums[idex] >= 0))
                    {
                        isLoop = false;
                        break;
                    }
                    idex = (idex + nums[idex]) % n;
                    if (idex < 0)
                        idex = n - Math.Abs(idex);

                    cnt++;
                }
                if (cnt == 1)
                    continue;
                if (isLoop && i == idex)
                    return true;
            }
            return false;
        }
    }
}
