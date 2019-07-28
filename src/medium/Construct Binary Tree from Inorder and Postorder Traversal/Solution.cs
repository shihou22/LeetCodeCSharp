using System.Collections.Generic;
using System;

namespace Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      TreeNode node = null;
      //   node = solution.BuildTree(new int[] { 9, 3, 15, 20, 7 }, new int[] { 9, 15, 7, 20, 3 });
      node = solution.BuildTree(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 });
      Console.WriteLine("Hello World!");
    }
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
      if (inorder == null || inorder.Length == 0
      || postorder == null || postorder.Length == 0)
      {
        return null;
      }
      this._inorder = inorder;
      this._postorder = postorder;
      for (int i = 0; i < _inorder.Length; i++)
        _inMap.Add(_inorder[i], i);

      for (int i = 0; i < _postorder.Length; i++)
        _posMap.Add(_postorder[i], i);

      int root = _inMap[_postorder[_postorder.Length - 1]];
      int leftS = 0;
      int leftE = root - 1 > 0 ? root - 1 : 0;
      int rightS = root + 1 < _inorder.Length - 1 ? root + 1 : _inorder.Length - 1;
      int rightE = _inorder.Length - 1;
      return DFS(root, leftS, leftE, rightS, rightE);
    }
    int[] _inorder;
    Dictionary<int, int> _inMap = new Dictionary<int, int>();
    int[] _postorder;
    Dictionary<int, int> _posMap = new Dictionary<int, int>();

    private TreeNode DFS(int rootI, int leftS, int leftE, int rightS, int rightE)
    {
      TreeNode rootNode = new TreeNode(_inorder[rootI]);
      int rootIndex = -1;
      int wkLeftS = 0;
      int wkLeftE = 0;
      int wkRightS = 0;
      int wkRightE = 0;
      if (leftS != rootI && leftE != rootI)
      {
        for (int i = leftS; i <= leftE; i++)
        {
          var tmp = _inorder[i];
          if (_posMap[tmp] > rootIndex)
            rootIndex = _posMap[tmp];
        }
        rootIndex = _inMap[_postorder[rootIndex]];
        wkLeftS = leftS;
        wkLeftE = rootIndex - 1 <= leftS ? leftS : rootIndex - 1;
        wkRightS = rootIndex + 1 >= leftE ? leftE : rootIndex + 1;
        wkRightE = leftE;
        rootNode.left = DFS(rootIndex, wkLeftS, wkLeftE, wkRightS, wkRightE);
      }

      if (rightS != rootI && rightE != rootI)
      {
        rootIndex = -1;
        for (int i = rightS; i <= rightE; i++)
        {
          var tmp = _inorder[i];
          if (_posMap[tmp] > rootIndex)
            rootIndex = _posMap[tmp];
        }
        rootIndex = _inMap[_postorder[rootIndex]];
        wkLeftS = rightS;
        wkLeftE = rootIndex - 1 <= rightS ? rightS : rootIndex - 1;
        wkRightS = rootIndex + 1 >= rightE ? rightE : rootIndex + 1;
        wkRightE = rightE;

        rootNode.right = DFS(rootIndex, wkLeftS, wkLeftE, wkRightS, wkRightE);
      }

      return rootNode;
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
