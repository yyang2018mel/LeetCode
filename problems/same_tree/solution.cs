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
    
    private bool IsIdentical(TreeNode lhs, TreeNode rhs)
    {
        if (lhs is null && rhs is null) return true;
        
        if (lhs is null || rhs is null) return false;
        
        // othwise, neither of them is null
        
        return
            lhs.val.Equals(rhs.val) &&
            IsIdentical(lhs.left, rhs.left) &&
            IsIdentical(lhs.right, rhs.right);
    }
    
    public bool IsSameTree(TreeNode p, TreeNode q) 
    {
        return IsIdentical(p, q);
    }
}