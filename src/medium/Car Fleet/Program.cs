using System;
using System.Linq;
using System.Collections.Generic;

namespace Car_Fleet
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //3
            Console.WriteLine(program.CarFleet(12, new int[] { 10, 8, 0, 5, 3 }, new int[] { 2, 4, 1, 1, 3 }));
            Console.WriteLine("Hello World!");
        }
        public int CarFleet(int target, int[] position, int[] speed)
        {
            if (position.Length <= 1)
                return position.Length;

            List<Fleet> fleets = new List<Fleet>();
            for (int i = 0; i < position.Length; i++)
                fleets.Add(new Fleet(position[i], speed[i], i));

            fleets.Sort((x, y) =>
            {
                if (x.Position == y.Position)
                    return x.Mile - y.Mile;
                else
                    return x.Position - y.Position;
            });
            int res = fleets.Count;
            for (int i = 0; i < fleets.Count - 1; i++)
            {
                //前後の差分
                var posDiff = fleets[i].Position - fleets[i + 1].Position;
                var speedDiff = fleets[i + 1].Mile - fleets[i].Mile;
                //速度差がない==追いつかない
                if (speedDiff == 0)
                    continue;
                //差分のspeed
                double time = ((double)posDiff) / speedDiff;
                //後ろのほうが遅い||targetより大きくなってしまう
                if (time < 0 || time * fleets[i].Mile + fleets[i].Position > target)
                    continue;
                // 同じだった
                fleets[i + 1] = fleets[i];
                res--;
            }

            return res;
        }
    }
    class Fleet
    {
        public int Position;
        public int Mile;
        List<int> Idx;
        public Fleet(int position, int mile, int idx)
        {
            this.Position = position;
            this.Mile = mile;
            this.Idx = new List<int>() { idx };
        }
    }
}
