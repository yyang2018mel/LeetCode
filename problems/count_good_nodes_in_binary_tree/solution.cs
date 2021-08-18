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
    private int goodNodes;

    private void PreOrderTraverse(TreeNode node, int currentMax)
    {
        if (node == null) return;

        int nodeVal = node.val;

        if (currentMax <= nodeVal)
        {
            goodNodes++;
            currentMax = nodeVal;
        }

        PreOrderTraverse(node.left, currentMax);
        PreOrderTraverse(node.right, currentMax);
    }

    public int GoodNodes(TreeNode root)
    {
        PreOrderTraverse(root, root.val);
        return goodNodes;
    }
}