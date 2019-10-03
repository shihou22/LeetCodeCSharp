using System;
using System.Collections.Generic;

namespace Subtree_of_Another_Tree
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
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null)
                return true;
            if (s == null || t == null)
                return false;
            var res1 = DFSFirst(s);
            var res2 = DFSFirst(t);
            // Console.WriteLine(res1);
            // Console.WriteLine(res2);
            return res2.IndexOf(res1) >= 0;
        }

        private string DFSFirst(TreeNode root)
        {
            if (root == null)
                return "|null|";
            var res = "|" + root.val.ToString() + "|";
            var val1 = DFSFirst(root.left);
            var val2 = DFSFirst(root.right);
            return res + val1 + val2;
        }
    }
}
