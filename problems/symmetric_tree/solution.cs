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
    private bool IsMirroring(TreeNode lhs, TreeNode rhs)
    {
        if(lhs is null && rhs is null) return true;
        if(lhs is null || rhs is null) return false;
        
        var sameRoot = lhs.val == rhs.val;
        return sameRoot
               && IsMirroring(lhs.left, rhs.right)
               && IsMirroring(lhs.right, rhs.left);
    }
    
    public bool IsSymmetric(TreeNode root) 
    {
        return IsMirroring(root.left, root.right);
    }
}