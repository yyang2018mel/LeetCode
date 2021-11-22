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

public class MinMax {
    
    public MinMax(int min, int max) {
        Min = min;
        Max = max;
    }
    
    public int Min { get; }
    public int Max { get; }
    
}


public class Solution {
    
    private bool validate(TreeNode tree, out MinMax minmax) {
        
        minmax = null;
        
        if (tree == null) {    
            return true;
        }
        
        if (tree.left == null && tree.right == null) {
            minmax = new MinMax(tree.val, tree.val);
            return true;
        }
        
        var isLeftValid = validate(tree.left, out var leftMinMax);
        var isRightValid = validate(tree.right, out var rightMinMax);
        
        if (!isLeftValid || !isRightValid) {
            return false;
        }
        
        if (leftMinMax == null && rightMinMax == null) {
            throw new Exception("xxx");
        }
        
        else if(leftMinMax == null && rightMinMax != null) {
            if (tree.val < rightMinMax.Min) {
                minmax = new MinMax(tree.val, rightMinMax.Max);
                return true;
            }
        }
        
        else if (leftMinMax != null && rightMinMax == null) {
            if (tree.val > leftMinMax.Max) {
                minmax = new MinMax(leftMinMax.Min, tree.val);
                return true;
            }
        }
        
        else {
            if (tree.val > leftMinMax.Max && tree.val < rightMinMax.Min) {
                minmax = new MinMax(leftMinMax.Min, rightMinMax.Max);
                return true;
            }
        }
        
        return false;
            
    }
    
    public bool IsValidBST(TreeNode root) {
        var isValid = validate(root, out var _);
        return isValid;
    }
}