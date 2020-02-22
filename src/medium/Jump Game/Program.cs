using System.Collections.Generic;
using System;

namespace Jump_Game
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      Console.WriteLine(program.CanJump(new int[] { 0 }));//true
      Console.WriteLine(program.CanJump(new int[] { }));//false
      Console.WriteLine(program.CanJump(new int[] { 2, 0 }));//true
      Console.WriteLine(program.CanJump(new int[] { 2, 3, 1, 1, 4 }));//true
      Console.WriteLine(program.CanJump(new int[] { 3, 2, 1, 0, 4 }));//false
      Console.WriteLine(program.CanJump(new int[] { 8, 2, 4, 4, 4, 9, 5, 2, 5, 8, 8, 0, 8, 6, 9, 1, 1, 6, 3, 5, 1, 2, 6, 6, 0, 4, 8, 6, 0, 3, 2, 8, 7, 6, 5, 1, 7, 0, 3, 4, 8, 3, 5, 9, 0, 4, 0, 1, 0, 5, 9, 2, 0, 7, 0, 2, 1, 0, 8, 2, 5, 1, 2, 3, 9, 7, 4, 7, 0, 0, 1, 8, 5, 6, 7, 5, 1, 9, 9, 3, 5, 0, 7, 5 }));//true
      Console.WriteLine("Hello World!");
    }
    public bool CanJump(int[] nums)
    {
      if (nums.Length == 0)
        return false;
      if (nums.Length == 1)
        return true;
      bool[] visited = new bool[nums.Length];
      Queue<int> queue = new Queue<int>();
      queue.Enqueue(0);
      visited[0] = true;
      while (queue.Count > 0)
      {
        int cnt = queue.Count;
        for (int i = 0; i < cnt; i++)
        {
          int index = queue.Dequeue();
          int length = nums[index];
          for (int j = 1; j <= length; j++)
          {
            if (index + j >= nums.Length)
              break;
            if (index + j == nums.Length - 1)
              return true;
            if (nums[index + j] == 0)
              continue;
            if (visited[index + j])
              continue;
            queue.Enqueue(index + j);
            visited[index + j] = true;
          }
        }
      }
      return false;
    }
  }
}
