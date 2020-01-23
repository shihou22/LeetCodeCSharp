using System;
using System.Text;
using System.Collections.Generic;

namespace Remove_K_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.RemoveKdigits("1432219", 3));//1219
            Console.WriteLine(program.RemoveKdigits("10200", 1));//200
            Console.WriteLine(program.RemoveKdigits("10", 2));//0
            Console.WriteLine("Hello World!");
        }

        public String RemoveKdigits(string num, int k)
        {
            string ans = helper(num, k);
            return ans.Length == 0 ? "0" : ans.ToString();
        }

        private string helper(string str, int k)
        {
            if (k >= str.Length)
                return "";
            if (k == 0)
                return str;
            int i = 0;
            //左から最初のピークを削除していく
            while (i < str.Length - 1 && str[i] <= str[i + 1])
                i++;
            //頂点削除
            str = str.Remove(i, 1);
            //trim
            while (str.Length > 0 && str[0] == '0')
                str = str.Remove(0, 1);
            return helper(str, k - 1);
        }

        public string RemoveKdigitsTLEDFS(string num, int k)
        {
            return Helper(num, k, 0, new List<char>());
        }
        private string Helper(string num, long k, int curr, List<char> wk)
        {
            if (k == 0)
            {
                string tmp = new string(wk.ToArray()) + num.Substring(curr);
                // Console.WriteLine(tmp);
                return tmp;
            }
            else if (curr >= num.Length)
            {
                return num;
            }
            wk.Add(num[curr]);
            string res1 = trim(Helper(num, k, curr + 1, wk), num);
            wk.RemoveAt(wk.Count - 1);
            string res2 = trim(Helper(num, k - 1, curr + 1, wk), num);
            return GetMin(res1, res2);
        }
        private string GetMin(string res1, string res2)
        {
            if (res1.Length > res2.Length)
            {
                return res2;
            }
            else if (res1.Length < res2.Length)
            {
                return res1;
            }
            else
            {
                return res1.CompareTo(res2) > 0 ? res2 : res1;
            }
        }
        private string trim(string wk, string max)
        {

            int cnt = 0;
            foreach (var item in wk)
            {
                if (item != '0')
                    break;
                cnt++;
            }
            if (cnt != 0 && wk.Length != cnt)
                return wk.Substring(cnt);
            if (wk.Length == cnt)
                return "0";
            return wk;
        }
    }
}
