using System;
using System.Collections.Generic;

namespace Middle_of_the_Linked_List
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        public ListNode MiddleNode(ListNode head)
        {
            ListNode one = head;
            ListNode two = head;
            while (two != null && two.next != null)
            {
                one = one.next;
                two = two.next.next;
            }
            return one;
        }
        public ListNode MiddleNodeUseList(ListNode head)
        {
            IList<ListNode> res = new List<ListNode>();
            while (head != null)
            {
                res.Add(head);
                head = head.next;
            }
            int middle = res.Count % 2 == 0 ? res.Count / 2 + 1 : res.Count / 2;
            return res[middle];
        }
    }
}
