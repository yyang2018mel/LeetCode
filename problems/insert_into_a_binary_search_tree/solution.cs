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
    public TreeNode InsertIntoBST(TreeNode root, int val) 
    {
        if (root is null)
            return new TreeNode(val);
        
        TreeNode p = null;
        TreeNode x = root;
        
        while(x != null)
        {
            p = x;
            if (val < x.val)
                x = x.left;
            else
                x = x.right;
        }
        
        if (val < p.val)
            p.left = new TreeNode(val);
        else
            p.right = new TreeNode(val);
        
        return root;
    }
}