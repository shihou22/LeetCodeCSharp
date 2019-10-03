using System;

namespace Largest_Time_for_Given_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // Console.WriteLine(program.LargestTimeFromDigits(new int[] { 1, 2, 3, 4 }));
            // Console.WriteLine(program.LargestTimeFromDigits(new int[] { 0, 4, 0, 0 }));
            // Console.WriteLine(program.LargestTimeFromDigits(new int[] { 1, 2, 5, 9 }));
            // Console.WriteLine(program.LargestTimeFromDigits(new int[] { 2, 3, 5, 9 }));
            // Console.WriteLine(program.LargestTimeFromDigits(new int[] { 2, 9, 0, 0 }));
            Console.WriteLine(program.LargestTimeFromDigits(new int[] { 2, 0, 6, 6 }));
            Console.WriteLine("Hello World!");
        }
        public string LargestTimeFromDigits(int[] A)
        {
            GetMaxFast(A, 0, new bool[4], 0);
            string res = timeMaxInt == -1 ? "" :  String.Format("{0:00}", timeMaxInt / 100) + ":" + String.Format("{0:00}", timeMaxInt % 100);
            return res;
        }
        private int timeMaxInt = -1;
        private void GetMaxFast(int[] A, int curr, bool[] visited, int time)
        {

            if (curr == 4)
            {
                if (time / 100 > 23 || time % 100 > 59)
                    return;
                timeMaxInt = Math.Max(timeMaxInt, time);
                return;
            }
            for (int i = 0; i < A.Length; i++)
            {
                if (visited[i])
                    continue;
                visited[i] = true;
                GetMaxFast(A, curr + 1, visited, time * 10 + A[i]);
                visited[i] = false;
            }
        }
        public string LargestTimeFromDigitsSlow(int[] A)
        {
            GetMax(A, 0, new bool[4], "");
            return timeMax;
        }
        string timeMax = "";
        private void GetMax(int[] A, int curr, bool[] visited, string time)
        {

            if (curr == 2)
                time += ":";

            if (curr == 4)
            {
                if (timeMax.Equals(""))
                {
                    try
                    {
                        DateTime dateTime = DateTime.Parse(time);
                        timeMax = time;
                    }
                    catch (System.Exception)
                    {
                        // Console.WriteLine(time);
                    }
                }
                else
                {
                    try
                    {
                        DateTime dateTime = DateTime.Parse(time);
                        if (dateTime.CompareTo(DateTime.Parse(timeMax)) > 0)
                        {
                            timeMax = time;
                        }
                    }
                    catch (System.Exception)
                    {
                        // Console.WriteLine(time);
                    }
                }
                return;
            }
            for (int i = 0; i < A.Length; i++)
            {
                if (visited[i])
                    continue;
                visited[i] = true;
                GetMax(A, curr + 1, visited, time + A[i]);
                visited[i] = false;
            }

        }
    }
}
