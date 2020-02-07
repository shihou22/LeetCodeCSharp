using System;

namespace Total_Hamming_Distance
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //6
      Console.WriteLine(program.TotalHammingDistance(new int[] { 4, 14, 2 }));
      Console.WriteLine("Hello World!");
    }
    public int TotalHammingDistance(int[] nums)
    {
      int res = 0;
      for (int i = 0; i < 32; i++)
      {
        int cntZero = 0;
        int cntOne = 0;
        for (int j = 0; j < nums.Length; j++)
        {
          if ((nums[j] & 1) == 0)
            cntZero++;
          else
            cntOne++;

          nums[j] >>= 1;
        }
        res += (cntZero * cntOne);
      }
      return res;
    }
  }
}
