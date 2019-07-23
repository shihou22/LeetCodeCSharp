using System;
using System.Text;

namespace Goat_Latin
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public string ToGoatLatin(string S)
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder aBuilder = new StringBuilder();
            int cnt = 1;
            foreach (var item in S.Split(" "))
            {
                aBuilder.Append("a");
                if (cnt != 1)
                    builder.Append(" ");

                var top = item[0];
                switch (top)
                {
                    case 'a':
                    case 'i':
                    case 'u':
                    case 'e':
                    case 'o':
                    case 'A':
                    case 'I':
                    case 'U':
                    case 'E':
                    case 'O':
                        builder.Append(item);
                        break;
                    default:
                        builder.Append(item.Substring(1));
                        builder.Append(top);
                        break;
                }
                builder.Append("ma");
                builder.Append(aBuilder.ToString());
                cnt++;
            }
            return builder.ToString();
        }
    }
}
