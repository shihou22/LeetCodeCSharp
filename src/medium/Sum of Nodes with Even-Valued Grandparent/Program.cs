using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Sum_of_Nodes_with_Even_Valued_Grandparent
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    class TreeNodeHelper
    {
        public static TreeNode CreateTree(int[] nums)
        {
            return CreateTree(nums.Select(x => x.ToString()).ToArray());
        }

        public static TreeNode CreateTree(string[] nums)
        {
            if (nums == null)
                return null;
            TreeNode res = new TreeNode(int.Parse(nums[0]));
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(res);
            int index = 1;
            while (nodes.Count > 0)
            {
                int cnt = nodes.Count;
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode root = nodes.Dequeue();
                    if (root == null)
                        continue;
                    root.left = GetNode(nums, index++);
                    root.right = GetNode(nums, index++);
                    nodes.Enqueue(root.left);
                    nodes.Enqueue(root.right);
                }
            }
            return res;
        }
        private static TreeNode GetNode(string[] nums, int n)
        {
            if (n >= nums.Length)
                return null;
            if (nums[n] == null)
                return null;
            return new TreeNode(int.Parse(nums[n]));
        }
        public static string ResultStr(TreeNode node)
        {
            StringBuilder builder = new StringBuilder();
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            while (nodes.Count > 0)
            {
                int cnt = nodes.Count;
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode wk = nodes.Dequeue();
                    if (wk == null)
                    {
                        builder.Append("null").Append(" ");
                    }
                    else
                    {
                        builder.Append(wk.val).Append(" ");
                        nodes.Enqueue(wk.left);
                        nodes.Enqueue(wk.right);
                    }
                }
            }
            return builder.ToString();
        }
    }
    class NodeHelper
    {
        public TreeNode node { get; }
        public int parent { get; }
        public int grand { get; }
        public NodeHelper(TreeNode node, int parent, int grand)
        {
            this.node = node;
            this.parent = parent;
            this.grand = grand;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //18
            var res1 = TreeNodeHelper.CreateTree(new string[] { "6", "7", "8", "2", "7", "1", "3", "9", null, "1", "4", null, null, null, "5" });
            Console.WriteLine(program.SumEvenGrandparent(res1));
            Console.WriteLine("Hello World!");
        }
        public int SumEvenGrandparent(TreeNode root)
        {
            DFS(root, 1, 1);
            return cnt;
        }
        int cnt = 0;
        private void DFS(TreeNode node, int parent, int grand)
        {
            if (node == null)
                return;
            if (grand % 2 == 0)
                cnt += node.val;
            if (node.left != null)
                DFS(node.left, node.val, parent);
            if (node.right != null)
                DFS(node.right, node.val, parent);
        }
        public int SumEvenGrandparentBFS(TreeNode root)
        {
            if (root == null)
                return 0;
            Queue<NodeHelper> queue = new Queue<NodeHelper>();
            queue.Enqueue(new NodeHelper(root, 1, 1));
            int res = 0;
            while (queue.Count > 0)
            {
                int cnt = queue.Count;
                for (int i = 0; i < cnt; i++)
                {
                    NodeHelper node = queue.Dequeue();
                    if (node.grand % 2 == 0)
                        res += node.node.val;
                    var wkNode = node.node;

                    if (wkNode.left != null)
                        queue.Enqueue(new NodeHelper(wkNode.left, node.node.val, node.parent));
                    if (wkNode.right != null)
                        queue.Enqueue(new NodeHelper(wkNode.right, node.node.val, node.parent));
                }
            }
            return res;
        }
    }
}
