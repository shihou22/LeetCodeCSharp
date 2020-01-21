using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Odd_Even_Linked_List
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class ListNodeFactory
    {
        public static ListNode CreateListNode(string nums, string delm)
        {
            if (nums == null)
                return null;
            string[] tmp = nums.Split(delm);
            List<int> res = new List<int>();
            foreach (var item in tmp)
            {
                int number;
                if (int.TryParse(item, out number))
                    res.Add(number);
            }

            return CreateTree(res.ToArray());
        }
        public static ListNode CreateTree(int[] nums)
        {
            if (nums == null)
                return null;
            ListNode res = new ListNode(-1);
            ListNode wk = res;
            for (int i = 0; i < nums.Length; i++)
            {
                wk.next = new ListNode(nums[i]);
                wk = wk.next;
            }
            return res.next;
        }
        public static string ResultStr(ListNode node)
        {
            StringBuilder builder = new StringBuilder();
            while (node != null)
            {
                builder.Append(node.val).Append("-");
                node = node.next;
            }
            return builder.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            ListNode res = null;
            res = ListNodeFactory.CreateListNode("1->2->3->4->5->NULL", "->");
            res = program.OddEvenList(res);
            Console.WriteLine(ListNodeFactory.ResultStr(res));
            res = ListNodeFactory.CreateListNode("2->1->3->5->6->4->7->NULL", "->");
            res = program.OddEvenList(res);
            Console.WriteLine(ListNodeFactory.ResultStr(res));
            res = ListNodeFactory.CreateListNode("2->1->NULL", "->");
            res = program.OddEvenList(res);
            Console.WriteLine(ListNodeFactory.ResultStr(res));
            res = ListNodeFactory.CreateListNode("2->NULL", "->");
            res = program.OddEvenList(res);
            Console.WriteLine(ListNodeFactory.ResultStr(res));
            Console.WriteLine("Hello World!");
        }
        public ListNode OddEvenList(ListNode head)
        {
            ListNode odd = head;
            ListNode even = head.next;
            ListNode res = even;
            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }
            odd.next = res;
            return head;
        }
        public ListNode OddEvenListDFS(ListNode head)
        {
            ListNode res = new ListNode(-1);
            ListNode odd = new ListNode(-1);
            ListNode even = new ListNode(-1);
            res.next = head;
            if (head == null || head.next == null)
                return head;
            int total = GetList(res.next, odd, even, 0);
            res.next = even.next;
            ListNode evenW = even;
            while (evenW.next != null)
            {
                evenW = evenW.next != null ? evenW.next : evenW;
            }
            evenW.next = odd.next;
            return res.next;
        }

        private int GetList(ListNode head, ListNode odd, ListNode even, int num)
        {
            if (head == null)
            {
                odd.next = null;
                even.next = null;
                return num;
            }
            if ((num & 1) == 0)
            {
                even.next = head;
                even = even.next;
            }
            else
            {
                odd.next = head;
                odd = odd.next;
            }
            head = head.next;
            return GetList(head, odd, even, num + 1);
        }
    }
}
