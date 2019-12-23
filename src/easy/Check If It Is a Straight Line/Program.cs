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
            if (coordinates == null || coordinates.Length <= 2)
                return true;

            Array.Sort(coordinates, (a, b) => a[0] < b[0] ? -1 : a[0] == b[0] ? 0 : 1);
            int pX = coordinates[0][0] - coordinates[1][0];
            int pY = coordinates[0][1] - coordinates[1][1];
            if (pX == 0 && pY != 0)
            {
                pX = coordinates[0][0];
                foreach (var item in coordinates)
                {
                    if (item[0] != pX)
                        return false;
                }
                return true;
            }
            else if (pX != 0 && pY == 0)
            {
                pY = coordinates[0][1];
                foreach (var item in coordinates)
                {
                    if (item[1] != pY)
                        return false;
                }
                return true;
            }
            else if (pX == 0 && pY == 0)
            {
                pX = coordinates[0][0];
                pY = coordinates[0][1];
                foreach (var item in coordinates)
                {
                    if (item[0] != pX || item[1] != pY)
                        return false;
                }
                return true;
            }
            Console.WriteLine(" pX/pY : " + pX + "/" + pY);
            int pB = coordinates[0][1] - coordinates[0][0] * pY / pX;
            Console.WriteLine("pB: " + pB);

            foreach (var item in coordinates)
            {
                Console.WriteLine("item[0] *item[1] : " + item[0] + "/" + (item[1]));
                if (item[1] - item[0] * pY / pX - pB != 0.0d)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
