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

public class Solution 
{
    private bool IsLeafOrNull(TreeNode node)
    {
        return (node is null) || (node.left is null && node.right is null);
    }
    
    public TreeNode InvertTree(TreeNode root) 
    {
        if(IsLeafOrNull(root)) return root;
        
        var left = root.left;
        var right = root.right;
        
        var newRight = InvertTree(left);
        var newLeft = InvertTree(right);
        
        root.right = newRight;
        root.left = newLeft;
        
        return root;
    }
}