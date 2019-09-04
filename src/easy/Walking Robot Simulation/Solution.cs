using System;
using System.Collections.Generic;

namespace Walking_Robot_Simulation
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[][] obs = new int[1][];
            obs[0] = new int[] { 2, 4 };
            int a = solution.RobotSim(new int[] { 4, -1, 4, -2, 4 }, obs);
            Console.WriteLine("Hello World!");
        }
        public int RobotSim(int[] commands, int[][] obstacles)
        {
            Dictionary<int, HashSet<int>> obs = new Dictionary<int, HashSet<int>>();
            foreach (var item in obstacles)
            {
                if (!obs.ContainsKey(item[0]))
                {
                    HashSet<int> wk = new HashSet<int>();
                    obs.Add(item[0], wk);
                }
                obs[item[0]].Add(item[1]);
            }
            int x = 0;
            int y = 0;
            int d = 1;
            int max = 0;
            for (int i = 0; i < commands.Length; i++)
            {
                int ci = commands[i];
                if (ci == -1 || ci == -2)
                {
                    d = Rotate(d, ci);
                }
                else
                {
                    for (int j = 0; j < ci; j++)
                    {
                        switch (d)
                        {
                            case 1:
                                y += 1;
                                break;
                            case 2:
                                x += 1;
                                break;
                            case 3:
                                y -= 1;
                                break;
                            case 4:
                                x -= 1;
                                break;
                            default:
                                break;
                        }
                        if (obs.ContainsKey(x) && obs[x].Contains(y))
                        {
                            // Console.WriteLine(x.ToString() + " - " + y.ToString());
                            switch (d)
                            {
                                case 1:
                                    y -= 1;
                                    break;
                                case 2:
                                    x -= 1;
                                    break;
                                case 3:
                                    y += 1;
                                    break;
                                case 4:
                                    x += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                    }
                }
                max = Math.Max((int)Math.Pow(x, 2) + (int)Math.Pow(y, 2), max);
                Console.WriteLine(x.ToString() + " - " + y.ToString());
            }
            return max;
        }
        private int Rotate(int x, int d)
        {

            if (d == -2)
            {
                if (x <= 1)
                    return 4;
                else
                    return x - 1;

            }
            else if (d == -1)
            {
                if (x >= 4)
                    return 1;
                else
                    return x + 1;
            }
            return 0;
        }
    }
}
