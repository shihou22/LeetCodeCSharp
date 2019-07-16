using System;
using System.Collections.Generic;
using System.Linq;

namespace Binary_Tree_Zigzag_Level_Order_Traversal
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> tmp = new List<IList<int>>();
            if (root == null)
                return tmp;
            var wkQueue = new Queue<TreeNode>();
            wkQueue.Enqueue(root);
            int depth = 0;
            while (wkQueue.Count > 0)
            {
                var size = wkQueue.Count;
                var res = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    var current = wkQueue.Dequeue();
                    if (depth % 2 == 0)
                        res.Add(current.val);
                    else
                        res.Insert(0, current.val);

                    if (current.left != null)
                        wkQueue.Enqueue(current.left);

                    if (current.right != null)
                        wkQueue.Enqueue(current.right);
                }

                depth++;
                tmp.Add(res);
            }
            return tmp;
        }

        public IList<IList<int>> ZigzagLevelOrderOld(TreeNode root)
        {
            IList<IList<int>> tmp = new List<IList<int>>();
            recursive(root, 0, tmp);
            return tmp;
        }


        private void recursive(TreeNode root, int depth, IList<IList<int>> res)
        {
            if (root == null)
                return;

            if (res.Count < depth + 1)
                res.Add(new List<int>());

            IList<int> tmp = res[depth];

            if (depth % 2 == 0)
                tmp.Insert(0, root.val);
            else
                tmp.Add(root.val);

            if (root.right != null)
                recursive(root.right, depth + 1, res);

            if (root.left != null)
                recursive(root.left, depth + 1, res);
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
        }
    }
}
