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
internal static class TreeExtenstions
{
    internal static bool IsLeaf(this TreeNode node)
    {
        return node != null && node.left is null && node.right is null;
    }
}

public class Solution 
{
    private int ReachLeaf(TreeNode node, int nodeCount=1)
    {
        if (node.IsLeaf()) return nodeCount;
        
        int totalCount = Int32.MaxValue;
        
        if (node.left is not null)
        {
            totalCount = Math.Min(totalCount, ReachLeaf(node.left, nodeCount+1));
        }

        if (node.right is not null)
        {
            totalCount = Math.Min(totalCount, ReachLeaf(node.right, nodeCount+1));
        }
     
        return totalCount;
    }
    
    public int MinDepth(TreeNode root) 
    {
        if (root is null) return 0;
        
        return ReachLeaf(root);
    }
}