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
    private List<List<int>> BreadthFirstTraverse(TreeNode root)
    {
        var result = new List<List<int>>();
        var queue = new Queue<(TreeNode, int)>();
        
        if (root is not null)
            queue.Enqueue((root,0));
        
        while(queue.Count > 0)
        {
            var (node, depth) = queue.Dequeue();
            
            if(result.Count - 1 < depth)
            {
                var list = new List<int> { node.val };
                result.Add(list);
            }
            else
            {
                result[depth].Add(node.val);
            }
            
            if (node.left is not null)
                queue.Enqueue((node.left, depth+1));
            
            if (node.right is not null)
                queue.Enqueue((node.right, depth+1));
        }
        
        return result;
        
    }
    
    
    public IList<IList<int>> LevelOrder(TreeNode root) 
    {
        var result = 
            BreadthFirstTraverse(root)
            .Select(l => l as IList<int>)
            .ToList();
        
        return result as IList<IList<int>>;
        
    }
}