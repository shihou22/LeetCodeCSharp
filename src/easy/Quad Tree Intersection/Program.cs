using System;
using System.Collections.Generic;

namespace Quad_Tree_Intersection
{
    public class Node
    {
        public bool val;
        public bool isLeaf;
        public Node topLeft;
        public Node topRight;
        public Node bottomLeft;
        public Node bottomRight;

        public Node() { }
        public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
            }
            public Node Intersect(Node quadTree1, Node quadTree2)
            {
                Node result = new Node();
                DFS(quadTree1, quadTree2, result);
                return result;
            }
            private void DFS(Node quadTree1, Node quadTree2, Node result)
            {
                if (quadTree1 == null || quadTree2 == null)
                    return;

                result.val = false;
                result.isLeaf = false;
                if (quadTree1.isLeaf || quadTree2.isLeaf)
                {
                    result.val = quadTree1.val | quadTree2.val;
                    result.isLeaf = true;
                    return;
                }

                if (quadTree1.topLeft != null && quadTree2.topLeft != null)
                {
                    result.topLeft = new Node();
                    DFS(quadTree1.topLeft, quadTree2.topLeft, result.topLeft);
                    result.topRight = new Node();
                    DFS(quadTree1.topRight, quadTree2.topRight, result.topRight);
                    result.bottomLeft = new Node();
                    DFS(quadTree1.bottomLeft, quadTree2.bottomLeft, result.bottomLeft);
                    result.bottomRight = new Node();
                    DFS(quadTree1.bottomRight, quadTree2.bottomRight, result.bottomRight);
                }
            }

        }
    }
