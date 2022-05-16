/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution 
{
    private IList<IList<int>> BFS(Node root)
    {        
        var result = new List<IList<int>>();
        
        var visited = new HashSet<Node>();
        var queue = new Queue<(Node,int)>();
        queue.Enqueue((root,1));
        visited.Add(root);
        
        var levelState = 1;
        var tempList = new List<int>(); 
        while(queue.Count > 0)
        {
            var (head, level) = queue.Dequeue();
            
            if (levelState == level)
            {
                tempList.Add(head.val);
            }
            else
            {
                result.Add(tempList as IList<int>);
                tempList = new List<int> { head.val };
                levelState = level;
            }
            
            foreach(var child in head.children)
            {
                if (!visited.Contains(child))
                {
                    visited.Add(child);
                    queue.Enqueue((child, levelState+1));    
                }
            }
        }
        
        result.Add(tempList as IList<int>);
        
        return result as IList<IList<int>>;
    }
    
    public IList<IList<int>> LevelOrder(Node root) 
    {
        if (root is null) return new List<IList<int>>() as IList<IList<int>>;
        
        return BFS(root);
    }
}