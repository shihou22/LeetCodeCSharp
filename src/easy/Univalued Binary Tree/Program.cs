using System;

namespace Univalued_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public bool IsUnivalTree(TreeNode root)
        {
            if (root == null)
                return false;
            return IsUnivalTree(root, root.val);
        }
        private bool IsUnivalTree(TreeNode root, int val)
        {
            if (root == null)
                return true;
            if (root.val != val)
                return false;
            var val1 = IsUnivalTree(root.left, val);
            var val2 = IsUnivalTree(root.right, val);
            return val1 && val2;
        }
    }
}
