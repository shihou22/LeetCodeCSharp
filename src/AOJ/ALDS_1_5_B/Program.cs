using System;
using System.Linq;
using System.Text;
static class Define
{
    // public const long Infty = 100000001;//const 上書きできない
    public const long Infty = long.MaxValue;//const 上書きできない
}
namespace ALDS_1_5_B
{
    class Program
    {
        public static long cnt = 0;
        public static long n = 0;
        public static long[] A = new long[n];
        public static void Merge(long[] A, long left, long mid, long right)
        {
            long n1 = mid - left;
            long n2 = right - mid;
            //L[0,,,n1]、R[0,,,n2]を生成
            long[] L = new long[n1 + (long)1];
            long[] R = new long[n2 + (long)1];
            for (long i = 0; i < n1; i++) L[i] = A[left + i];
            for (long i = 0; i < n2; i++) R[i] = A[mid + i];
            L[n1] = Define.Infty;
            R[n2] = Define.Infty;
            long l = 0;
            long m = 0;
            try
            {

                for (long k = left; k < right; k++)//k=0～n-1
                {
                    cnt++;
                    if (L[l] <= R[m])
                    {
                        A[k] = L[l];
                        l++;
                    }
                    else
                    {
                        A[k] = R[m];
                        m++;
                    }
                }
            }
            catch (Exception e)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("L;");
                foreach (var item in L)
                {
                    builder.Append(item + "/");
                }
                builder.Append(" / R;");
                foreach (var item in R)
                {
                    builder.Append(item + "/");
                }
                builder.Append(n1 + "/" + n2 + "/" + m + "/" + left + "/" + mid + "/" + right + "/" + A.Length);
                throw new ArgumentException(e.Message + builder.ToString());
            }

        }
        public static void MergeSort(long[] A, long left, long right)
        {
            if (right - left > 1)
            {//継続条件
                long mid = left + (right - left) / (long)2;
                MergeSort(A, left, mid);
                MergeSort(A, mid, right);
                Merge(A, left, mid, right);
            }
        }

        public static void Main()
        {
            //入力
            n = long.Parse(Console.ReadLine());
            string[] text1 = Console.ReadLine().Split(' ');
            A = text1.Select(s => long.Parse(s)).ToArray();
            // A = new long[] { 100000002, 100000002, 100000002, 100000002, 100000002, 100000002, 100000002, 100000002};
            n = A.Length;
            //探索ソート
            MergeSort(A, 0, n);
            //出力
            Console.Write(A[0]);
            for (long i = 1; i < n; i++)
            {
                Console.Write(" {0}", A[i]);
            }
            Console.WriteLine();
            Console.WriteLine(cnt);
        }
    }

}
