using System;

namespace Divide_Two_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            Program solution = new Program();
            // Console.WriteLine(solution.Divide(100, 20));//5
            // Console.WriteLine(solution.Divide(100, 100));//1
            // Console.WriteLine(solution.Divide(10, 3));//3
            // Console.WriteLine(solution.Divide(7, -3));//-2
            // Console.WriteLine(solution.Divide(1, 1));//1
            Console.WriteLine(solution.Divide(-2147483648, -1));//1
            Console.WriteLine("Hello World!");
        }
        public int Divide(int dividend, int divisor)
        {
            return (int)divide2(dividend, divisor);
        }
        private bool equal(long a, long b)
        {
            return (a ^ b) == 0;
        }
        private bool notEqual(long a, long b)
        {
            return (a ^ b) > 0;
        }

        /*
        https://qiita.com/ruuuuuuuty/items/a8edf4c22f56b5456994#%E5%8A%A0%E7%AE%97ab
         */
        private long add(long a, long b)
        {
            if (equal(b, 0))
                return a;

            /*
            (a ^ b) => XOR なので、繰り上がりなしの足し算となる
            (a & b) => AND なので、繰り上がり対象の桁がわかる
            (a & b)<<1 => 繰り上がり対象の桁を1桁ずらす→足し込む先の桁にずらす
            上記を再帰で実施すれば足せる。
            足した結果、繰り上がりがなくなれば終了
            */
            return add(a ^ b, ((a & b) << 1));
        }

        /*
        https://qiita.com/ruuuuuuuty/items/a8edf4c22f56b5456994#%E6%B8%9B%E7%AE%97a-b
        補数を考える
         */
        private long subtract1(long a, long b)
        {
            //補数の求め方は、bitを反転させて+1すればよい
            long comp = add(~b, 1);
            //補数を加算する
            return add(a, comp);
            //add(a,-b)
        }

        private bool greaterThan(long a, long b)
        {
            //同じならfalse
            // if (equal(a, b)) return false;
            // a>b なら、a-b > 0
            long sub = subtract1(a, b);
            //32bit目が0なら>0、1なら<0
            return equal(sub >> 31, 0);
        }
        private bool lessThan(long a, long b)
        {
            return greaterThan(b, a);
        }
        private long ter(bool cond, long a, long b)
        {
            if (cond) return a;
            return b;
        }


        private long divide2(long a, long b)
        {
            if (a == int.MinValue && b == -1)
            {
                return int.MaxValue;
            }
            bool isMinus = false;
            if (a < 0 && b < 0)
            {
                a = -a;
                b = -b;
            }
            else if (a < 0)
            {
                a = -a;
                isMinus = true;
            }
            else if (b < 0)
            {
                b = -b;
                isMinus = true;
            }
            if (equal(b, 0)) throw new Exception("Divide by zero");
            long originalB = b;
            long cnt = 1;
            long quotient = 0;
            while (greaterThan(a, b))
            {
                b <<= 1;
                if (greaterThan(a, b))
                    cnt <<= 1;
                else
                {
                    b >>= 1;
                    quotient = add(quotient, cnt);
                    cnt = 1;
                    a = subtract1(a, b);
                    b = originalB;
                }
            }
            return ter(isMinus, -quotient, quotient);
        }
        /*
        */
        private long divide(long a, long b)
        {
            if (equal(b, 0)) throw new Exception("Divide by zero");
            long originalB = b;
            long c = 1;
            long q = 0;
            while (greaterThan(a, b))
            {
                //割る数を2の累乗で調べていく
                b <<= 1;
                /*
                割れる限り（割られる数を割る数がうわまらない限り）1->2->4->8とシフトする
                2であれば、2->4->8->16 ...
                8で割れて16で割れない（割られる数より大きくなった）時は、
                2×4で割れるということなので、+4
                */
                if (greaterThan(a, b)) c <<= 1;
                else
                {
                    /*
                    累乗による割る数の調査限界
                    qにcを足す
                    */
                    q = add(q, c);
                    //cはreset
                    c = 1;
                    //累乗しすぎたので1段階戻す
                    b >>= 1;
                    /*
                    a-bをすることによって、aから現在の最大のbを引く
                    15/2 であれば、15-8=7 とする
                    */
                    a = subtract1(a, b);
                    //bが8になってしまっているのでoriginalに戻す
                    b = originalB;
                }
            }
            return q;
        }
        private long quotient(long a, long b)
        {
            return subtract1(a, divide(a, b));
        }

        /*
        12 -> 1100
        13 -> 1101

        1:  1&1=1 -> 0+12 = 12
        110(6) 11000(24)
        2:  0&1=0 -> 12+0 = 12
        11(3) 110000(48)
        3:  1&1=1 -> 12 + 48 = 60
        1(1) 1100000(96)
        4:  1&1=1 -> 60 + 96 = 156
        0(0) 11000000(192)
        5:  b==0 return

        */
        private long multiply(long a, long b)
        {
            if (lessThan(a, 0)) return subtract1(0, multiply(-a, b));
            if (lessThan(b, 0)) return subtract1(0, multiply(a, -b));
            long res = 0;
            while (notEqual(b, 0))
            {
                res = add(res, ter((b & 1) == 1, a, 0));
                b >>= 1;
                a <<= 1;
            }
            return res;
        }

    }
}
