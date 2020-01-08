using System;
using System.Linq;
using System.Collections.Generic;

namespace Letter_Combinations_of_a_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.LetterCombinations("23"));
            Console.WriteLine("Hello World!");
        }
        public IList<string> LetterCombinations(string digits)
        {
            if (digits == "")
                return new List<string>();
            Dictionary<int, List<char>> phone = new Dictionary<int, List<char>>();
            phone.Add(1, new List<char>());
            phone.Add(2, new List<char>() { 'a', 'b', 'c' });
            phone.Add(3, new List<char>() { 'd', 'e', 'f' });
            phone.Add(4, new List<char>() { 'g', 'h', 'i' });
            phone.Add(5, new List<char>() { 'j', 'k', 'l' });
            phone.Add(6, new List<char>() { 'm', 'n', 'o' });
            phone.Add(7, new List<char>() { 'p', 'q', 'r', 's' });
            phone.Add(8, new List<char>() { 't', 'u', 'v' });
            phone.Add(9, new List<char>() { 'w', 'x', 'y', 'z' });
            phone.Add(0, new List<char>() { ' ' });
            IList<string> res = new List<string>();

            helper(res, digits.ToCharArray(), 0, phone, new char[digits.Length]);
            return res;
        }

        private void helper(IList<string> res, char[] dig, int curr, Dictionary<int, List<char>> phone, char[] wkRes)
        {
            if (curr > wkRes.Length - 1)
            {
                res.Add(new string(wkRes));
                return;
            }
            var p = phone[dig[curr] - '0'];
            foreach (var item in p)
            {
                wkRes[curr] = item;
                helper(res, dig, curr + 1, phone, wkRes);
            }
        }

        public IList<string> LetterCombinationsBFS(string digits)
        {
            if (digits == "")
                return new List<string>();
            Dictionary<int, List<char>> phone = new Dictionary<int, List<char>>();
            phone.Add(1, new List<char>());
            phone.Add(2, new List<char>() { 'a', 'b', 'c' });
            phone.Add(3, new List<char>() { 'd', 'e', 'f' });
            phone.Add(4, new List<char>() { 'g', 'h', 'i' });
            phone.Add(5, new List<char>() { 'j', 'k', 'l' });
            phone.Add(6, new List<char>() { 'm', 'n', 'o' });
            phone.Add(7, new List<char>() { 'p', 'q', 'r', 's' });
            phone.Add(8, new List<char>() { 't', 'u', 'v' });
            phone.Add(9, new List<char>() { 'w', 'x', 'y', 'z' });
            phone.Add(0, new List<char>() { ' ' });

            Queue<IList<char>> queue = new Queue<IList<char>>();
            char[] wk = digits.ToCharArray();
            foreach (var item in phone[wk[0] - '0'])
            {
                queue.Enqueue(new List<char>() { item });
            }
            for (int i = 1; i < wk.Length; i++)
            {
                int cnt = queue.Count;
                for (int j = 0; j < cnt; j++)
                {
                    IList<char> tmp = queue.Dequeue();
                    foreach (var item in phone[wk[i] - '0'])
                    {
                        queue.Enqueue(new List<char>(tmp) { item });
                    }
                }
            }
            IList<string> res = new List<string>();
            while (queue.Count > 0)
            {
                IList<char> tmp = queue.Dequeue();
                res.Add(new string(tmp.ToArray()));
            }
            return res;
        }
    }
}
