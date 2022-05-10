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
    private int[] _preorder;
    
    private int[] _inorder;
    
    private TreeNode BuildTree(int preorderStart, int preorderEnd, int inorderStart, int inorderEnd)
    {
        if (preorderStart > preorderEnd || inorderStart > inorderEnd)
            return null;
        
        var rootIdxInPreOrder = preorderStart;
        var rootVal = _preorder[rootIdxInPreOrder];
        var rootIdxInInOrder = Array.FindIndex(_inorder, e => e == rootVal);

        var leftCount = rootIdxInInOrder - inorderStart;
        var rightCount = inorderEnd - rootIdxInInOrder;

        var leftTree  = 
                leftCount <= 0
                ? null
                : BuildTree(preorderStart+1, 
                            preorderStart+leftCount, 
                            inorderStart, 
                            rootIdxInInOrder-1);
        var rightTree = 
                rightCount <= 0
                ? null
                : BuildTree(preorderStart+leftCount+1, 
                            preorderStart+leftCount+rightCount, 
                            rootIdxInInOrder+1, 
                            inorderEnd); 

        var tree = new TreeNode(rootVal, leftTree, rightTree);
        return tree; 
        
    }
    
    
    public TreeNode BuildTree(int[] preorder, int[] inorder) 
    {
        _preorder = preorder;
        _inorder = inorder;
        var tree = BuildTree(0, preorder.Length-1, 0, inorder.Length-1);
        
        return tree;
    }
}