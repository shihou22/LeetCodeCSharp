using System;

namespace _132_Pattern
{
  class SegementTree
  {
    private int n;
    private int[] node;
    public SegementTree(int[] nodes)
    {
      int sz = nodes.Length;
      n = 1;
      while (n < sz)
        n *= 2;
      node = new int[2 * n - 1];
      for (int i = 0; i < sz; i++)
      {
        node[i + n - 1] = nodes[i];
      }
      for (int i = n - 2; i >= 0; i--)
      {
        node[i] = Math.Min(node[i * 2 + 1], node[i * 2 + 2]);
      }
    }
    public void update(int index, int val)
    {
      index += (n - 1);
      node[index] = val;
      while (index > 0)
      {
        index = (index - 1) / 2;
        node[index] = Math.Min(node[2 * index + 1], node[2 * index + 2]);
      }
    }
    public int getMin(int a, int b, int k = 0, int l = 0, int r = -1)
    {
      if (r < 0)
        r = n;
      if (r <= a || b <= l)
        return int.MaxValue;

      if (a <= l && r <= b)
        return node[k];
      int vl = getMin(a, b, 2 * k + 1, l, (l + r) / 2);
      int vr = getMin(a, b, 2 * k + 2, (l + r) / 2, r);
      return Math.Min(vl, vr);
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //   true
      Console.WriteLine(program.Find132pattern(new int[] { 3, 5, 0, 3, 4 }));
      //   false
      Console.WriteLine(program.Find132pattern(new int[] { 1, 2, 3, 4 }));
      //   true
      Console.WriteLine(program.Find132pattern(new int[] { 3, 1, 4, 2 }));
      //   true
      Console.WriteLine(program.Find132pattern(new int[] { -1, 3, 2, 0 }));
      Console.WriteLine("Hello World!");
    }
    public bool Find132pattern(int[] nums)
    {
      if (nums.Length == 0)
        return false;
      int n = nums.Length;
      int min = nums[0];
      for (int j = 1; j < n - 1; j++)
      {
        if (min > nums[j])
        {
          min = nums[j];
          continue;
        }

        for (int k = j + 1; k < n; k++)
        {
          if (min < nums[k] && nums[k] < nums[j])
            return true;
        }

      }
      return false;
    }
    public bool Find132patternTLE(int[] nums)
    {
      int n = nums.Length;
      for (int i = 0; i < n; i++)
      {
        for (int j = i + 1; j < n; j++)
        {
          for (int k = j + 1; k < n; k++)
          {
            if (nums[i] < nums[k] && nums[k] < nums[j])
              return true;
          }
        }
      }
      return false;
    }

  }
}
