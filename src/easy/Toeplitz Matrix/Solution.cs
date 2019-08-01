using System;

namespace Toeplitz_Matrix
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[][] arg3 = new int[2][];
            arg3[0] = new int[] { 11, 74, 0, 93 };
            arg3[1] = new int[] { 40, 11, 74, 7 };
            var res3 = solution.IsToeplitzMatrix(arg3);
            Console.WriteLine(res3);
            // int[][] arg1 = new int[3][];
            // arg1[0] = new int[] { 1, 2, 3, 4 };
            // arg1[1] = new int[] { 5, 1, 2, 3 };
            // arg1[2] = new int[] { 9, 5, 1, 2 };
            // var res1 = solution.IsToeplitzMatrix(arg1);
            // Console.WriteLine(res1);
            // int[][] arg2 = new int[2][];
            // arg2[0] = new int[] { 1, 2 };
            // arg2[1] = new int[] { 2, 2 };
            // var res2 = solution.IsToeplitzMatrix(arg2);
            // Console.WriteLine(res2);
            Console.WriteLine("Hello World!");
        }
        public bool IsToeplitzMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                var max = 1;
                if (i == 0)
                    max = matrix[0].Length;
                for (int outer = 0; outer < max; outer++)
                {
                    var tmpI = i;
                    bool tepliz = true;
                    for (int j = outer; j < matrix[0].Length - 1; j++)
                    {
                        if (tmpI + 1 > matrix.Length - 1)
                            break;

                        if (matrix[tmpI][j] != matrix[tmpI + 1][j + 1])
                        {
                            tepliz = false;
                            break;
                        }
                        tmpI++;
                    }
                    if (!tepliz)
                        return false;
                }

            }
            return true;

        }
    }
}
