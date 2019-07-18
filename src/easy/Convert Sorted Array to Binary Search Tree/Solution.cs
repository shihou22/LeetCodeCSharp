using System;

namespace Convert_Sorted_Array_to_Binary_Search_Tree
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return DFS(nums, 0, nums.Length - 1);
        }

        private TreeNode DFS(int[] nums, int left, int right)
        {
            if (left > right)
                return null;

            int mid = (left + right) / 2;
            var root = new TreeNode(nums[mid]);
            var leftNode = DFS(nums, left, mid - 1);
            var rightNode = DFS(nums, mid + 1, right);
            root.left = leftNode;
            root.right = rightNode;
            return root;
        }

    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
