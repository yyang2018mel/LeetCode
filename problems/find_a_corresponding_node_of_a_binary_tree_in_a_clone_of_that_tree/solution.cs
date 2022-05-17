/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution 
{
    
    private TreeNode Preorder(TreeNode node, int target)
    {
        if (node is null)
            return null;
        
        if (node.val == target)
            return node;
        
        if (node.left is null && node.right is null)
            return null;
        
        var left = Preorder(node.left, target);
        return left ?? Preorder(node.right, target);
        
    }
    
    
    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target) 
    {
        var result = Preorder(cloned, target.val);
        
        return result;
    }
}