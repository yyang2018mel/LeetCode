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

internal record UniValPath(int val, int len)
{
    internal UniValPath() : this(Int32.MinValue,0) { }
    
    internal UniValPath(int val) : this(val, 0) { }
    
    internal static UniValPath Longest(UniValPath lhs, UniValPath rhs)
    {
        if (lhs.len >= rhs.len) return lhs;
        
        return rhs;
    }
    
    internal static UniValPath Longest(UniValPath p1, UniValPath p2, UniValPath p3)
    {
        var p1vsp2 = Longest(p1, p2);
        return Longest(p1vsp2, p3);
    }
}

public class Solution 
{
    
    private UniValPath _longestUniValPath = new UniValPath();
    
    private UniValPath DepthFirstTraversal(TreeNode node) 
    // return longest single branch path length from the node
    {
        if (node is null) 
        {
            var nullPath = new UniValPath();
            _longestUniValPath = UniValPath.Longest(_longestUniValPath, nullPath);
            return nullPath;
        }
        
        if (node.IsLeaf()) 
        {
            var nullPath = new UniValPath(node.val);
            _longestUniValPath = UniValPath.Longest(_longestUniValPath, nullPath);
            return nullPath;
        }
            
        var yieldedFromDownLeft = DepthFirstTraversal(node.left);
        var yieldedFromDownRight = DepthFirstTraversal(node.right);
        
        UniValPath localMaxPath;
        UniValPath toYieldUp;
        
        if (yieldedFromDownLeft.val == node.val && yieldedFromDownRight.val == node.val)
        {
            localMaxPath = new UniValPath(node.val, 2 + yieldedFromDownLeft.len + yieldedFromDownRight.len);
            toYieldUp = new UniValPath(node.val, 1 + Math.Max(yieldedFromDownLeft.len, yieldedFromDownRight.len));
        }
        else if (yieldedFromDownLeft.val == node.val && yieldedFromDownRight.val != node.val)
        {
            toYieldUp = new UniValPath(node.val, 1 + yieldedFromDownLeft.len);
            localMaxPath = UniValPath.Longest(toYieldUp, yieldedFromDownRight);
        }
        else if (yieldedFromDownLeft.val != node.val && yieldedFromDownRight.val == node.val)
        {
            toYieldUp = new UniValPath(node.val, 1 + yieldedFromDownRight.len);
            localMaxPath = UniValPath.Longest(toYieldUp, yieldedFromDownLeft);
        }
        else
        {
            toYieldUp = new UniValPath(node.val, 0);
            localMaxPath = UniValPath.Longest(toYieldUp, yieldedFromDownLeft, yieldedFromDownRight);
        }
        
        _longestUniValPath = UniValPath.Longest(_longestUniValPath, localMaxPath);
        
        return toYieldUp;
        
    }
    
    public int LongestUnivaluePath(TreeNode root) 
    {
        DepthFirstTraversal(root);
        return _longestUniValPath.len;
    }
}