using System;
using System.Linq;
using System.Text;

namespace Push_Dominoes
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //"LL.RR.LLRRLL.."
            Console.WriteLine(program.PushDominoes(".L.R...LR..L.."));
            //"RR.L"
            Console.WriteLine(program.PushDominoes("RR.L"));
            // //"LL.RR"
            Console.WriteLine(program.PushDominoes(".L.R."));
            // //"LR"
            Console.WriteLine(program.PushDominoes("LR"));
            // //"RRR.L"
            Console.WriteLine(program.PushDominoes("R.R.L"));
            Console.WriteLine("Hello World!");
        }
        public string PushDominoes(string dominoes)
        {
            char[] toward = dominoes.ToCharArray();
            int[] towardRight = new int[dominoes.Length];
            int[] towardLeft = new int[dominoes.Length];
            int n = dominoes.Length;
            for (int i = 0; i < n; i++)
            {
                towardRight[i] = toward[i] == 'R' ? 1 : 0;
                towardLeft[n - 1 - i] = toward[n - 1 - i] == 'L' ? -1 : 0;
                if (i != 0)
                {
                    if (toward[i] == '.' && towardRight[i - 1] > 0)
                        towardRight[i] = towardRight[i - 1] + 1;
                    if (toward[n - 1 - i] == '.' && towardLeft[n - i] < 0)
                        towardLeft[n - 1 - i] = towardLeft[n - i] - 1;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (toward[i] != '.')
                    continue;
                if (towardRight[i] > 0 && towardLeft[i] < 0)
                {
                    int tmp = towardRight[i] + towardLeft[i];
                    if (tmp > 0)
                        toward[i] = 'L';
                    else if (tmp < 0)
                        toward[i] = 'R';
                }
                else if (towardRight[i] > 0)
                    toward[i] = 'R';
                else if (towardLeft[i] < 0)
                    toward[i] = 'L';
            }

            return new string(toward);
        }
    }
}
