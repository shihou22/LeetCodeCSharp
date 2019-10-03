using System;
using System.Collections.Generic;

namespace Delete_Columns_to_Make_Sorted
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // Console.WriteLine(program.MinDeletionSize(new string[] { "cba", "daf", "ghi" }));
            Console.WriteLine(program.MinDeletionSize(new string[] { "rrjk", "furt", "guzm" }));
            Console.WriteLine("Hello World!");
        }
        public int MinDeletionSize(string[] A)
        {
            // char[][] res = new char[A.Length][];
            // for (int i = 0; i < A.Length; i++)
            // {
            //     res[i] = A[i].ToCharArray();
            // }
            List<int> result = new List<int>();
            for (int i = 0; i < A[0].Length; i++)
            {
                int cnt = -1;
                bool isDel = false;
                for (int j = 0; j < A.Length; j++)
                {
                    var charItem = A[j][i];
                    if (charItem - 'a' >= cnt)
                        cnt = charItem - 'a';
                    else
                    {
                        isDel = true;
                        break;
                    }
                }
                if (isDel)
                    result.Add(i);

            }
            return result.Count;
        }
    }
}
