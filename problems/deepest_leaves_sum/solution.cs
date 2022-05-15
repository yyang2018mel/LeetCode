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
    private List<(int val, int depth)> DFSFindLeaves(TreeNode node, int depth)
    {
        if (node is null)
            return new List<(int, int)>();
        
        if (node.IsLeaf())
            return new List<(int, int)> { (node.val, depth) };
        
        var leavesOnLeftBranch = DFSFindLeaves(node.left, depth+1);
        var leavesOnRightBranch = DFSFindLeaves(node.right, depth+1);
        
        leavesOnLeftBranch.AddRange(leavesOnRightBranch);
        return leavesOnLeftBranch;
    }
    
    public int DeepestLeavesSum(TreeNode root) 
    {
        var allLeaves = 
            DFSFindLeaves(root, 0)
            .OrderByDescending(ld => ld.depth)
            .ToArray();
        
        var sum = allLeaves[0].val;
        for(var i = 1; i < allLeaves.Length; i++)
        {
            if (allLeaves[i].depth != allLeaves[i-1].depth)
                break;
            sum += allLeaves[i].val;
        }
        return sum;
    }
}