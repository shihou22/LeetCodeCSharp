using System;
using System.Collections.Generic;

namespace Path_Sum_III
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
        public int PathSum(TreeNode root, int sum)
        {
            if (root == null)
                return 0;
            return Helper(root, sum) + PathSum(root.left, sum) + PathSum(root.right, sum);
        }

        private int Helper(TreeNode root, int sum)
        {
            if (root == null)
                return 0;

            int count = 0;
            if (root.val == sum)
                count++;
            count += Helper(root.left, sum - root.val);
            count += Helper(root.right, sum - root.val);
            return count;
        }
    }
}
