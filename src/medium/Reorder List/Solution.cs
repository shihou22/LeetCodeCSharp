using System;
using System.Collections.Generic;

namespace Reorder_List
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      ListNode root = new ListNode(1);
    //   root.next = new ListNode(2);
    //   root.next.next = new ListNode(3);
    //   root.next.next.next = new ListNode(4);
    //   root.next.next.next.next = new ListNode(5);
      solution.ReorderList(root);
      Console.WriteLine("Hello World!");
    }
    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
    }
    public void ReorderList(ListNode head)
    {
      IList<ListNode> nodes = new List<ListNode>();
      ListNode res = new ListNode(-1);
      res.next = head;
      while (head != null)
      {
        nodes.Add(head);
        head = head.next;
        nodes[nodes.Count - 1].next = null;
      }
      int min = 0;
      int max = nodes.Count - 1;
      for (int i = 0; min <= max; i++)
      {
        if (i % 2 == 0)
        {
          res.next = nodes[min];
          min++;
        }
        else
        {
          res.next = nodes[max];
          max--;
        }
        res = res.next;
      }
      //
    }
  }
}
