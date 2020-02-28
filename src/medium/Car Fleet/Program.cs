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
            // Console.WriteLine(program.CarFleet(12, new int[] { 10, 8, 0, 5, 3 }, new int[] { 2, 4, 1, 1, 3 }));
            //1
            Console.WriteLine(program.CarFleet(10, new int[] { 0, 4, 2 }, new int[] { 2, 1, 3 }));
            Console.WriteLine("Hello World!");
        }
        public int CarFleet(int target, int[] position, int[] speed)
        {
            if (position.Length <= 1)
                return position.Length;

            List<Fleet> fleets = new List<Fleet>();
            for (int i = 0; i < position.Length; i++)
                fleets.Add(new Fleet(position[i], speed[i]));

            //追いつくかの判定ではなく、追いつかれるか？を判定をする。
            fleets.Sort((x, y) =>
            {
                int positionCmp = -(x.Position).CompareTo(y.Position);
                // int positionCmp = (target - x.Position).CompareTo(target - y.Position);
                if (positionCmp != 0)
                    return positionCmp;
                return x.Mile - y.Mile;
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
        public Fleet(int position, int mile)
        {
            this.Position = position;
            this.Mile = mile;
        }
    }
}
