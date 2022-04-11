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
    
    private void Postorder(TreeNode root, List<int> trace)
    {
        if (root is null)
            return;
        
        Postorder(root.left, trace);
        Postorder(root.right, trace);
        trace.Add(root.val);
    }
    
    public IList<int> PostorderTraversal(TreeNode root) 
    {
        var trace = new List<int>();
        Postorder(root, trace);
        
        return trace as IList<int>;
    }
}