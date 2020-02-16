using System.Collections.Generic;
using System;
using System.Linq;

namespace Check_If_N_and_Its_Double_Exist
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //false
      Console.WriteLine(program.CheckIfExist(new int[] { -2, 0, 10, -19, 4, 6, -8 }));
      //true
      Console.WriteLine(program.CheckIfExist(new int[] { 0, 0 }));
      Console.WriteLine("Hello World!");
    }
    public bool CheckIfExist(int[] arr)
    {
      HashSet<int> set = new HashSet<int>();
      int zero = 0;
      foreach (var item in arr)
      {
        if (item == 0)
          zero++;
        set.Add(item);
      }
      foreach (var item in set.OrderBy(x => x))
      {
        if (item != 0 && set.Contains(item * 2))
          return true;
        else if (item == 0 && zero > 1)
          return true;
      }
      return false;
    }
    public bool CheckIfExistSlow(int[] arr)
    {
      var group = arr.GroupBy(x => x);
      var set = arr.ToHashSet();
      foreach (var item in group.OrderBy(x => x.Key))
      {
        if (item.Key != 0 && set.Contains(item.Key * 2) || item.Key == 0 && item.Count() > 1)
          return true;
      }
      return false;
    }
  }
}
