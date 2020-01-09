using System;
using System.Linq;
using System.Collections.Generic;

namespace Find_Smallest_Letter_Greater_Than_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public char NextGreatestLetter(char[] letters, char target)
        {
            return LowerBound(letters, target, Comparer<char>.Default);
        }
        public T LowerBound<T>(T[] a, T v, Comparer<T> comp)
        {
            var left = 0;
            var right = a.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                var val = comp.Compare(a[mid], v);
                if (val <= 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return left > a.Length - 1 ? a[0] : a[left];
        }
    }
}
