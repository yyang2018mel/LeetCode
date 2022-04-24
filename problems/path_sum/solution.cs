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

internal static class TreeExtensions
{
    internal static bool IsLeaf(this TreeNode node)
    {
        return node is not null && node.left is null && node.right is null;
    }
}

public class Solution 
{
    private List<int> PathSum(TreeNode node, int currentSum)
    {
        var result = new List<int> ();
     
        if (node is null) return result;
        
        if (node.IsLeaf()) return new List<int> { currentSum + node.val };
        
        result.AddRange(PathSum(node.left, currentSum + node.val));
        
        result.AddRange(PathSum(node.right, currentSum + node.val));
        
        return result;
    }
    
    
    public bool HasPathSum(TreeNode root, int targetSum) 
    {
        var list = PathSum(root, 0);
        
        return list.Exists(s => s == targetSum);
    }
}