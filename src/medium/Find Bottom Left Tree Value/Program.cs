using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Find_Bottom_Left_Tree_Value
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
      if (nums[n] == null)
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
      TreeNode root1 = TreeNodeHelper.CreateTree(new int[] { 2, 1, 3 });
      Console.WriteLine(program.FindBottomLeftValue(root1));
      TreeNode root2 = TreeNodeHelper.CreateTree(new string[] { "1", "2", "3", "4", null, "5", "6", null, null, "7" });
      Console.WriteLine(program.FindBottomLeftValue(root2));
      TreeNode root3 = TreeNodeHelper.CreateTree(new string[] { "0", null, "-1" });
      Console.WriteLine(program.FindBottomLeftValue(root3));
      Console.WriteLine("Hello World!");
    }
    public int FindBottomLeftValue(TreeNode root)
    {
      int res = -1;
      Queue<TreeNode> queue = new Queue<TreeNode>();
      queue.Enqueue(root);
      while (queue.Count > 0)
      {
        int cnt = queue.Count;
        for (int i = 0; i < cnt; i++)
        {
          TreeNode node = queue.Dequeue();
          if (i == 0)
            res = node.val;
          if (node.left != null)
            queue.Enqueue(node.left);
          if (node.right != null)
            queue.Enqueue(node.right);
        }
      }
      return res;
    }
  }
}
