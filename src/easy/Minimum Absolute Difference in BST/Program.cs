using System;
using System.Collections.Generic;

namespace Minimum_Absolute_Difference_in_BST
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
        public int GetMinimumDifference(TreeNode root)
        {
            if (root == null)
                return 0;
            GetBST(root);
            res.Sort();
            int minval = int.MaxValue;
            for (int i = 1; i < res.Count; i++)
            {
                minval = Math.Min(Math.Abs(res[i] - res[i - 1]), minval);
            }
            return minval;
        }
        List<int> res = new List<int>();
        private void GetBST(TreeNode root)
        {
            if (root == null)
                return;
            res.Add(root.val);
            GetBST(root.right);
            GetBST(root.left);
        }
    }
}
