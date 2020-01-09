using System;

namespace Swap_Nodes_in_Pairs
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
            ListNode root = new ListNode(1);
            root.next = new ListNode(2);
            root.next.next = new ListNode(3);
            root.next.next.next = new ListNode(4);
            Program program = new Program();
            program.SwapPairs(root);
            Console.WriteLine("Hello World!");
        }
        public ListNode SwapPairs(ListNode head)
        {
            ListNode node = new ListNode(-1);
            node.next = head;
            ListNode dummy = node;
            while (node != null && node.next != null)
            {
                ListNode wk = node.next;
                ListNode tmp = node.next.next;
                if (tmp != null)
                {
                    wk.next = node.next.next.next;
                    tmp.next = wk;
                    node.next = tmp;
                }
                node = node.next.next;
            }
            return dummy.next;
        }
    }
}
