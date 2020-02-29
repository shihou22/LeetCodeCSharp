using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Letter_Tile_Possibilities
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //8
            Console.WriteLine(program.NumTilePossibilities("AAB"));
            //188
            Console.WriteLine(program.NumTilePossibilities("AAABBC"));
            Console.WriteLine("Hello World!");
        }
        public int NumTilePossibilities(string tiles)
        {
            return DFS(tiles).Count;
        }
        public ISet<string> DFS(string tiles)
        {
            ISet<string> res = new HashSet<string>();

            if (tiles.Length == 0)
                return res;
            for (int i = 0; i < tiles.Length; i++)
            {
                char c = tiles[i];
                res.Add(c.ToString());
                string rest = tiles.Remove(i, 1);
                ISet<string> resultAux = DFS(rest);
                foreach (var item in resultAux)
                {
                    string newTile = c + item;
                    res.Add(newTile);
                }
            }
            return res;
        }
    }
}