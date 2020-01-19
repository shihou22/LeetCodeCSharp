using System;
using System.Linq;
using System.Collections.Generic;

namespace Repeated_DNA_Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //["AAAAACCCCC", "CCCCCAAAAA"]
            var res1 = program.FindRepeatedDnaSequences("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT");
            Console.WriteLine("Hello World!");
        }

        public IList<string> FindRepeatedDnaSequences(string s)
        {
            IList<string> res = new List<string>();
            ISet<string> memo = new HashSet<string>();

            if (s == "")
                return res;

            for (int i = 0; i < s.Length - 9; i++)
            {
                string wk = s.Substring(i, 10);
                if (memo.Contains(wk))
                    res.Add(wk);
                else
                    memo.Add(wk);
            }
            return new List<string>(res.Distinct());
        }
    }
}
