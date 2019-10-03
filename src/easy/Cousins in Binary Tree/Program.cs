using System;
using System.Collections.Generic;

namespace Cousins_in_Binary_Tree
{
  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
  }
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public bool IsCousins(TreeNode root, int x, int y)
    {
      Queue<TreeNode> que = new Queue<TreeNode>();
      que.Enqueue(root);
      //   int cnt = 1;
      while (que.Count > 0)
      {
        int wk = que.Count;
        bool existX = false;
        bool existY = false;
        // Console.WriteLine("--:" + cnt++ + ":--");
        for (int i = 0; i < wk; i++)
        {
          var tmp = que.Dequeue();
          if (tmp == null)
            continue;
          //   Console.WriteLine(tmp.val);
          if (tmp.val == x)
            existX = true;
          if (tmp.val == y)
            existY = true;

          que.Enqueue(tmp.left);
          que.Enqueue(tmp.right);
          if (tmp.left != null && tmp.right != null)
          {
            bool val1 = false;
            if (tmp.left.val == x || tmp.right.val == x)
              val1 = true;
            bool val2 = false;
            if (tmp.left.val == y || tmp.right.val == y)
              val2 = true;
            if (val1 && val2)
              return false;
          }
        }
        if (existX && existY)
          return true;

      }
      return false;
    }
  }
}
