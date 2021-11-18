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
public class Solution {
    
    
    
    public IList<TreeNode> generateTrees(int n, int valIncrement = 0) {
        
        var trees = new List<TreeNode>();
        
        if (n == 0) {
            trees.Add(null);
            return trees;
        }
        
        if (n == 1) {
            trees.Add(new TreeNode(1 + valIncrement, null, null));
            return trees;
        }
    
        for(var root = 1; root <= n; root++) {
            
            var lefts = generateTrees(root-1, valIncrement);
            var rights = generateTrees(n-root, root+valIncrement);
            
            foreach (var left in lefts) {
                foreach (var right in rights) {
                    var tree = new TreeNode(root + valIncrement, left, right);
                    trees.Add(tree);
                }
            }
        }
        
        return trees;
    }
    
    
    public IList<TreeNode> GenerateTrees(int n) {
        
        var trees = generateTrees(n);
        return trees;
    }
}