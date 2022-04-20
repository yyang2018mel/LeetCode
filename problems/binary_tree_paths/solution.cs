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
    
    private List<List<TreeNode>> DepthFirstTraversal(TreeNode node)
    {
        if (node is null)
            return new List<List<TreeNode>> ();
        
        if (node.IsLeaf())
        {
            var singleton = new List<TreeNode> { node };
            return new List<List<TreeNode>> { singleton };
        }
        
        var leftPaths = DepthFirstTraversal(node.left);
        var rightPaths = DepthFirstTraversal(node.right);
        
        var localPaths =
            leftPaths.Concat(rightPaths);
        
        foreach(var path in localPaths)
            path.Insert(0, node);
        
        
        return localPaths.ToList();
    }
    
    public IList<string> BinaryTreePaths(TreeNode root) 
    {
        var allPaths = DepthFirstTraversal(root);
        var result = new List<string> ();
        
        foreach(var path in allPaths)
            result.Add(String.Join("->", path.Select(n => n.val)));
        
        
        return result as IList<string>;
    }
}