using System;
using System.Collections.Generic;

namespace Increasing_Order_Search_Tree
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
        public TreeNode IncreasingBST(TreeNode root)
        {
            List<TreeNode> memo = new List<TreeNode>();
            DFS(root, memo);
            TreeNode ret = new TreeNode(memo[0].val);
            var wk = ret;
            for (int i = 1; i < memo.Count; i++)
            {
                wk.right = new TreeNode(memo[i].val);
                wk = wk.right;
            }
            return ret;

        }
        private void DFS(TreeNode root, List<TreeNode> memo)
        {
            if (root == null)
                return;
            //先に左を探索。左を先にaddする
            DFS(root.left, memo);
            //中央をAdd
            memo.Add(root);
            //右を最後に探索。右を先にAddする
            DFS(root.right, memo);
        }
    }
}
