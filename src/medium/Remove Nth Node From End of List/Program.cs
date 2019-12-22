using System;
using System.Collections.Generic;

namespace Remove_Nth_Node_From_End_of_List
{

  //Definition for singly-linked list.
  public class ListNode
  {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
      IList<ListNode> nodes = new List<ListNode>();
      ListNode dummy = new ListNode(-1);
      dummy.next = head;
      while (head != null)
      {
        nodes.Add(head);
        head = head.next;
      }
      Console.WriteLine("nodes.Count:" + nodes.Count);
      if (nodes.Count == n)
      {
        if (n <= 1)
          dummy.next = null;
        else
          dummy.next = nodes[nodes.Count - (n - 1)];
      }
      else if (nodes.Count < n)
      {
        return null;
      }
      else
      {
        if (n <= 1)
          nodes[nodes.Count - (n + 1)].next = null;
        else
          nodes[nodes.Count - (n + 1)].next = nodes[nodes.Count - (n - 1)];
      }
      return dummy.next;

    }
  }
}
