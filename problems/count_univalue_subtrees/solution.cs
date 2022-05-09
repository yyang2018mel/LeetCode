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
    private static readonly int NULL = -1001;
    
    private (int, int) Calculate(TreeNode node)
    {
        if (node is null) return (NULL, 0);
        
        var (uniLeft, uniLeftCount) = Calculate(node.left);
        
        var (uniRight, uniRightCount) = Calculate(node.right);
        
        if (node.IsLeaf())
        {
            return (node.val, 1);
        }
        else if (node.left is not null && node.right is not null)
        {
            return 
                uniLeft == node.val && uniRight == node.val 
                ? (node.val, uniLeftCount+uniRightCount+1)
                : (NULL, uniLeftCount+uniRightCount);
        }
        else if (node.left is null && node.right is not null)
        {
            return 
                uniRight == node.val 
                ? (node.val, uniLeftCount+uniRightCount+1)
                : (NULL, uniLeftCount+uniRightCount);
        }
        else
        {
            return 
                uniLeft == node.val 
                ? (node.val, uniLeftCount+uniRightCount+1)
                : (NULL, uniLeftCount+uniRightCount);
        }   
    }
    
    
    public int CountUnivalSubtrees(TreeNode root) 
    {
        var result = Calculate(root);
        return result.Item2;
    }
}