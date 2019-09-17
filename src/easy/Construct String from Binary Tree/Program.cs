using System;

namespace Construct_String_from_Binary_Tree
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
        public String tree2str(TreeNode t)
        {
            if (t == null)
                return "";
            if (t.left == null && t.right == null)
                return t.val + "";
            if (t.right == null)
                return t.val + "(" + tree2str(t.left) + ")";
            return t.val + "(" + tree2str(t.left) + ")(" + tree2str(t.right) + ")";
        }
        public string Tree2strTwoMethod(TreeNode t)
        {
            if (t == null)
                return "";
            return DFS(t, true);
        }
        private string DFS(TreeNode root, bool first)
        {
            if (root == null)
                return "()";

            var res = !first ? "(" : "";
            res += root.val.ToString();

            var resL = DFS(root.left, false);
            var resR = DFS(root.right, false);

            if (!resL.Equals("()") && !resR.Equals("()"))
                res += resL + resR;
            else if (!resL.Equals("()") && resR.Equals("()"))
                res += resL;
            else if (resL.Equals("()") && !resR.Equals("()"))
                res += resL + resR;
            res += !first ? ")" : "";
            return res;
        }
    }
}
