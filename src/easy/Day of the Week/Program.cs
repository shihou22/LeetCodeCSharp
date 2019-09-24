using System;

namespace Day_of_the_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public string DayOfTheWeek(int day, int month, int year)
        {
            var theDay = new DateTime(year, month, day);
            // string dayLong = string.Format("{0:dddd}", theDay);
            // return dayLong;
            return theDay.DayOfWeek.ToString();
        }
    }
}
