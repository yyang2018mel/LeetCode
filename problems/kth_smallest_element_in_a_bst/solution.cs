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
    
    private int K;
    
    private void InorderWithShortCircuit(TreeNode root, List<int> trace)
    {
        if (root is null) return;
        
        if (trace.Count == this.K) return;
        
        InorderWithShortCircuit(root.left, trace);
        trace.Add(root.val);
        InorderWithShortCircuit(root.right, trace);
    }
    
    
    public int KthSmallest(TreeNode root, int k) 
    {
        this.K = k;
        var trace = new List<int>();
        InorderWithShortCircuit(root, trace);
        
        return trace[this.K-1];
    }
}