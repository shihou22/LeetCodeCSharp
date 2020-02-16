using System.Linq;
using System;

namespace Beautiful_Arrangement
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //10
      Console.WriteLine(program.CountArrangement(5));
      program.count = 0;
      //36
      Console.WriteLine(program.CountArrangement(6));
      Console.WriteLine("Hello World!");
    }
    int count = 0;
    public int CountArrangement(int N)
    {
      bool[] visited = new bool[N + 1];
      DFS(N, 1, visited);
      return count;
    }
    public void DFS(int N, int pos, bool[] visited)
    {

      if (pos > N)
      {
        count++;
        return;
      }
      for (int i = 1; i <= N; i++)
      {
        if (!visited[i] && (pos % i == 0 || i % pos == 0))
        {
          visited[i] = true;
          DFS(N, pos + 1, visited);
          visited[i] = false;
        }
      }
    }


    public int CountArrangementBruteForce(int N)
    {
      int[] nums = new int[N];
      for (int i = 0; i < N; i++)
        nums[i] = i + 1;
      Permute(nums, 0);
      return count;
    }

    public void Permute(int[] nums, int l)
    {
      if (l == nums.Length)
      {
        // var res = nums.Where((x, i) => !(x % (i + 1) == 0 || (i + 1) % x == 0)).ToList();
        // if (!res.Any())
        //   count++;
        count++;
        return;
      }
      for (int i = l; i < nums.Length; i++)
      {
        Swap(nums, l, i);
        if (nums[l] % (l + 1) == 0 || (l + 1) % nums[l] == 0)
        {
          Permute(nums, l + 1);
        }
        Swap(nums, l, i);
      }
    }
    public void Swap(int[] nums, int x, int y)
    {
      int temp = nums[x];
      nums[x] = nums[y];
      nums[y] = temp;
    }
  }
}
