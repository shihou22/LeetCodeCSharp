using System;
using System.Collections.Generic;

namespace Flatten_a_Multilevel_Doubly_Linked_List
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public class Node
        {
            public int val;
            public Node prev;
            public Node next;
            public Node child;

            public Node() { }
            public Node(int _val, Node _prev, Node _next, Node _child)
            {
                val = _val;
                prev = _prev;
                next = _next;
                child = _child;
            }
            public Node Flatten(Node head)
            {
                if (head == null)
                    return null;
                Stack<Node> stack = new Stack<Node>();
                // IList<Node> wkList = new List<Node>();
                Node wkListNode = null;
                //return用を準備しておかないと参照先が不明になる。
                Node res = head;
                stack.Push(head);
                while (stack.Count > 0)
                {
                    Node wk = stack.Pop();
                    if (wk == null)
                        continue;
                    // if (wkList.Count > 0)
                    if (wkListNode != null)
                    {
                        // Node conNode = wkList[wkList.Count - 1];
                        Node conNode = wkListNode;
                        conNode.next = wk;
                        wk.prev = conNode;
                        conNode.child = null;
                    }
                    // wkList.Add(wk);
                    wkListNode = wk;
                    stack.Push(wk.next);
                    stack.Push(wk.child);
                }
                // return wkList[0];
                return res;
            }
        }
    }
}
