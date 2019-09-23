using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System;

namespace Subdomain_Visit_Count
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public IList<string> SubdomainVisits(string[] cpdomains)
    {
      Dictionary<string, int> map = new Dictionary<string, int>();
      foreach (var item in cpdomains)
      {
        string[] f = item.Split(" ");
        int num = int.Parse(f[0]);
        string[] d = f[1].Split(".");
        string wk = "";
        for (int i = d.Length - 1; i >= 0; i--)
        {
          wk = wk.Equals("") ? d[i] : d[i] + "." + wk;
          if (map.ContainsKey(wk))
            map[wk] += num;
          else
            map.Add(wk, num);
        }
      }
      IList<string> res = new List<string>();
      foreach (var item in map)
      {
        res.Add(item.Value + " " + item.Key);
      }
      return res;
    }
  }
}
