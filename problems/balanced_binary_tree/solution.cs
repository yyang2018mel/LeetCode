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
    private int GetHeight(TreeNode root)
    {
        if (root is null) return 0;
        
        if (root.left is null && root.right is null) return 1;
        
        var leftHeight = root.left is null ? 0 : GetHeight(root.left);
        var rightHeight = root.right is null ? 0 : GetHeight(root.right);
        return 1 + Math.Max(leftHeight, rightHeight);
    }
    
    public bool IsBalanced(TreeNode root) 
    {
        if (root is null) return true;
        
        var leftHeight = GetHeight(root.left);
        var rightHeight = GetHeight(root.right);
        var absDiff = Math.Abs(leftHeight - rightHeight);
        
        return absDiff <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
    }
}