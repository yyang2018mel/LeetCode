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
    private IList<IList<int>> LevelOrderWithZigZag(TreeNode root)
    {
        var queue = new Queue<(TreeNode, int)>(); // (node , depth)
        queue.Enqueue((root,0));
        
        var levels = new Dictionary<int, List<int>>();
        
        while(queue.Count > 0)
        {
            var (head, depth) = queue.Dequeue();
            
            if (levels.TryGetValue(depth, out var list))
            {
                list.Add(head.val);
            }
            else
            {
                levels[depth] = new List<int>{head.val};
            }
            
            if (head.left != null)
                queue.Enqueue((head.left, depth+1));
            
            if (head.right != null)
                queue.Enqueue((head.right, depth+1));
        }
        
        var result = 
            levels
            .Select(kv => 
            {
                var depth = kv.Key;
                
                if (depth % 2 == 0)
                {
                    return kv.Value as IList<int>;
                }
                else
                {
                    var list = kv.Value;
                    list.Reverse();
                    return list as IList<int>;
                }
            })
            .ToList();
        
        return result as IList<IList<int>>;
    }
    
    
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) 
    {
        if (root is null)
            return new List<IList<int>>() as IList<IList<int>>;
        
        return LevelOrderWithZigZag(root);
    }
}