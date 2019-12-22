using System;
using System.Collections.Generic;

namespace Minimum_Distance_Between_BST_Nodes
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
    public int MinDiffInBST(TreeNode root)
    {
      return solveRecursive(root);
      // searchMin(root);
      // return minVal;
    }

    // private static int minVal = int.MaxValue;
    // private void searchMin(TreeNode root)
    // {
    //   if (root == null)
    //     return;
    //   Console.WriteLine("root.val : " + root.val);
    //   if (root.left != null)
    //   {
    //     Console.WriteLine("root.val : " + root.val);
    //     Console.WriteLine("root.left.val : " + root.left.val);
    //     minVal = Math.Min(Math.Abs(root.val - root.left.val), minVal);
    //     searchMin(root.left);
    //   }

    //   if (root.right != null)
    //   {
    //     Console.WriteLine("root.val : " + root.val);
    //     Console.WriteLine("root.right.val : " + root.right.val);
    //     minVal = Math.Min(Math.Abs(root.val - root.right.val), minVal);
    //     searchMin(root.right);
    //   }
    // }

    private int solveRecursive(TreeNode root)
    {
      IList<int> list = new List<int>();
      getMin(root, list);
      int min = int.MaxValue;
      for (int i = 1; i < list.Count; i++)
      {
        min = Math.Min(list[i] - list[i - 1], min);
        if (min == 1) return min;
      }
      return min;
    }

    private void getMin(TreeNode root, IList<int> diff)
    {
      if (root == null)
        return;
      getMin(root.left, diff);
      diff.Add(root.val);
      getMin(root.right, diff);
    }
  }
}
