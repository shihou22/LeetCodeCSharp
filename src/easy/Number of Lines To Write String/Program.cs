using System;

namespace Number_of_Lines_To_Write_String
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      // [3, 60]
      Console.WriteLine(program.NumberOfLines(new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, "abcdefghijklmnopqrstuvwxyz"));
      //[2, 4]
      Console.WriteLine(program.NumberOfLines(new int[] { 4, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, "bbbcccdddaaa"));
      Console.WriteLine("Hello World!");
    }
    public int[] NumberOfLines(int[] widths, string S)
    {
      const int MAX = 100;
      int wk = MAX;
      int line = 1;
      foreach (var item in S)
      {
        int no = item - 'a';
        int len = widths[no];
        if (wk < len)
        {
          wk = MAX;
          line++;
        }
        wk -= len;
      }
      return new int[] { line, MAX - wk };
    }
  }
}
