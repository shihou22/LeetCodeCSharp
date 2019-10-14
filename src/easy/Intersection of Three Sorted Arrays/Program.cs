using System.Linq;
using System.Collections.Generic;
using System;

namespace Intersection_of_Three_Sorted_Arrays
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public IList<int> ArraysIntersection(int[] arr1, int[] arr2, int[] arr3)
    {
      IList<int> list = new List<int>();
      int i = 0;
      int j = 0;
      int k = 0;

      while (i < arr1.Length && j < arr2.Length && k < arr3.Length)
      {
        if (arr1[i] == arr2[j] && arr1[i] == arr3[k])
        {
          list.Add(arr1[i]);
          i++;
          j++;
          k++;
        }
        else
        {
          int min = Math.Min(arr1[i], Math.Min(arr2[j], arr3[k]));
          if (arr1[i] == min)
            i++;
          else if (arr2[j] == min)
            j++;
          else if (arr3[k] == min)
            k++;
        }
      }
      return list;
    }
    public IList<int> ArraysIntersectionHash(int[] arr1, int[] arr2, int[] arr3)
    {
      SortedSet<int> res = new SortedSet<int>();
      foreach (var item in arr1)
      {
        res.Add(item);
      }
      foreach (var item in res.ToArray())
      {
        if (!arr2.Contains(item))
          res.Remove(item);
      }
      foreach (var item in res.ToArray())
      {
        if (!arr3.Contains(item))
          res.Remove(item);
      }
      return res.ToArray();
    }
  }
}
