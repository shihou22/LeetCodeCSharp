using System;
using System.Linq;

namespace Replace_Elements_with_Greatest_Element_on_Right_Side
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int[] ReplaceElements(int[] arr)
        {
            int max = arr[arr.Length - 1];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (max < arr[i])
                {
                    int tmp = arr[i];
                    arr[i] = max;
                    max = tmp;
                }
                else
                {
                    arr[i] = max;
                }
            }
            arr[arr.Length - 1] = -1;
            return arr;
        }
    }
}
