using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Vertical_Order_Traversal_of_a_Binary_Tree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    class TreeNodeFactory
    {
        public static TreeNode CreateTree(string[] nums)
        {
            if (nums == null)
                return null;
            TreeNode res = new TreeNode(int.Parse(nums[0]));
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(res);
            int index = 1;
            while (nodes.Count > 0)
            {
                int cnt = nodes.Count;
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode root = nodes.Dequeue();
                    if (root == null)
                        continue;
                    root.left = GetNode(nums, index++);
                    root.right = GetNode(nums, index++);
                    nodes.Enqueue(root.left);
                    nodes.Enqueue(root.right);
                }
            }
            return res;
        }
        private static TreeNode GetNode(string[] nums, int n)
        {
            if (n >= nums.Length)
                return null;
            if (nums[n] == null)
                return null;
            return new TreeNode(int.Parse(nums[n]));
        }
        public static string ResultStr(TreeNode node)
        {
            StringBuilder builder = new StringBuilder();
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            while (nodes.Count > 0)
            {
                int cnt = nodes.Count;
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode wk = nodes.Dequeue();
                    if (wk == null)
                    {
                        builder.Append("null").Append(" ");
                    }
                    else
                    {
                        builder.Append(wk.val).Append(" ");
                        nodes.Enqueue(wk.left);
                        nodes.Enqueue(wk.right);
                    }
                }
            }
            return builder.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            //[[9],[3,15],[20],[7]]
            // TreeNode root1 = TreeNodeFactory.CreateTree(new string[] { "3", "9", "20", null, null, "15", "7" });
            // var res1 = program.VerticalTraversal(root1);

            // TreeNode root2 = TreeNodeFactory.CreateTree(new string[] { "1", "2", "3", "4", "5", "6", "7" });
            // var res2 = program.VerticalTraversal(root2);

            //[[8],[0,3,6],[1,4,5],[2,7]]
            TreeNode root3 = TreeNodeFactory.CreateTree(new string[] { "0", "8", "1", null, null, "3", "2", null, "4", "5", null, null, "7", "6" });
            var res3 = program.VerticalTraversal(root3);

            //[[9,7],[5,6],[0,2,4],[1,3],[8]]
            // TreeNode root4 = TreeNodeFactory.CreateTree(new string[] { "0", "5", "1", "9", null, "2", null, null, null, null, "3", "4", "8", "6", null, null, null, "7" });
            // var res4 = program.VerticalTraversal(root4);
            Console.WriteLine("Hello World!");
        }
        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            List<int[]> map = new List<int[]>();
            DFS2(map, root, 0, 0);
            map.Sort((x, y) => x[0].CompareTo(y[0]) == 0 ? x[1].CompareTo(y[1]) == 0 ? x[2].CompareTo(y[2]) : x[1].CompareTo(y[1]) : x[0].CompareTo(y[0]));
            int prev = map[0][0];
            IList<IList<int>> res = new List<IList<int>>();
            var tmpOrd = map.GroupBy(x => x[0]);
            foreach (var item in tmpOrd)
            {
                IList<int> wk = new List<int>();
                foreach (var wkI in item)
                {
                    wk.Add(wkI[2]);
                }
                res.Add(wk);
            }
            return res;
        }
        private void DFS2(List<int[]> map, TreeNode node, int x, int y)
        {
            if (node == null)
                return;

            map.Add(new int[] { x, y, node.val });
            DFS2(map, node.left, x - 1, y + 1);
            DFS2(map, node.right, x + 1, y + 1);
        }
        public IList<IList<int>> VerticalTraversalDFS(TreeNode root)
        {
            Dictionary<int, List<Tuple<int, int>>> map = new Dictionary<int, List<Tuple<int, int>>>();
            IList<IList<int>> res = new List<IList<int>>();
            DFS(map, root, 0, 0);
            foreach (var item in map.OrderBy(x => x.Key))
            {
                item.Value.Sort((x, y) => x.Item1.CompareTo(y.Item1) == 0 ? x.Item2.CompareTo(y.Item2) : x.Item1.CompareTo(y.Item1));
                var tmp = item.Value.Select(x => x.Item2).ToList();
                res.Add(tmp);
            }
            return res;
        }
        private void DFS(Dictionary<int, List<Tuple<int, int>>> map, TreeNode node, int x, int y)
        {
            if (node == null)
                return;

            map.TryAdd(x, new List<Tuple<int, int>>());
            map[x].Add(new Tuple<int, int>(y, node.val));
            DFS(map, node.left, x - 1, y + 1);
            DFS(map, node.right, x + 1, y + 1);
        }
    }
}
