using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Unique_Binary_Search_Trees_II
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
            var res1 = program.GenerateTrees(3);
            var res2 = program.GenerateTrees(0);
            Console.WriteLine("Hello World!");
        }
        public IList<TreeNode> GenerateTrees(int n)
        {
            int[] wk = new int[n];
            for (int i = 0; i < n; i++)
                wk[i] = i + 1;
            if (n == 0)
                return new List<TreeNode>();
            return CreateNode(wk, 1, n);
        }
        private List<TreeNode> CreateNode(int[] wk, int start, int end)
        {
            List<TreeNode> list = new List<TreeNode>();

            if (start > end)
            {
                list.Add(null);
                return list;
            }
            List<TreeNode> left;
            List<TreeNode> right;
            for (int i = start; i <= end; i++)
            {
                left = CreateNode(wk, start, i - 1);
                right = CreateNode(wk, i + 1, end);
                foreach (var leftItem in left)
                {
                    foreach (var rightItem in right)
                    {
                        TreeNode node = new TreeNode(wk[i - 1]);
                        node.left = leftItem;
                        node.right = rightItem;
                        list.Add(node);
                    }
                }
            }
            return list;
        }
    }
}
