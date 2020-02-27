using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solve_the_Equation
{
    class Elm
    {
        public int num;

        public bool onlyNum = true;
        public Elm(string x)
        {
            if (x.Contains('x'))
            {
                onlyNum = false;
                if (x.Replace("+", "").Length == 1)
                    num = 1;
                else if (x.Replace("-", "").Length == 1)
                    num = -1;
                else
                    num = int.Parse(x.Replace("x", ""));
            }
            else
            {
                num = int.Parse(x.Replace("x", ""));
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // Console.WriteLine(program.SolveEquation("x+5-3+x=6+x-2"));// "x=2"
            // Console.WriteLine(program.SolveEquation("x=x"));//  "Infinite solutions"
            // Console.WriteLine(program.SolveEquation("2x=x"));// "x=0"
            Console.WriteLine(program.SolveEquation("2x+3x-6x=x+2"));// "x=-1"
            // Console.WriteLine(program.SolveEquation("x=x+2"));//"No solution"
            Console.WriteLine("Hello World!");
        }
        public string SolveEquation(string equation)
        {
            string[] wk = equation.Split("=");
            //左側分割
            var left = Separate(wk[0]);
            var leftR = Calc(left);
            //右側分割
            var right = Separate(wk[1]);
            var rightR = Calc(right);
            //移項
            int leftResult = leftR.Item2 - rightR.Item2;
            int rightResult = rightR.Item1 - leftR.Item1;
            //-の移項
            if (leftResult < 0)
            {
                leftResult = -leftResult;
                rightResult = -rightResult;
            }
            //約分のため、GCD用意
            int gcd = GetGcd(leftResult, Math.Abs(rightResult));
            leftResult /= gcd;
            rightResult /= gcd;
            //出力
            if (leftResult != 0)
                return ConvResStr(leftResult) + "=" + rightResult;
            else if (leftResult == 0 && rightResult == 0)
                return "Infinite solutions";
            else if (leftResult == 0)
                return "No solution";
            return "";
        }
        //GCD。ただし、0の場合は計算のため1に変換
        private int GetGcd(int a, int b)
        {
            if (b == 0)
                return a == 0 ? 1 : a;
            return GetGcd(b, a % b);
        }
        private string ConvResStr(int n)
        {
            if (n == 1)
                return "x";
            else
                return n + "x";
        }
        //xがついている数と、xがついていない数の集約
        private Tuple<int, int> Calc(List<Elm> elms)
        {
            int num = 0;
            int x = 0;
            foreach (var item in elms)
            {
                if (item.onlyNum)
                    num += item.num;
                else
                    x += item.num;
            }
            return new Tuple<int, int>(num, x);
        }
        //文字を数に分割
        private List<Elm> Separate(string wk)
        {
            List<Elm> res = new List<Elm>();
            int start = 0;
            if (!wk.StartsWith("-") && !wk.StartsWith("+"))
                wk = "+" + wk;
            for (int i = 0; i < wk.Length; i++)
            {
                if (wk[i] == '+' || wk[i] == '-')
                {
                    Convert(wk, i, start, res);
                    start = i;
                }
            }
            if (start != wk.Length)
                Convert(wk, wk.Length, start, res);
            return res;
        }
        //文字を切り出してElmに変換
        private void Convert(string wk, int i, int start, List<Elm> res)
        {
            string tmp = wk.Substring(start, i - start);
            if (tmp != "")
            {
                Elm elm = new Elm(tmp);
                res.Add(elm);
            }
        }
    }
}
