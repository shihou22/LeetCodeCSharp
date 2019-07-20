using System.Collections.Generic;
using System;

namespace Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      TreeNode root = null;
      //   root = solution.BuildTree(new int[] { 3, 9, 20, 15, 7 }, new int[] { 9, 3, 15, 20, 7 });
      root = solution.BuildTree(new int[] { 1, 2 }, new int[] { 2, 1 });
      Console.WriteLine("Hello World!");
    }

    // preorder = [3,9,20,15,7]
    // inorder = [9,3,15,20,7]

    private int[] _preorder;
    private Dictionary<int, int> preMap = new Dictionary<int, int>();
    private int[] _inorder;
    private Dictionary<int, int> inMap = new Dictionary<int, int>();
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
      if (preorder == null || preorder.Length == 0
      || inorder == null || inorder.Length == 0)
        return null;

      this._preorder = preorder;
      this._inorder = inorder;
      for (int i = 0; i < preorder.Length; i++)
        preMap.Add(preorder[i], i);

      for (int i = 0; i < inorder.Length; i++)
        inMap.Add(inorder[i], i);

      int rootIndex = 0;
      int leftStart = 0;
      int leftEnd = inMap[preorder[0]] - 1 < 0 ? 0 : inMap[preorder[0]] - 1;
      int rightStart = inMap[preorder[0]] + 1 >= inorder.Length ? inorder.Length - 1 : inMap[preorder[0]] + 1;
      int righttEnd = inorder.Length - 1;
      TreeNode root = GetRoot(inMap[_preorder[rootIndex]], leftStart, leftEnd, rightStart, righttEnd);
      return root;
    }
    private TreeNode GetRoot(int rootIndex, int lS, int lE, int rS, int rE)
    {
      TreeNode root = new TreeNode(_inorder[rootIndex]);
      if (rootIndex == lS && rootIndex == lE && rootIndex == rS && rootIndex == rE)
        return root;

      var tmpLRoot = int.MaxValue;
      for (int i = lS; i <= lE; i++)
        tmpLRoot = Math.Min(preMap[_inorder[i]], tmpLRoot);

      var lRoot = inMap[_preorder[tmpLRoot]];
      var wklE1 = lS < lRoot ? lRoot - 1 : lRoot;
      var wkrS1 = lE > lRoot ? lRoot + 1 : lRoot;
      if (rootIndex != lRoot)
        root.left = GetRoot(lRoot, lS, wklE1, wkrS1, lE);

      var tmpRRoot = int.MaxValue;
      for (int i = rS; i <= rE; i++)
        tmpRRoot = Math.Min(preMap[_inorder[i]], tmpRRoot);

      var rRoot = inMap[_preorder[tmpRRoot]];
      var wklE2 = rS < rRoot ? rRoot - 1 : rRoot;
      var wkrS2 = rE > rRoot ? rRoot + 1 : rRoot;
      if (rootIndex != rRoot)
        root.right = GetRoot(rRoot, rS, wklE2, wkrS2, rE);

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

