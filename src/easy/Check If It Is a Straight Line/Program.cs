using System;

namespace Check_If_It_Is_a_Straight_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool CheckStraightLine(int[][] coordinates)
        {
            Array.Sort(coordinates, (a, b) => a[0] < b[0] ? -1 : a[0] == b[0] ? 0 : 1);
            if (coordinates == null || coordinates.Length <= 2)
                return true;
            int pX = Math.Abs(Math.Abs(coordinates[1][0]) - Math.Abs(coordinates[0][0]));
            int pY = Math.Abs(Math.Abs(coordinates[1][1]) - Math.Abs(coordinates[0][1]));
            pX = pX == 0 ? 1 : pX;
            pY = pY == 0 ? 1 : pY;
            // Console.WriteLine("pX/pY : " + pX + "/" + pY);
            for (int i = 2; i < coordinates.Length; i++)
            {
                if ((coordinates[i][0] - coordinates[i - 1][0]) % pX != 0
                || (coordinates[i][1] - coordinates[i - 1][1]) % pY != 0)
                {
                    // Console.WriteLine((coordinates[i][0] - coordinates[i - 1][0]) % pX);
                    // Console.WriteLine((coordinates[i][1] - coordinates[i - 1][1]) % pY);
                    // Console.WriteLine("coordinates[i-1][0]/coordinates[i-1][1] : " + coordinates[i - 1][0] + "/" + coordinates[i - 1][1]);
                    // Console.WriteLine("coordinates[i][0]/coordinates[i][1] : " + coordinates[i][0] + "/" + coordinates[i][1]);
                    return false;
                }
            }
            return true;
        }
    }
}
