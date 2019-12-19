using System;

namespace Minimum_Time_Visiting_All_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MinTimeToVisitAllPoints(int[][] points)
        {
            int sec = 0;
            int pR = points[0][0];
            int pC = points[0][1];
            for (int i = 1; i < points.Length; i++)
            {
                int wkR = Math.Abs(Math.Min(pR, points[i][0]) - Math.Max(pR, points[i][0]));
                pR = points[i][0];
                int wkC = Math.Abs(Math.Min(pC, points[i][1]) - Math.Max(pC, points[i][1]));
                pC = points[i][1];
                Console.WriteLine(pR + "/" + pC);

                int max = Math.Max(wkR, wkC);
                sec += max;
            }
            return sec;
        }
    }
}
