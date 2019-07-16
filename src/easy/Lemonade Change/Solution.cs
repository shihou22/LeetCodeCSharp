using System;

namespace Lemonade_Change
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            // solution.LemonadeChange(new int[] { 5, 5, 10, 10, 20 });
            solution.LemonadeChange(new int[] { 5, 5, 5, 10, 5, 5, 10, 20, 20, 20 });
            Console.WriteLine("Hello World!");
        }

        public bool LemonadeChange(int[] bills)
        {
            int five = 0;
            int ten = 0;
            for (int i = 0; i < bills.Length; i++)
            {
                switch (bills[i])
                {
                    case 5:
                        five++;
                        break;
                    case 10:
                        if (five == 0)
                        {
                            return false;
                        }
                        five--;
                        ten++;
                        break;
                    case 20:
                        if (ten > 0 && five > 0)
                        {
                            five--;
                            ten--;
                        }
                        else if (five > 2)
                        {
                            five -= 3;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                }
            }
            return true;
        }

        public bool LemonadeChangeOld(int[] bills)
        {
            // int[] bill = new int[3];
            int five = 0;
            int ten = 0;
            foreach (var item in bills)
            {
                switch (item)
                {
                    case 5:
                        // bill[0]++;
                        five++;
                        break;
                    case 10:
                        if (five > 0)// if (bill[0] > 0)
                        {
                            five--;//bill[0]--;
                            ten++;//bill[1]++;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case 20:
                        if (ten > 0 && five > 0) //if (bill[1] > 0 && bill[0] > 0)
                        {
                            five--;//bill[0]--;
                            ten--;//bill[1]--;
                        }
                        else if (ten == 0 && five > 2)//else if (bill[1] == 0 && bill[0] > 2)
                        {
                            five -= 3;//bill[0] -= 3;
                        }
                        else
                        {
                            return false;
                        }
                        // bill[2]++;
                        break;
                }
            }
            return true;
        }
    }
}
