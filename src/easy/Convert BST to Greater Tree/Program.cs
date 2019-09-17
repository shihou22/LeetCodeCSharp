using System;
using System.Linq;
using System.Collections.Generic;

namespace Convert_BST_to_Greater_Tree
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
        public TreeNode ConvertBST(TreeNode root)
        {

            bstHelper(root, 0);
            return root;
        }

        private int bstHelper(TreeNode root, int sum)
        {
            if (root == null)
                return sum;

            sum = bstHelper(root.right, sum);
            root.val += sum;
            sum = bstHelper(root.left, root.val);

            return sum;
        }
        public TreeNode ConvertBSTIteration(TreeNode root)
        {
            var bases = new List<TreeNode>();

            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);
            while (que.Count > 0)
            {
                TreeNode wk = que.Dequeue();
                if (wk == null)
                    continue;
                bases.Add(wk);
                que.Enqueue(wk.left);
                que.Enqueue(wk.right);
            }
            var en = bases.OrderByDescending(x => x.val);
            int total = 0;
            foreach (var item in en)
            {
                total += item.val;
                item.val = total;
            }
            return root;
        }
    }
}
