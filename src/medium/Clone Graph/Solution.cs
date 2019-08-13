using System;
using System.Collections.Generic;

namespace Clone_Graph
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node() { }
            public Node(int _val, IList<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }
        public Node CloneGraph(Node node)
        {
            Dictionary<int, Node> memo = new Dictionary<int, Node>();
            Stack<Node> stack = new Stack<Node>();
            stack.Push(node);
            while (stack.Count > 0)
            {
                Node wk = stack.Pop();
                foreach (var item in wk.neighbors)
                {
                    if (!memo.ContainsKey(item.val))
                    {
                        memo.Add(item.val, new Node(item.val, new List<Node>()));
                        stack.Push(item);
                    }

                }
                if (!memo.ContainsKey(wk.val))
                    memo.Add(wk.val, new Node(wk.val, new List<Node>()));
            }
            stack.Push(node);
            while (stack.Count > 0)
            {
                Node wk = stack.Pop();

                IList<Node> wkNeighbors = memo[wk.val].neighbors;
                if (wkNeighbors.Count > 0)
                    continue;
                foreach (var item in wk.neighbors)
                {
                    wkNeighbors.Add(memo[item.val]);
                    stack.Push(item);
                }

            }
            return memo[node.val];
        }
    }
}
