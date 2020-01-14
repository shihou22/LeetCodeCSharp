using System;

namespace Partition_List
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
            // ListNode root = new ListNode(1);
            // root.next = new ListNode(4);
            // root.next.next = new ListNode(3);
            // root.next.next.next = new ListNode(2);
            // root.next.next.next.next = new ListNode(5);
            // root.next.next.next.next.next = new ListNode(2);
            // var res = program.Partition(root, 3);

            ListNode root = new ListNode(1);
            root.next = new ListNode(4);
            root.next.next = new ListNode(4);
            root.next.next.next = new ListNode(4);
            root.next.next.next.next = new ListNode(3);
            root.next.next.next.next.next = new ListNode(2);
            root.next.next.next.next.next.next = new ListNode(5);
            root.next.next.next.next.next.next.next = new ListNode(2);
            var res = program.Partition(root, 3);

            // ListNode root = new ListNode(2);
            // root.next = new ListNode(1);
            // var res = program.Partition(root, 2);

            // ListNode root = new ListNode(1);
            // root.next = new ListNode(2);
            // root.next.next = new ListNode(3);
            // var res = program.Partition(root, 4);
            Console.WriteLine("Hello World!");
        }
        public ListNode Partition(ListNode head, int x)
        {
            ListNode wk = new ListNode(int.MinValue);
            wk.next = head;
            ListNode res = null;

            res = helper(null, wk, head, x);
            return wk.next;

        }

        private ListNode helper(ListNode prev, ListNode parent, ListNode head, int x)
        {
            if (head == null)
                return null;
            ListNode wkPrev = prev;
            if (prev == null && parent.val < x && head.val >= x)
            {
                wkPrev = parent;
            }
            ListNode wkHead = head;
            ListNode wkHeadNext = head.next;
            if (prev != null && parent.val >= x && wkHead.val < x)
            {
                /*
                DUMMY parent
                親の値はx以上であればよい=次のheadと同じ値であればよい
                本当は、parentのparentがいるといいんだけど。。。
                4 ,4 ,3 ,2と来ている場合、
                2 ,4, 4, 3と変更している。
                実際のところ、3(=head)の前にある4の並び順にも値にも意味がない。
                x=3であれば、3以上の値であればいいから。
                prevは2の後ろとしてとっているし、3の位置は3以上であることが保証されているので、
                2の後ろ以降、3より前の値は3以上であればよい。となる。
                そのため、parentにdummy値を入れても問題がなくなる。
                */
                wkHead = new ListNode(parent.val);
                // wkHead = prev.next;
                // wkHeadNext = prev.next != null ? prev.next.next : null; //TLE
                wkHeadNext = parent;
                parent.next = head.next;
                head.next = prev.next;
                prev.next = head;
                wkPrev = prev.next;
            }
            return helper(wkPrev, wkHead, wkHeadNext, x);
        }
    }
}
