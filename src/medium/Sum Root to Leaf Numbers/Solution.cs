using System;

namespace Sum_Root_to_Leaf_Numbers
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            Console.WriteLine(solution.SumNumbers(root));
            Console.WriteLine("Hello World!");
        }
        public int SumNumbers(TreeNode root)
        {
            if (root == null)
                return 0;

            sum(root, 0);

            return totalSum;
        }
        private int totalSum = 0;

        private void sum(TreeNode root, int currentTotal)
        {
            if (root == null)
                return;

            if (root.left != null)
                sum(root.left, currentTotal * 10 + root.val);

            if (root.right != null)
                sum(root.right, currentTotal * 10 + root.val);

            if (root.left == null && root.right == null)
                totalSum += currentTotal * 10 + root.val;
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
