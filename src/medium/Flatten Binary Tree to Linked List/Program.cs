using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Flatten_Binary_Tree_to_Linked_List
{
  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
  }
  class TreeNodeHelper
  {
    public static TreeNode CreateTree(int[] nums)
    {
      return CreateTree(nums.Select(x => x.ToString()).ToArray());
    }

    public static TreeNode CreateTree(string[] nums)
    {
      if (nums == null)
        return null;
      TreeNode res = new TreeNode(int.Parse(nums[0]));
      Queue<TreeNode> nodes = new Queue<TreeNode>();
      nodes.Enqueue(res);
      int index = 1;
      while (nodes.Count > 0)
      {
        int cnt = nodes.Count;
        for (int i = 0; i < cnt; i++)
        {
          TreeNode root = nodes.Dequeue();
          if (root == null)
            continue;
          root.left = GetNode(nums, index++);
          root.right = GetNode(nums, index++);
          nodes.Enqueue(root.left);
          nodes.Enqueue(root.right);
        }
      }
      return res;
    }
    private static TreeNode GetNode(string[] nums, int n)
    {
      if (n >= nums.Length)
        return null;
      if (nums[n] == null || nums[n] == "null")
        return null;
      return new TreeNode(int.Parse(nums[n]));
    }
    public static string ResultStr(TreeNode node)
    {
      StringBuilder builder = new StringBuilder();
      Queue<TreeNode> nodes = new Queue<TreeNode>();
      while (nodes.Count > 0)
      {
        int cnt = nodes.Count;
        for (int i = 0; i < cnt; i++)
        {
          TreeNode wk = nodes.Dequeue();
          if (wk == null)
          {
            builder.Append("null").Append(" ");
          }
          else
          {
            builder.Append(wk.val).Append(" ");
            nodes.Enqueue(wk.left);
            nodes.Enqueue(wk.right);
          }
        }
      }
      return builder.ToString();
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      var root1 = TreeNodeHelper.CreateTree("1,2,5,3,4,null,6".Split(","));
      program.Flatten(root1);
      Console.WriteLine("Hello World!");
    }
    public void Flatten(TreeNode root)
    {

      while (root != null)
      {
        if (root.left != null)
        {
          if (root.right == null)
          {
            root.right = root.left;
          }
          else
          {
            var nextRight = root.right;
            root.right = root.left;
            var curr = root.right;
            while (curr.right != null)
            {
              curr = curr.right;
            }
            curr.right = nextRight;
          }
          root.left = null;
        }
        root = root.right;
      }
    }

    public void FlattenQueue(TreeNode root)
    {
      if (root == null)
        return;

      Queue<TreeNode> nodes = new Queue<TreeNode>();
      Flat(nodes, root);
      root = nodes.Dequeue();
      while (nodes.Count > 0)
      {
        root.left = null;
        root.right = nodes.Dequeue();
        root = root.right;
      }
    }
    private void Flat(Queue<TreeNode> nodes, TreeNode root)
    {
      if (root == null)
        return;
      nodes.Enqueue(root);
      Flat(nodes, root.left);
      Flat(nodes, root.right);
      root.left = null;
      root.right = null;
    }

  }
}
