using System.Collections.Immutable;
using System.Linq;
using System;

namespace The_K_Weakest_Rows_in_a_Matrix
{
  class Pair<K, V>
  {
    public K key { get; }
    public V val { get; }
    public Pair(K k, V v)
    {
      this.key = k;
      this.val = v;
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public int[] KWeakestRows(int[][] mat, int k)
    {
      return mat.Select((val, index) => new Pair<int, int>(val.Where(x => (x == 1)).Count(), index)).OrderBy(x => x.key).Take(k).Select(x => x.val).ToArray();
    }
  }
}
