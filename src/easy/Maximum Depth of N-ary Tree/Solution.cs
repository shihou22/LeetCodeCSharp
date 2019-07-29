using System;
using System.Collections.Generic;

namespace Maximum_Depth_of_N_ary_Tree
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            // Console.WriteLine(solution.MaxDepth());
            Console.WriteLine("Hello World!");
        }
        public int MaxDepth(Node root)
        {
            if (root == null)
                return 0;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            int currentI = 0;
            while (queue.Count != 0)
            {
                int max = queue.Count;
                currentI++;
                for (int i = 0; i < max; i++)
                {
                    Node wkRoot = queue.Dequeue();
                    IList<Node> _children = wkRoot.children;
                    foreach (var cNode in _children)
                    {
                        queue.Enqueue(cNode);
                    }
                }
            }
            return currentI;
        }
        public int MaxDepthDFS(Node root)
        {
            return CountMaxDepth(root, 0);
        }

        private int CountMaxDepth(Node root, int currentI)
        {
            if (root == null)
                return currentI;

            int depth = currentI + 1;
            IList<Node> _children = root.children;
            foreach (var node in _children)
            {
                var wkDepth = CountMaxDepth(node, currentI + 1);
                depth = Math.Max(wkDepth, depth);
            }
            return depth;
        }
    }
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }
        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}
