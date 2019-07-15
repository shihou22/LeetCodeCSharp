using System;
using System.Collections.Generic;

namespace Average_of_Levels_in_Binary_Tree
{
  class Solution
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public IList<double> AverageOfLevels(TreeNode root)
    {

      var res = new List<double>();
      Queue<TreeNode> queue = new Queue<TreeNode>();
      queue.Enqueue(root);

      while (queue.Count > 0)
      {
        double count = queue.Count;
        double total = 0;
        double valCount = 0;
        for (int i = 0; i < count; i++)
        {
          var tmp = queue.Dequeue();
          if (tmp == null)
            continue;

          total += tmp.val;

          queue.Enqueue(tmp.left);
          queue.Enqueue(tmp.right);

          valCount++;
        }
        if (valCount != 0)
          res.Add(total / valCount);

      }
      return res;

    }
  }
  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
  }
}
