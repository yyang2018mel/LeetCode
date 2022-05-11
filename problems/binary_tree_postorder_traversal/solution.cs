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
    private List<int> Postorder(TreeNode node)
    {
        if (node is null) return new List<int>();
        
        var left = Postorder(node.left);
        var right = Postorder(node.right);
        var result = left;
        result.AddRange(right);
        result.Add(node.val);
        return result;
    }
    
    
    public IList<int> PostorderTraversal(TreeNode root) 
    {
        var result = Postorder(root);
        return result as IList<int>;
    }
}