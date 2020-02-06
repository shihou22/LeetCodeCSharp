using System;
using System.Text;

namespace Bag_of_Tokens
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //0
            Console.WriteLine(program.BagOfTokensScore(new int[] { 100 }, 50));
            //1
            Console.WriteLine(program.BagOfTokensScore(new int[] { 100, 200 }, 150));
            //2
            Console.WriteLine(program.BagOfTokensScore(new int[] { 100, 200, 300, 400 }, 200));
            Console.WriteLine("Hello World!");
        }
        /*
        方針：Greeedy
        point獲得はpowerが低いほうからとったほうが良い
        pointを捨ててPowerを獲得するのはpowerが高いほうからとったほうが良い
        左右から同時に確認していく。
        まず、powerが低いものからとれるだけpointを獲得する。
        powerが足りなくなったら、pointを一つ捨ててpowerを補う
        補ったpowerで足りるなら、再度powerが低いほうをとってpointを獲得する。
        */
        public int BagOfTokensScore(int[] tokens, int P)
        {
            int n = tokens.Length;
            Array.Sort(tokens);
            int left = 0;
            int right = n - 1;
            int res = 0;
            int points = 0;
            while (left <= right)
            {
                if (P >= tokens[left])
                {
                    P -= tokens[left];
                    left++;
                    points++;
                    res = Math.Max(res, points);
                }
                else if (points > 0)
                {
                    P += tokens[right];
                    right--;
                    points--;
                    res = Math.Max(res, points);
                }
                else
                {
                    break;
                }
            }
            return res;
        }
    }
}

