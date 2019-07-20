using System;

namespace Add_Two_Numbers
{
    class Solution
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carry = 0;
            if (l1 != null)
            {
                carry += l1.val;
                l1 = l1.next;
            }
            if (l2 != null)
            {
                carry += l2.val;
                l2 = l2.next;
            }
            ListNode l3 = new ListNode(carry % 10);
            ListNode res = l3;
            carry /= 10;
            while (l1 != null || l2 != null)
            {
                if (l1 != null)
                {
                    carry += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    carry += l2.val;
                    l2 = l2.next;
                }
                l3.next = new ListNode(carry % 10);
                l3 = l3.next;
                carry /= 10;
            }
            if (carry != 0)
            {
                l3.next = new ListNode(carry % 10);
            }
            return res;
        }
    }
}
