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
    public int RangeSumBST(TreeNode root, int low, int high) 
    {
        if (root.val >= low && root.val <= high)
        {
            var result = 
                root.val +
                (root.left is null  ? 0 : RangeSumBST(root.left, low, high)) +
                (root.right is null ? 0 : RangeSumBST(root.right, low, high));
            
            return result;
        }
        else if (root.val < low)
        {
            return root.right is null ? 0 : RangeSumBST(root.right, low, high);
        }
        else if (root.val > high)
        {
            return root.left is null  ? 0 :RangeSumBST(root.left, low, high);
        }
        
        throw new Exception("Impposible code path hit");
    }
}