using System;
using System.Collections.Generic;

namespace Path_Sum_II
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var root = new TreeNode(5);
            root.left = new TreeNode(4);
            root.left.left = new TreeNode(11);
            root.left.left.left = new TreeNode(7);
            root.left.left.right = new TreeNode(2);
            root.right = new TreeNode(8);
            root.right.left = new TreeNode(13);
            root.right.right = new TreeNode(4);
            root.right.right.left = new TreeNode(5);
            root.right.right.right = new TreeNode(1);
            solution.PathSum(root, 22);
            Console.WriteLine("Hello World!");
        }
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {

            IList<IList<int>> res = new List<IList<int>>();
            IList<int> memo = new List<int>();
            DFS(root, memo, sum, 0, res);
            return res;
        }

        private void DFS(TreeNode root, IList<int> memo, int sum, int curr, IList<IList<int>> res)
        {

            if (root == null)
                return;

            memo.Add(root.val);
            if (sum == curr + root.val && root.left == null && root.right == null)
            {
                res.Add(new List<int>(memo));
            }
            else
            {
                DFS(root.left, memo, sum, curr + root.val, res);
                DFS(root.right, memo, sum, curr + root.val, res);
            }
            memo.RemoveAt(memo.Count - 1);
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
