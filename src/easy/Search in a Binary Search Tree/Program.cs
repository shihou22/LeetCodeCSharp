using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Search_in_a_Binary_Search_Tree
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
            TreeNode node = TreeNodeHelper.CreateTree(new int[] { 4, 2, 7, 1, 3 });
            var res1 = program.SearchBST(node, 2);
            Console.WriteLine("Hello World!");
        }
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
                return null;
            if (root.val == val)
                return root;
            TreeNode left = SearchBST(root.left, val);
            if (left != null)
                return left;
            TreeNode right = SearchBST(root.right, val);
            return right;
        }
    }
}
