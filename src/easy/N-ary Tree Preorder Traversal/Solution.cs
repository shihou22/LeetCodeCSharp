using System;
using System.Collections.Generic;

namespace N_ary_Tree_Preorder_Traversal
{
  class Solution
  {
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
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Node node5 = new Node(5, new List<Node>());
      Node node6 = new Node(6, new List<Node>());
      Node node3 = new Node(3, new List<Node>() { node5, node6 });
      Node node2 = new Node(2, new List<Node>());
      Node node4 = new Node(4, new List<Node>());
      Node node1 = new Node(1, new List<Node>() { node3, node2, node4 });
      IList<int> res = solution.Preorder(node1);
      Console.WriteLine("Hello World!");
    }
    public IList<int> Preorder(Node root)
    {
      IList<int> res = new List<int>();
      if (root == null)
        return res;
      Stack<Node> stack = new Stack<Node>();
      stack.Push(root);
      while (stack.Count > 0)
      {
        Node wk = stack.Pop();
        res.Add(wk.val);
        for (int i = wk.children.Count - 1; i >= 0; i--)
        {
          stack.Push(wk.children[i]);
        }
      }
      return res;
    }
    public IList<int> PreorderRecursive(Node root)
    {
      IList<int> res = new List<int>();
      if (root == null)
        return res;
      res.Add(root.val);
      rec(root, res);
      return res;
    }
    private void rec(Node root, IList<int> que)
    {
      IList<Node> wkNode = root.children;
      for (int i = 0; i < wkNode.Count; i++)
      {
        que.Add(wkNode[i].val);
        rec(wkNode[i], que);
      }
    }
  }
}
