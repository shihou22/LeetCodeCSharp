using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Rotate_List
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class ListFactory
    {
        public static ListNode CreateList(int[] nums)
        {
            if (nums == null)
                return null;
            ListNode res = new ListNode(-1);
            ListNode node = res;
            for (int i = 0; i < nums.Length; i++)
            {
                node.next = new ListNode(nums[i]);
                node = node.next;
            }
            return res.next;
        }
        public static string ResultStr(ListNode node)
        {
            IList<string> nodes = new List<string>();
            while (node != null)
            {
                nodes.Add(Convert.ToString(node.val));
                node = node.next;
            }
            return string.Join(", ", nodes.ToArray());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            ListNode res = null;
            ListNode node = null;
            node = ListFactory.CreateList(new int[] { 1, 2, 3, 4, 5 });
            res = program.RotateRight(node, 6);
            Console.WriteLine(ListFactory.ResultStr(res));

            node = ListFactory.CreateList(new int[] { 1, 2, 3, 4, 5 });
            res = program.RotateRight(node, 10);
            Console.WriteLine(ListFactory.ResultStr(res));

            node = ListFactory.CreateList(new int[] { 0, 1, 2 });
            res = program.RotateRight(node, 4);
            Console.WriteLine(ListFactory.ResultStr(res));

            node = ListFactory.CreateList(new int[] { 1 });
            res = program.RotateRight(node, 0);
            Console.WriteLine(ListFactory.ResultStr(res));

            node = ListFactory.CreateList(null);
            res = program.RotateRight(node, 1);
            Console.WriteLine(ListFactory.ResultStr(res));

            node = ListFactory.CreateList(new int[] { 1, 2 });
            res = program.RotateRight(node, 3);
            Console.WriteLine(ListFactory.ResultStr(res));

            Console.WriteLine("Hello World!");
        }
        public ListNode RotateRight(ListNode head, int k)
        {

            ListNode first = head;
            ListNode last = null;
            int cnt = 0;
            while (first != null)
            {
                cnt++;
                if (first.next == null)
                    last = first;
                first = first.next;
            }

            if (k == 0 || cnt == 0 || cnt == 1 || k % cnt == 0)
                return head;

            int f = (cnt < k) ? (cnt - k % cnt) : (cnt - k);
            first = head;
            for (int i = 0; i < f - 1; i++)
            {
                first = first.next;
            }

            ListNode res = null;
            if (first != null)
            {
                res = first.next;
                last.next = head;
                first.next = null;
            }
            return res;
        }
    }
}
