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
    private List<int> DoInorderTraversal(TreeNode node) 
    {
        var result = new List<int>();
        if (node is null)  return result;
        
        result.AddRange(DoInorderTraversal(node.left));
        result.Add(node.val);
        result.AddRange(DoInorderTraversal(node.right));
        return result;
        
    }
    
    public IList<int> InorderTraversal(TreeNode root) 
    {
        var result = DoInorderTraversal(root);
        return result as IList<int>;
    }
}