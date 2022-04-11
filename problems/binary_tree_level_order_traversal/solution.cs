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
    public IList<IList<int>> LevelOrder(TreeNode root) 
    {
        if (root is null) 
            return (new List<IList<int>>()) as IList<IList<int>>;
        
        var queue = new Queue<(TreeNode,int)>(); // (node, depth)
        queue.Enqueue((root,0));
        
        var cache = new Dictionary<int, List<int>>();
        
        while(queue.Count > 0)
        {
            var (head, depth) = queue.Dequeue();
            
            if(cache.TryGetValue(depth, out var list))
            {
                list.Add(head.val);
            }
            else
            {
                cache[depth] = new List<int> { head.val };
            }
            
            if (head.left is not null)
                queue.Enqueue((head.left, depth+1));
            
            if (head.right is not null)
                queue.Enqueue((head.right, depth+1));
        }
        
        return (
            cache.Values
            .Select(l => l as IList<int>)
            .ToList()) as IList<IList<int>>;
    }
}