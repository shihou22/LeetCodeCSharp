using System;
using System.Collections.Generic;

namespace N_ary_Tree_Level_Order_Traversal
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
    class Solution
    {
      static void Main(string[] args)
      {
        Console.WriteLine("Hello World!");
      }
      public IList<IList<int>> LevelOrder(Node root)
      {
        IList<IList<int>> res = new List<IList<int>>();
        if (root == null)
          return res;
        Queue<Node> nodes = new Queue<Node>();
        nodes.Enqueue(root);
        while (nodes.Count > 0)
        {
          int count = nodes.Count;
          IList<int> tmp = new List<int>();
          for (int i = 0; i < count; i++)
          {
            Node _node = nodes.Dequeue();
            tmp.Add(_node.val);
            if (_node.children != null)
            {
              foreach (var item in _node.children)
              {
                nodes.Enqueue(item);
              }
            }
          }
          res.Add(tmp);
        }
        return res;
      }
    }
  }
