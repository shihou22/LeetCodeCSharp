using System;
using System.Collections.Generic;

namespace Binary_Tree_Inorder_Traversal
{
    /**
    * Definition for a binary tree node.
    */
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
            Program program = new Program();
            TreeNode node = new TreeNode(1);
            node.right = new TreeNode(2);
            node.right.left = new TreeNode(3);

            var res = program.InorderTraversal(node);
            Console.WriteLine("Hello World!");
        }
        /**
        Recursive
        */

        public IList<int> InorderTraversalRecursive(TreeNode root)
        {
            IList<int> res = new List<int>();
            helper(root, res);
            return res;
        }
        public void helper(TreeNode root, IList<int> res)
        {
            if (root != null)
            {
                if (root.left != null)
                {
                    helper(root.left, res);
                }
                res.Add(root.val);
                if (root.right != null)
                {
                    helper(root.right, res);
                }
            }
        }
        public IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> res = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode node = root;
            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                node = stack.Pop();
                res.Add(node.val);
                node = node.right;
            }
            return res;
        }

    }
}
