/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

internal static class TreeEx
{
    internal static bool IsLeaf(this TreeNode node) =>
        node is not null && node.left is null && node.right is null;
}


public class Solution 
{
    private int _targetSum;
    
    private bool PreOrderTraverse(TreeNode node, int pathLenSoFar = 0)
    {
        if (node is null) return false;
        
        if (node.IsLeaf()) return pathLenSoFar+node.val == _targetSum;
        
        var hasPathInLeft  = PreOrderTraverse(node.left, pathLenSoFar + node.val);
        var hasPathInRight = PreOrderTraverse(node.right, pathLenSoFar + node.val); 
        return hasPathInLeft || hasPathInRight;
        
    }
    
    
    public bool HasPathSum(TreeNode root, int targetSum) 
    {
        _targetSum = targetSum;
        
        return PreOrderTraverse(root);
    }
}