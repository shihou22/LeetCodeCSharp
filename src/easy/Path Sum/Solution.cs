using System;

namespace Path_Sum
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;

            if (root.left == null && root.right == null && sum - root.val == 0)
                return true;

            bool val1 = HasPathSum(root.left, sum - root.val);
            bool val2 = HasPathSum(root.right, sum - root.val);
            return val1 || val2;
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
