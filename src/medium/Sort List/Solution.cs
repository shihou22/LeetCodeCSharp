using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort_List
{
  class Solution
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    static int[] _heapList;

    public ListNode SortList(ListNode head)
    {
      // build heap and sort it
      HeapLList(head);

      // save head of list
      ListNode tmpHead = head;

      // convert array to linked list
      foreach (int x in _heapList)
      {
        tmpHead.val = x;
        tmpHead = tmpHead.next;
      }

      // return sorted linked list
      return head;
    }

    public void HeapLList(ListNode Head)
    {
      ListNode tmpHead = Head;
      int i = 0,
          last;


      // get length of list
      //Console.Write("\nList looks like: \n");
      while (tmpHead != null)
      {
        //  Console.Write($" {tmpHead.Value} ");
        tmpHead = tmpHead.next;
        i++;
      }

      // conver list to array
      _heapList = ListToArray(Head, i);

      //Console.Write("\nbefore sorint array looks like:  \n");
      //foreach (int x in arr)
      //{
      //    Console.Write($" {x} ");
      //}
      //Console.Write("\n");

      // build heap
      last = i / 2 - 1;

      /*
      この時点のiは最後の位置

       */
      while (last >= 0)
      {
        Heapify(_heapList, last, i);
        last--;
      }


      //Console.Write("\nAfter heapify of data:  \n");
      //foreach (int x in arr)
      //{
      //    Console.Write($" {x} ");
      //}
      //Console.Write("\n");

      last = i - 1;

      // traverse heap binary tree
      // and heapify, which will
      // sort whole tree
      while (last > 0)
      {
        swap(_heapList, 0, last);
        Heapify(_heapList, last, 0);
        last--;
      }

      //Console.Write("\nAfter Sorting list looks like:  \n");
      //foreach (int x in arr)
      //{
      //    Console.Write($" {x} ");
      //}
      //Console.Write("\n");
    }


    // sort each tree node compared to its children
    public void Heapify(int[] arr, int start, int size)
    {
      int largest = start; // node
      int left = 2 * start + 1; // left child
      int right = 2 * start + 2; // right child

      // is left child bigger than parent?
      if (left < size && arr[left] > arr[largest])
        largest = left;

      // is right child bigger than parent
      // then if so take right child
      if (right < size && arr[right] > arr[largest])
        largest = right;

      // is the root node the same as the largest
      // node?  If so we are done
      // else swap and try again, so we can
      // ensure the other child is not bigger
      if (start != largest)
      {
        // swap parent and child
        swap(arr, largest, start);

        // try again
        Heapify(arr, size, largest);
      }
    }
    public static void swap(int[] arr, int i1, int i2)
    {
      int tmp = arr[i1];
      arr[i1] = arr[i2];
      arr[i2] = tmp;
    }
    public static int[] ListToArray(ListNode head, int size)
    {
      int[] wk = new int[size];
      int cnt = 0;
      while (head != null)
      {
        wk[cnt] = head.val;
        head = head.next;
      }
      return wk;
    }
    public ListNode SortListOld(ListNode head)
    {
      if (head == null)
        return null;
      List<int> vals = new List<int>();
      while (head != null)
      {
        vals.Add(head.val);
        head = head.next;
      }
      vals.Sort();

      ListNode root = new ListNode(vals[0]);
      ListNode wk = root;
      for (int i = 1; i < vals.Count; i++)
      {
        ListNode tmp = new ListNode(vals[i]);
        wk.next = tmp;
        wk = wk.next;
      }
      return root;
    }

  }
  public class ListNode
  {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
  }
}
