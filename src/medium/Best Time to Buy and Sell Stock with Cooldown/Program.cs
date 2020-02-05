using System;

namespace Best_Time_to_Buy_and_Sell_Stock_with_Cooldown
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //3
            Console.WriteLine(program.MaxProfit(new int[] { 1, 2, 3, 0, 2 }));
            Console.WriteLine("Hello World!");
        }
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0)
                return 0;
            if (prices.Length == 0) return 0;
            int hold = -prices[0], cash = 0, cool = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                int hold2 = Math.Max(hold, cool - prices[i]);
                int cash2 = Math.Max(cash, hold + prices[i]);
                cool = cash;
                hold = hold2;
                cash = cash2;
            }
            return cash;
        }
    }
}
