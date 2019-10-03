using System;

namespace First_Bad_Version
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
      private bool IsBadVersion(int version) {
          return true;
      }
      
        public int FirstBadVersion(int n)
        {
            int left = 0;
            int right = n;
            while(left<right) {
                int mid = left + (right-left)/2;
                if (IsBadVersion(mid) ) {
                    right = mid;
                } else {
                    left = mid+1;
                }
            }
            return right;
        }
    }
}
