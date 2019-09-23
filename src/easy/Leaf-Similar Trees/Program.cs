using System;
using System.Collections.Generic;

namespace Leaf_Similar_Trees
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
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
      IList<int> list1 = CreateList(root1, new List<int>());
      IList<int> list2 = CreateList(root2, new List<int>());

      for (int i = 0; i < list1.Count; i++)
      {
        Console.WriteLine(list2[i] + " / " + list1[i]);
        if (list2[i] != list1[i])
          return false;
      }
      return true;
    }
    private IList<int> CreateList(TreeNode root, IList<int> res)
    {
      if (root == null)
        return res;

      if (root.left == null && root.right == null)
        res.Add(root.val);
      CreateList(root.left, res);
      CreateList(root.right, res);

      return res;
    }
  }
}
