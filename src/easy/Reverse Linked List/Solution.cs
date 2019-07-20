using System;
using System.Collections;
using System.Collections.Generic;

namespace Reverse_Linked_List
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            ListNode root = new ListNode(5);
            ListNode rootWk = root;
            rootWk.next = new ListNode(4);
            rootWk = rootWk.next;
            rootWk.next = new ListNode(3);
            rootWk = rootWk.next;
            rootWk.next = new ListNode(2);
            rootWk = rootWk.next;
            rootWk.next = new ListNode(1);
            rootWk = rootWk.next;
            ListNode res = solution.ReverseList(root);
            Console.WriteLine("Hello World!");
        }

        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            Stack<ListNode> stack = new Stack<ListNode>();
            while (head != null)
            {
                stack.Push(head);
                head = head.next;
            }
            ListNode res = stack.Pop();
            ListNode wk = res;
            while (stack.Count > 0)
            {
                wk.next = stack.Pop();
                wk = wk.next;
                /*
                Popしたものをそのまま使うと循環参照でTLE起こすのでnewしている
                */
                // ListNode tmp = stack.Pop();
                // wk.next = new ListNode(tmp.val);
                // wk = wk.next;

                /*
                Popしたものをそのまま使うと循環参照でTLE起こすが、
                最後の一つのnextを切れば循環を切れる。
                newではなくてこちらでもOK
                 */
                if (stack.Count == 0)
                    wk.next = null;
            }
            return res;
        }

        /*
        use recursive
         */
        public ListNode ReverseListDFS(ListNode head)
        {
            if (head == null)
                return null;
            ListNode res = new ListNode(head.val);
            return dfs(head.next, res);
        }

        private ListNode dfs(ListNode baseNode, ListNode root)
        {
            if (baseNode == null)
                return root;

            ListNode res = new ListNode(baseNode.val);
            res.next = root;

            return dfs(baseNode.next, res);
        }

        /*
        use while
         */
        public ListNode ReverseListWhile(ListNode head)
        {
            ListNode res = new ListNode(-1);

            while (head != null)
            {
                ListNode tmp = new ListNode(head.val);
                tmp.next = res.next;
                res.next = tmp;
                head = head.next;
            }
            return res.next;
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
