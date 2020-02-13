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
            int res = 0;
            int cntO = 0;
            int cntE = 0;
            for (int i = 0; i < A.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    if (A[i] < A[i + 1])
                    {
                        cntO = 0;
                        cntE++;
                    }
                    else if (A[i] > A[i + 1])
                    {
                        cntO++;
                        cntE = 0;
                    }
                    else
                    {
                        cntO = 0;
                        cntE = 0;
                    }
                }
                else
                {
                    if (A[i] < A[i + 1])
                    {
                        cntO++;
                        cntE = 0;
                    }
                    else if (A[i] > A[i + 1])
                    {
                        cntO = 0;
                        cntE++;
                    }
                    else
                    {
                        cntO = 0;
                        cntE = 0;
                    }
                }
                res = Math.Max(res, Math.Max(cntO, cntE));
            }
            return res + 1;
        }
    }
}
