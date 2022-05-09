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
    private List<int> DoPreorderTraversal(TreeNode root) 
    {
        var result = new List<int>();
        
        if (root is null) return result;
        
        result.Add(root.val);
        result.AddRange(DoPreorderTraversal(root.left));
        result.AddRange(DoPreorderTraversal(root.right));
        
        return result;
        
    }
    
    public IList<int> PreorderTraversal(TreeNode root) 
    {
        var result = DoPreorderTraversal(root);
        return result as IList<int>;
    }
}