using System;
using System.Collections.Generic;
using System.Linq;

namespace Decrypt_String_from_Alphabet_to_Integer_Mapping
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.FreqAlphabets("10#11#12"));
            Console.WriteLine("Hello World!");
        }
        public string FreqAlphabets(string s)
        {
            IList<char> wkRes = new List<char>();
            for (int i = s.Length - 1; i >= 0;)
            {
                if (s[i] != '#')
                {
                    wkRes.Add((char)(s[i] - '0' - 1 + 'a'));
                    i--;
                }
                else
                {
                    wkRes.Add((char)((s[i - 2] - '0') * 10 + (s[i - 1] - '0') - 1 + 'a'));
                    i -= 3;
                }
            }
            return new string(wkRes.Reverse().ToArray());
        }
    }
}
