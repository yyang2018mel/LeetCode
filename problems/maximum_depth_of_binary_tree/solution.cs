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
public class Solution {
    
    private int maxDepth(TreeNode root) {
        
        if (root == null) return 0;
        
        if (root.left == null && root.right == null) return 1;
        
        return 1 + Math.Max( maxDepth(root.left), maxDepth(root.right) );
        
    }
    
    public int MaxDepth(TreeNode root) {
        return maxDepth(root);
    }
}