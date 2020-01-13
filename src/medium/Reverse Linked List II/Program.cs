using System;
using System.Collections.Generic;

namespace Reverse_Linked_List_II
{
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
      Program Program = new Program();
      ListNode node = new ListNode(1);
      node.next = new ListNode(2);
      node.next.next = new ListNode(3);
      node.next.next.next = new ListNode(4);
      node.next.next.next.next = new ListNode(5);
      Program.ReverseBetween(node, 2, 4);
      //   ListNode node = new ListNode(3);
      //   node.next = new ListNode(4);
      //   Program.ReverseBetween(node, 1, 2);
      //   ListNode node = new ListNode(1);
      //   node.next = new ListNode(2);
      //   node.next.next = new ListNode(3);
      //   node.next.next.next = new ListNode(4);
      //   Program.ReverseBetween(node, 1, 4);
      Console.WriteLine("Hello World!-Reverse");
    }
    public ListNode ReverseBetween(ListNode head, int m, int n)
    {
      ListNode dummy = new ListNode(-1);
      dummy.next = head;
      List<ListNode> list = new List<ListNode>();
      helperDummy(dummy, null, null, new ListNode(-1), m, n, 0);
      return dummy.next;
    }

    public void helperDummy(ListNode head, ListNode mm1, ListNode mm, ListNode prev, int m, int n, int curr)
    {
      if (curr + 1 == m)
        mm1 = head;
      if (curr == m)
        mm = head;

      if (curr == n + 1)
      {
        mm1.next = prev;
        mm.next = head;
        return;
      }
      ListNode wkNext = head.next;
      if (m <= curr && curr <= n)
      {
        head.next = prev;
      }

      helperDummy(wkNext, mm1, mm, head, m, n, curr + 1);
    }
    public ListNode ReverseBetweenNotOnePath(ListNode head, int m, int n)
    {
      ListNode dummy = new ListNode(-1);
      dummy.next = head;
      List<ListNode> list = new List<ListNode>();
      helper(dummy, list, m, n, 0);
      return dummy.next;
    }

    public void helper(ListNode head, List<ListNode> list, int m, int n, int curr)
    {
      if (curr > n + 1)
      {
        for (int i = n; i >= m; i--)
        {
          list[i].next = list[i - 1];
        }
        list[m - 1].next = list[n];
        list[m].next = list[n + 1];
        return;
      }
      list.Add(head);
      if (head == null)
        helper(head, list, m, n, curr + 1);
      else
        helper(head.next, list, m, n, curr + 1);
    }
  }
}
