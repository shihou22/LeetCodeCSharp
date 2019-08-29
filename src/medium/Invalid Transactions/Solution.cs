using System;
using System.Collections.Generic;

namespace Invalid_Transactions
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            IList<string> res = null;
            //["alice,20,800,mtv","alice,50,100,beijing"]
            // res = solution.InvalidTransactions(new string[] { "alice,20,800,mtv", "alice,50,100,beijing" });
            //["bob,50,1200,mtv"]
            // res = solution.InvalidTransactions(new string[] { "alice,20,800,mtv", "bob,50,1200,mtv" });
            //["bob,689,1910,barcelona","bob,832,1726,barcelona","bob,820,596,bangkok"]
            // res = solution.InvalidTransactions(new string[] { "bob,689,1910,barcelona", "alex,696,122,bangkok", "bob,832,1726,barcelona", "bob,820,596,bangkok", "chalicefy,217,669,barcelona", "bob,175,221,amsterdam" });
            //["bob,627,1973,amsterdam","alex,387,885,bangkok","alex,355,1029,barcelona"]
            res = solution.InvalidTransactions(new string[] { "bob,627,1973,amsterdam", "alex,387,885,bangkok", "alex,355,1029,barcelona", "alex,587,402,bangkok", "chalicefy,973,830,barcelona", "alex,932,86,bangkok", "bob,188,989,amsterdam" });

            Console.WriteLine("Hello World!");
        }
        private class Transaction
        {
            public string name { get; }
            public int time { get; }
            public int cost { get; }
            public string city { get; }
            public string transtr { get; set; }

            public Transaction(string name, string time, string cost, string city)
            {
                this.name = name;
                this.time = int.Parse(time);
                this.cost = int.Parse(cost);
                this.city = city;
                this.transtr = name + "," + time.ToString() + "," + cost.ToString() + "," + city;
            }
        }
        public IList<string> InvalidTransactions(string[] transactions)
        {
            HashSet<string> res = new HashSet<string>();
            Dictionary<string, IList<Transaction>> memo = new Dictionary<string, IList<Transaction>>();
            foreach (var item in transactions)
            {
                string[] tmp = item.Split(",");
                Transaction tran = new Transaction(tmp[0], tmp[1], tmp[2], tmp[3]);
                if (tran.cost >= 1000)
                {
                    res.Add(tran.transtr);
                }
                if (memo.ContainsKey(tran.name))
                {
                    IList<Transaction> trans = memo[tran.name];
                    foreach (var elmT in trans)
                    {
                        if ((elmT.time - 60 <= tran.time && tran.time <= elmT.time + 60) && elmT.city != tran.city)
                        {
                            res.Add(elmT.transtr);
                            res.Add(tran.transtr);
                        }
                    }
                    memo[tran.name].Add(tran);
                }
                else
                {
                    memo.Add(tran.name, new List<Transaction>() { tran });
                }

            }
            return new List<string>(res);
        }
    }
}
