using System;
using System.Text;
using System.Collections.Generic;

namespace Reverse_Words_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //"blue is sky the"
            Console.WriteLine(program.ReverseWords("the sky is blue"));
            //"world! hello"
            Console.WriteLine(program.ReverseWords("  hello world!  "));
            //"example good a"
            Console.WriteLine(program.ReverseWords("a good   example"));
            Console.WriteLine("Hello World!");
        }
        public string ReverseWords(string s)
        {
            string[] wk = s.Trim().Split(" ");
            StringBuilder builder = new StringBuilder();
            for (int i = wk.Length - 1; i >= 0; i--)
            {
                if (i != 0 && wk[i] != "")
                {
                    builder.Append(wk[i] + " ");
                }
                else
                {
                    builder.Append(wk[i]);
                }

            }
            return builder.ToString();
        }
    }
}
