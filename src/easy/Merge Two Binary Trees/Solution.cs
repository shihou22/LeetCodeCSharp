using System.ComponentModel.Design.Serialization;
using System.Xml.Schema;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace Merge_Two_Binary_Trees
{
  class Solution
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }

    public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
    {
      if (t1 == null && t2 == null)
        return null;

      if (t2 == null)
        return t1;

      if (t1 == null)
        return t2;

      t1.val += t2.val;

      var queueT1 = new Queue<TreeNode>();
      queueT1.Enqueue(t1);
      var queueT2 = new Queue<TreeNode>();
      queueT2.Enqueue(t2);
      while (queueT1.Count > 0 || queueT2.Count > 0)
      {
        var inT1 = queueT1.Dequeue();
        var inT2 = queueT2.Dequeue();

        if (inT1 == null || inT2 == null)
          continue;

        if (inT1.left != null && inT2.left != null)
          inT1.left.val += inT2.left.val;

        queueT1.Enqueue(inT1.left);
        queueT2.Enqueue(inT2.left);

        if (inT1.left == null)
          inT1.left = inT2.left;

        if (inT1.right != null && inT2.right != null)
          inT1.right.val += inT2.right.val;

        queueT1.Enqueue(inT1.right);
        queueT2.Enqueue(inT2.right);

        if (inT1.right == null)
          inT1.right = inT2.right;
      }
      return t1;
    }

    public TreeNode MergeTreesRevursive(TreeNode t1, TreeNode t2)
    {
      if (t1 == null && t2 == null)
        return null;

      if (t2 == null)
        return t1;

      if (t1 == null)
        return t2;

      t1.val += t2.val;
      recursiveCall(t1, t2);
      return t1;
    }

    private void recursiveCall(TreeNode left, TreeNode right)
    {
      if (left == null || right == null)
        return;

      if (left.left != null && right.left != null)
        left.left.val += right.left.val;


      if (left.right != null && right.right != null)
        left.right.val += right.right.val;


      recursiveCall(left.left, right.left);
      recursiveCall(left.right, right.right);

      if (left.left == null)
        left.left = right.left;

      if (left.right == null)
        left.right = right.right;

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
