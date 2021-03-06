﻿using System;
using System.Text;
using System.Collections.Generic;

namespace Deepest_Leaves_Sum
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    class TreeNodeFactory
    {
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
            TreeNode root = TreeNodeFactory.CreateTree(new string[] { "1", "2", "3", "4", "5", null, "6", "7", null, null, null, null, "8" });
            Console.WriteLine(program.DeepestLeavesSum(root));
            root = TreeNodeFactory.CreateTree(new string[] { "6", "7", "8", "2", "7", "1", "3", "9", null, "1", "4", null, null, null, "5" });
            Console.WriteLine(program.DeepestLeavesSum(root));
            Console.WriteLine("Hello World!");
        }
        public int DeepestLeavesSum(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int res = 0;
            while (queue.Count > 0)
            {
                int cnt = queue.Count;
                int levelCnt = 0;
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue.Dequeue();
                    levelCnt += node.val;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                if (queue.Count == 0)
                    res = levelCnt;
            }
            return res;
        }
    }
}
