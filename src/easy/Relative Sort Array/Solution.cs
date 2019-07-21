using System.Collections.Generic;
using System;

namespace Relative_Sort_Array
{
  class Solution
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public int[] RelativeSortArray(int[] arr1, int[] arr2)
    {
      SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
      foreach (var item in arr1)
      {
        if (dict.ContainsKey(item))
          dict[item]++;
        else
          dict.Add(item, 1);
      }

      var index = 0;
      foreach (var item in arr2)
      {
        var num = dict[item];
        for (int i = 0; i < num; i++)
        {
          arr1[index] = item;
          index++;
        }
        dict.Remove(item);
      }
      foreach (var item in dict)
      {
        for (int i = 0; i < item.Value; i++)
        {
          arr1[index] = item.Key;
          index++;
        }
      }
      return arr1;
    }
  }
}
