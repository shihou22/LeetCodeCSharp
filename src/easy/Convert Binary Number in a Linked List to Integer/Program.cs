using System;

namespace Convert_Binary_Number_in_a_Linked_List_to_Integer
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
            Program program = new Program();
            ListNode node = new ListNode(1);
            node.next = new ListNode(0);
            node.next.next = new ListNode(1);
            Console.WriteLine(program.GetDecimalValue(node));
            Console.WriteLine(program.GetDecimalValue2(node));
            Console.WriteLine("Hello World!");
        }

        public int GetDecimalValue(ListNode head)
        {
            int cnt = 0;
            ListNode node = head;
            while (node != null)
            {
                cnt++;
                node = node.next;
            }
            int res = 0;
            node = head;
            while (node != null)
            {
                int dig = node.val;
                res += dig * (int)Math.Pow(2, --cnt);
                node = node.next;
            }
            return res;
        }
        public int GetDecimalValue2(ListNode head)
        {
            int res = 0;
            while (head != null)
            {
                res <<= 1;
                res += head.val;
                head = head.next;
            }
            return res;
        }
    }
}
