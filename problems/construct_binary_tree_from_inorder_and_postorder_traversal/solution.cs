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
    public TreeNode BuildTree(List<int> inorder, List<int> postorder) 
    {
        if (inorder.Count == 0 && postorder.Count == 0)
            return null;
        
        var rootVal = postorder[postorder.Count-1];
        var rootIdx = inorder.FindIndex(e => e == rootVal);
        var leftNodesInOrder = new List<int>();
        var rightNodesInOrder = new List<int>();
        for(var i = 0; i < inorder.Count; i++)
        {
            if (i < rootIdx)
                leftNodesInOrder.Add(inorder[i]);
            else if (i > rootIdx)
                rightNodesInOrder.Add(inorder[i]);
        }
        
        var leftNodesPostOrder = new List<int>();
        var rightNodesPostOrder = new List<int>();
        for(var i = 0; i < postorder.Count-1; i++)
        {
            if (leftNodesPostOrder.Count < leftNodesInOrder.Count)
                leftNodesPostOrder.Add(postorder[i]);
            else
                rightNodesPostOrder.Add(postorder[i]);
        }
        
        return new TreeNode(rootVal,
                            BuildTree(leftNodesInOrder, leftNodesPostOrder),
                            BuildTree(rightNodesInOrder, rightNodesPostOrder));
    }
    
    public TreeNode BuildTree(int[] inorder, int[] postorder) 
    {
        var tree = BuildTree(inorder.ToList(), postorder.ToList());
        return tree;
    }
}