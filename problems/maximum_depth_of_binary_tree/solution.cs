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
internal static class TreeNodeEx
{
    internal static bool IsLeaf(this TreeNode node) => 
        node is not null && node.left is null && node.right is null;
}


public class Solution 
{
    private int Probe(TreeNode node, int depth=1)
    {
        if (node is null) return depth-1;
        
        if (node.IsLeaf()) return depth;
        
        var maxDepthLeft  = Probe(node.left, depth+1);
        
        var maxDepthRight = Probe(node.right, depth+1);
        
        return Math.Max(maxDepthLeft, maxDepthRight);
        
    }
    
    public int MaxDepth(TreeNode root) 
    {
        return Probe(root);
    }
}