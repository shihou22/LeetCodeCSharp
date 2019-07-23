using System;
using System.Text;

namespace Defanging_an_IP_Address
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public string DefangIPaddr(string address)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in address)
            {
                if (item == '.')
                    builder.Append("[.]");
                else
                    builder.Append(item);
            }
            return builder.ToString();
        }
        public string DefangIPaddrReplace(string address)
        {
            return address.Replace(".", "[.]");
        }
    }
}
