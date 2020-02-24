using System;

namespace Number_of_Days_Between_Two_Dates
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      Console.WriteLine(program.DaysBetweenDates("2019-06-29", "2019-06-30"));//1
      Console.WriteLine(program.DaysBetweenDates("2020-01-15", "2019-12-31"));//15
      Console.WriteLine("Hello World!");
    }
    public int DaysBetweenDates(string date1, string date2)
    {
      DateTime d1 = DateTime.Parse(date1);
      DateTime d2 = DateTime.Parse(date2);
      switch (d1.CompareTo(d2))
      {
        case 0:
          return 0;
        case 1:
          return (d1 - d2).Days;
        case -1:
          return (d2 - d1).Days;
      }
      return -1;
    }
  }
}
