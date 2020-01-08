using System;

namespace Longest_Palindromic_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.LongestPalindrome("babab"));
            Console.WriteLine(program.LongestPalindrome("babad"));
            Console.WriteLine(program.LongestPalindrome("bb"));
            Console.WriteLine(program.LongestPalindrome("cbbd"));
            Console.WriteLine(program.LongestPalindrome("ac"));
            Console.WriteLine(program.LongestPalindrome("a"));
            Console.WriteLine("Hello World!");
        }

        public string LongestPalindromeTLE(string s)
        {
            if (s.Length <= 1)
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

                    if (s[i] != s[j])
                        continue;

                    string wk = palindrome(s.Substring(i, j - i + 1));
                    if (wk.Length > res.Length)
                    {
                        res = wk;
                    }
                }

            }
            return res;
        }
        /*
                    0   1   2   3   4
	                b	a	b	a	b
            0   b	t		t		t
            1   a		t		t	
            2   b			t		t
            3   a				t	
            4   b					t
        */
        public string LongestPalindrome(string s)
        {
            int n = s.Length;
            if (n <= 1)
                return s;
            bool[,] dp = new bool[n, n];

            /*
            1文字は常にtrue
            */
            for (int i = 0; i < n; i++)
                dp[i, i] = true;

            int max = 1;//1文字は常にtrueなので
            int start = 0;//開始位置
            /*
            2文字連続が存在するかの判定
            2文字は別対策
            */
            for (int i = 0; i < n - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    dp[i, i + 1] = true;
                    max = 2;
                    start = i;
                }
            }

            /*
            3文字目から判定開始
            k文字先の値がiの位置の文字と等しいかの判定
            DPテーブル上、i+1とj-1の両方の状況を確認するため
            */
            for (int k = 3; k <= n; k++)
            {
                for (int i = 0; i < n - k + 1; i++)
                {
                    //k文字先の値を確認する
                    int j = i + k - 1;
                    /*
                    i+1 , j-1とは、
                    「新しいiの位置とjの位置の間に挟まれているサブセットが回文かどうかを判定」
                    するためのもの。
                    つまり、
                    dp[1,5]の位置(文字列1-5が回文であるかの判定)のためには、
                    dp[2,4]の位置（文字列2-4が回文であるかの判定）がtrueである必要がある。
                    */
                    if (s[i] == s[j] && dp[i + 1, j - 1])
                    {
                        dp[i, j] = true;
                        if (k > max)
                        {
                            max = k;
                            start = i;
                        }
                    }

                }

            }

            return s.Substring(start, max);
        }


        public string LongestPalindromeDP(string s)
        {

            int n = s.Length;   // get length of input string 

            if (n <= 1)
                return s;
            // table[i][j] will be false if substring str[i..j] 
            // is not palindrome. 
            // Else table[i][j] will be true 
            bool[,] dp = new bool[n, n];

            // All substrings of length 1 are palindromes 
            int max = 1;
            for (int i = 0; i < n; ++i)
                dp[i, i] = true;

            // check for sub-string of length 2. 
            int start = 0;
            for (int i = 0; i < n - 1; ++i)
            {
                if (s[i] == s[i + 1])
                {
                    dp[i, i + 1] = true;
                    start = i;
                    max = 2;
                }
            }

            // Check for lengths greater than 2. k is length 
            // of substring 
            for (int k = 3; k <= n; ++k)
            {

                // Fix the starting index 
                for (int i = 0; i < n - k + 1; ++i)
                {
                    // Get the ending index of substring from 
                    // starting index i and length k 
                    int j = i + k - 1;

                    // checking for sub-string from ith index to 
                    // jth index iff str.charAt(i+1) to  
                    // str.charAt(j-1) is a palindrome 
                    if (dp[i + 1, j - 1] && s[i] == s[j])
                    {
                        dp[i, j] = true;

                        if (k > max)
                        {
                            start = i;
                            max = k;
                        }
                    }
                }
            }
            return s.Substring(start, max);
        }
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
