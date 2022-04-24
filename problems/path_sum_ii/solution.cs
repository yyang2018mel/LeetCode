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
    
    private List<List<int>> PathSum(TreeNode node, List<int> accumulative)
    {
        var result = new List<List<int>>();
        
        if (node is null) return result;
        
        var path = new List<int>(accumulative);
        path.Add(node.val);
        
        if (node.IsLeaf())
        {
            result.Add(path);
            return result;
        }
        
        result.AddRange(PathSum(node.left, path));
        
        result.AddRange(PathSum(node.right, path));
        
        return result;
    }
    
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) 
    {
        var allPaths = PathSum(root, new List<int>());
        var validPaths = 
            allPaths
            .Where(path => path.Sum() == targetSum)
            .Select(path => path as IList<int>)
            .ToList();
        
        return validPaths as IList<IList<int>>;
    }
}