using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Find_Largest_Value_in_Each_Tree_Row
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
      var res1 = program.LargestValues(TreeNodeHelper.CreateTree(new string[] { "34", "-6", null, "-21" }));
      Console.WriteLine("Hello World!");
    }
    public IList<int> LargestValues(TreeNode root)
    {
      IList<int> res = new List<int>();
      if (root == null)
        return res;
      Queue<TreeNode> queue = new Queue<TreeNode>();
      queue.Enqueue(root);
      while (queue.Count > 0)
      {
        int cnt = queue.Count;
        int val = -1;
        for (int i = 0; i < cnt; i++)
        {
          TreeNode node = queue.Dequeue();
          if (i == 0)
            val = node.val;
          else
            val = Math.Max(val, node.val);

          if (node.left != null)
            queue.Enqueue(node.left);
          if (node.right != null)
            queue.Enqueue(node.right);
        }
        res.Add(val);
      }
      return res;
    }
  }
}
