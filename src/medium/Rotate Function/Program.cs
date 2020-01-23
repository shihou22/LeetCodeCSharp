using System;
using System.Linq;

namespace Rotate_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.MaxRotateFunction(new int[] { 4, 3, 2, 6 }));//26
            Console.WriteLine(program.MaxRotateFunction(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));//330
            Console.WriteLine(program.MaxRotateFunction(new int[] { 2147483647, 2147483647 }));//330
            Console.WriteLine("Hello World!");
        }
        /*
        f(0)= 0A + 1B + 2C + 3D
        f(1)= 3A + 0B + 1C + 2D
        f(2)= 2A + 3B + 0C + 1D
        f(3)= 1A + 2B + 3C + 0D
        
        f(1)=f(0)-sum(A->B)+A[0]*4
        */
        public int MaxRotateFunction(int[] A)
        {
            long total = 0;
            long fresult = 0;
            int n = A.Length;

            for (int i = 0; i < n; i++)
            {
                /*
                if use Arrays.Sum(). Cause the Arithmetic Exception. 
                Because total sum will be over at int32.
                */
                total += A[i];
                fresult += A[i] * i;
            }
            long res = fresult;
            for (int i = 1; i < n; i++)
            {
                fresult = fresult - total + A[i - 1] * n;
                res = Math.Max(res, fresult);
            }
            return (int)res;
        }
    }
}
