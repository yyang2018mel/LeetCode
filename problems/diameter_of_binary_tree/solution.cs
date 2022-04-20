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

internal static class TreeExtensions 
{
    internal static bool IsLeaf(this TreeNode node)
    {
        return node is not null && node.left is null && node.right is null;
    }
}

public class Solution 
{

    private int _diameter;
    
    private int DepthFirstTraversal(TreeNode node)
    {
        if (node.IsLeaf())
        {
            return 0;
        }
        
        var leftLocalPathLen = 
            node.left is null
            ? 0
            : DepthFirstTraversal(node.left)+1;
        var rightLocalPathLen = 
            node.right is null
            ? 0
            : DepthFirstTraversal(node.right)+1;
        
        _diameter = Math.Max(_diameter, leftLocalPathLen+rightLocalPathLen);
        
        return Math.Max(leftLocalPathLen, rightLocalPathLen);
    }
    
    public int DiameterOfBinaryTree(TreeNode root) 
    {
        _ = DepthFirstTraversal(root);
        return _diameter;
    }
}