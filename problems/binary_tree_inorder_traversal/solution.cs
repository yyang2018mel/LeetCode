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
    private void Inorder(TreeNode root, List<int> trace)
    {
        if(root is null) return;
        
        Inorder(root.left, trace);
        trace.Add(root.val);
        Inorder(root.right, trace);
    }
    
    public IList<int> InorderTraversal(TreeNode root) 
    {
        var trace = new List<int>();
        Inorder(root, trace);
        return trace as IList<int>;
    }
}