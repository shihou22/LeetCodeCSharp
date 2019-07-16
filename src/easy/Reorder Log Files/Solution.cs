using System;
using System.Collections.Generic;
using System.Linq;

namespace Reorder_Log_Files
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Solution().ReorderLogFiles(new string[] { "a1 9 2 3 1", "g1 act car", "zo4 4 7", "ab1 off key dog", "a8 act zoo" });
        }

        public string[] ReorderLogFiles(string[] logs)
        {
            List<string> listn = new List<string>();
            List<string> list = new List<string>();
            foreach (var s in logs)
            {
                String[] split1 = s.Split(' ');
                long l1;
                // bool digit1 = long.TryParse(split1[1], out l1);longであふれるので意味がない
                // Console.WriteLine(split1[1] + " / " + digit1 + " / " + split1[1].All(Char.IsDigit));
                if (split1[1].All(Char.IsDigit))　//allで一文字ずつ精査している
                // if (digit1) こちらだと桁あふれする
                {
                    listn.Add(s);
                }
                else
                {
                    list.Add(s);
                }
            }
            list.Sort(delegate (string x, string y)
            {
                int result;
                String s1 = x.Substring(x.IndexOf(' ') + 1);
                String s2 = y.Substring(y.IndexOf(' ') + 1);

                result = s1.CompareTo(s2);

                if (result == 0)
                {
                    result = x.CompareTo(y);
                }
                return result;
            }
            );
            return list.Concat(listn).ToList().ToArray();
        }
    }
}
