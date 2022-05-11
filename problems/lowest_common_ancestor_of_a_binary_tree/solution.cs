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
    private TreeNode _p;
    private TreeNode _q;
    
    private TreeNode DepthFirstSearch(TreeNode node, TreeNode parent, TreeNode target)
    {
        if (node is null)
            return null;
        
        if (node.val == target.val)
            return parent;
        
        var findingLeft = DepthFirstSearch(node.left, node, target);
        
        if (findingLeft is not null) 
        {
            return findingLeft;
        }
        else
        {
            return DepthFirstSearch(node.right, node, target);
        }
    }
    
    
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) 
    {
        if (DepthFirstSearch(p, p, q) is not null)
        {
            return p;
        }
        
        var pParent = DepthFirstSearch(root, root, p);
        if (DepthFirstSearch(pParent, pParent, q) is not null)
        {
            return pParent;
        }
        else
        {
            return LowestCommonAncestor(root, pParent, q);
        }
    }
}







