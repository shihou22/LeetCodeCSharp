using System.Linq;
using System;
using System.Collections.Generic;

namespace Find_Duplicate_File_in_System
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      Console.WriteLine(program.FindDuplicate(new string[] { "root/a 1.txt(abcd) 2.txt(efgh)", "root/c 3.txt(abcd)", "root/c/d 4.txt(efgh)", "root 4.txt(efgh)" }));
      Console.WriteLine("Hello World!");
    }
    public IList<IList<string>> FindDuplicate(string[] paths)
    {
      IDictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();
      foreach (var item in paths)
      {
        string[] files = item.Split(" ");
        string folder = "";
        int cnt = 0;
        foreach (var item2 in files)
        {
          if (cnt == 0)
          {
            cnt++;
            folder = item2;
            continue;
          }
          string[] f = item2.Replace(")", "").Split("(");
          map.TryAdd(f[1], new List<string>());
          map[f[1]].Add(folder + "/" + f[0]);
        }
      }
      IList<IList<string>> res = new List<IList<string>>();
      foreach (var item in map.Values)
      {
        if (item.Count > 1)
          res.Add(item);
      }
      return res;
    }
  }
}
