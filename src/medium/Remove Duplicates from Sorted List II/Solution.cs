using System;
using System.Collections.Generic;

namespace Remove_Duplicates_from_Sorted_List_II
{
    class Solution
    {
        static void Main(string[] args)
        {
            // ListNode root = new ListNode(1);
            // root.next = new ListNode(2);
            // root.next.next = new ListNode(3);
            // root.next.next.next = new ListNode(3);
            // root.next.next.next.next = new ListNode(4);
            // root.next.next.next.next.next = new ListNode(4);
            // root.next.next.next.next.next.next = new ListNode(5);
            // Solution solution = new Solution();
            // ListNode res = null;
            // res = solution.DeleteDuplicates(root);
            ListNode root = new ListNode(1);
            root.next = new ListNode(1);
            root.next.next = new ListNode(1);
            root.next.next.next = new ListNode(2);
            root.next.next.next.next = new ListNode(3);
            Solution solution = new Solution();
            ListNode res = null;
            res = solution.DeleteDuplicates(root);
            Console.WriteLine("Hello World!");
        }
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode res = new ListNode(-1);
            res.next = head;
            ListNode node = res;
            while (node.next != null)
            {
                ListNode wk = node.next;
                //refを進める
                while (wk != null && wk.next != null && wk.val == wk.next.val)
                {
                    wk = wk.next;
                }
                //参照の変更があるならrefが進んでいるため、wkの位置を.nextに変更
                //変更がないならそのままnextに進めるのみ
                if (wk != node.next)
                    node.next = wk.next;
                else
                    node = node.next;

            }
            return res.next;
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
