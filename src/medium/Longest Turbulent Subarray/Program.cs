using System;

namespace Longest_Turbulent_Subarray
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //5
            Console.WriteLine(program.MaxTurbulenceSize(new int[] { 9, 4, 2, 10, 7, 8, 8, 1, 9 }));
            //2
            Console.WriteLine(program.MaxTurbulenceSize(new int[] { 4, 8, 12, 16 }));
            //1
            Console.WriteLine(program.MaxTurbulenceSize(new int[] { 100 }));
            Console.WriteLine("Hello World!");
        }
        public int MaxTurbulenceSize(int[] A)
        {
            int res = 1;
            int cntO = 1;
            int cntE = 1;
            for (int i = 0; i < A.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    if (A[i] < A[i + 1])
                    {
                        cntO = 1;
                        cntE++;
                    }
                    else if (A[i] > A[i + 1])
                    {
                        cntO++;
                        cntE = 1;
                    }
                    else
                    {
                        cntO = 1;
                        cntE = 1;
                    }
                }
                else
                {
                    if (A[i] < A[i + 1])
                    {
                        cntO++;
                        cntE = 1;
                    }
                    else if (A[i] > A[i + 1])
                    {
                        cntO = 1;
                        cntE++;
                    }
                    else
                    {
                        cntO = 1;
                        cntE = 1;
                    }
                }
                res = Math.Max(res, Math.Max(cntO, cntE));
            }
            return res;
        }
    }
}
