using System;

namespace Super_Pow
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //1198
            Console.WriteLine(program.SuperPow(2147483647, new int[] { 2, 0, 0 }));
            //8
            Console.WriteLine(program.SuperPow(2, new int[] { 3 }));
            //1024
            Console.WriteLine(program.SuperPow(2, new int[] { 1, 0 }));
            //933
            Console.WriteLine(program.SuperPow(2, new int[] { 3, 1 }));
            Console.WriteLine("Hello World!");
        }
        int MOD = 1337;

        public int SuperPowMiss(int a, int[] b)
        {
            if (b == null || b.Length == 0)
                return 0;

            a %= MOD;
            long res = 1;
            long n = b.Length;

            for (long i = n - 1; i >= 0; i--)
            {
                long powPow = (n - i - 1) % MOD;
                powPow = Pow(10, powPow) % MOD;
                long basePow = Pow(a, powPow) % MOD;
                basePow = Pow(basePow, b[i]) % MOD;
                res = res * basePow;
                res = res % MOD;
            }
            return (int)res % MOD;
        }
        /*
        nをpow乗する
        */
        private long Pow(long n, long pow)
        {
            long res = 1;
            for (long j = 0; j < pow; j++)
            {
                res *= n;
                res %= MOD;
            }
            return res;
        }
        public int SuperPow(int a, int[] b)
        {
            if (b == null || b.Length == 0)
                return 0;

            a %= MOD;
            long res = 1;
            long n = b.Length;
            /*
            頭から計算していく
            頭を計算して10乗すれば、桁が一つ繰り上がる
            その後、残りのけたをb[i]乗すればよい。
            a ^ ( 10 * i + j ) = a ^ j * ( ( a ^ i ) ^ 10 )
            */
            for (long i = 0; i < n; i++)
            {
                res = Pow(res, 10);
                long pow = Pow(a, b[i]);
                res = res * pow;
                res = res % MOD;
            }
            return (int)res % MOD;
        }
    }
}
