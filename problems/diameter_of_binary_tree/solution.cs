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
        return 
            node is not null &&
            node.left is null &&
            node.right is null;
    }
}

public class Solution 
{
    private int diameter;
    
    private int DepthFirstTraversal(TreeNode node, int depth)
    {
        if(node is null) return depth-1;
        
        if(node.IsLeaf()) return depth;
        
        var l = DepthFirstTraversal(node.left, depth+1);
        var r = DepthFirstTraversal(node.right, depth+1);
        diameter = Math.Max(diameter, l+r-2*depth);
        
        return Math.Max(l,r);
    }
    
    public int DiameterOfBinaryTree(TreeNode root) 
    {
        _ = DepthFirstTraversal(root, 0);
        return diameter;
    }
}