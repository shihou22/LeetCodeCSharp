using System;

namespace Longest_Palindromic_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.LongestPalindrome("babad"));
            Console.WriteLine(program.LongestPalindrome("bb"));
            Console.WriteLine(program.LongestPalindrome("cbbd"));
            Console.WriteLine(program.LongestPalindrome("ac"));
            Console.WriteLine("Hello World!");
        }

        public string LongestPalindrome(string s)
        {
            if (s.Length == 1)
                return s;

            string res = "";
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s.Length - 1 - i < res.Length)
                    break;
                for (int j = s.Length - 1; j >= i; j--)
                {
                    if (j - i < res.Length)
                        break;

                    if (s[i] == s[j])
                    {
                        string wk = palindrome(s.Substring(i, j - i + 1));
                        if (wk.Length > res.Length)
                        {
                            res = wk;
                        }
                    }

                }

            }
            return res;
        }
        // public string LongestPalindrome(string s)
        // {
        //     int len = s.Length - 1;
        //     int left = 0;
        //     int right = left;
        //     int range = s.Length / 2;
        //     while (len - left > 1)
        //     {
        //         while (right < len && left + range < right + 1)
        //         {

        //         }
        //     }
        // }
        private string palindrome(string s)
        {
            bool isPalindrome = true;
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }
            return isPalindrome ? s : "";
        }
    }
}
