using System;

namespace Day_of_the_Year
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.DayOfYear("2019-01-09"));//9
            Console.WriteLine(solution.DayOfYear("2019-02-10"));//41
            Console.WriteLine(solution.DayOfYear("2003-03-01"));//60
            Console.WriteLine(solution.DayOfYear("2004-03-01"));//61
            Console.WriteLine("Hello World!");
        }
        public int DayOfYear(string date)
        {
            String year = date.Substring(0, 4);
            TimeSpan span = DateTime.Parse(date) - DateTime.Parse(year + "-01-01");
            return span.Days + 1;
        }
    }
}
