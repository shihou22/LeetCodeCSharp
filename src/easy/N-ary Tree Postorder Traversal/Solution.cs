using System.Linq;
using System;
using System.Collections.Generic;

namespace N_ary_Tree_Postorder_Traversal
{
  class Solution
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public IList<int> Postorder(Node root)
    {
      IList<int> res = new List<int>();
      if (root == null)
        return res;

      Stack<Node> nodes = new Stack<Node>();
      nodes.Push(root);
      while (nodes.Count > 0)
      {
        Node wk = nodes.Pop();
        res.Insert(0, wk.val);
        IList<Node> childs = wk.children;
        if (childs == null)
          continue;

        foreach (var item in childs)
        {
          nodes.Push(item);
        }
      }
      return res;
    }
    public IList<int> PostorderItr1(Node root)
    {
      IList<int> res = new List<int>();
      if (root == null)
        return res;

      Stack<Node> nodes = new Stack<Node>();
      nodes.Push(root);
      while (nodes.Count > 0)
      {
        Node wk = nodes.Peek();
        if (wk.children == null)
        {
          wk = nodes.Pop();
          res.Add(wk.val);
        }
        else
        {
          for (int i = wk.children.Count - 1; i >= 0; i--)
          {
            nodes.Push(wk.children[i]);
          }
          wk.children = null;
        }
      }
      return res;
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
}
