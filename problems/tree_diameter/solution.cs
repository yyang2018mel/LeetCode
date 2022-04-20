public class Solution 
{
    private int _diameter;
    private int _root;
    private Dictionary<int, List<int>> _adjacencyList;
    
    void InitializeTree(int[][] edges)
    {
        var rootCandidates = new HashSet<int>(Enumerable.Range(0, edges.Length));
        _adjacencyList = new Dictionary<int, List<int>>();
        foreach(var edge in edges)
        {
            var start = edge[0];
            var end = edge[1];

            // if a node has ever been pointed to, it must not be the root of the tree!
            rootCandidates.Remove(end);
            
            if(_adjacencyList.TryGetValue(start, out var neighbours))
            {
                neighbours.Add(end);
            }
            else
            {
                _adjacencyList[start] = new List<int> { end };
            }
        }
        
        _root = rootCandidates.Single();
    }
    
    public int DepthFirstTraversal(int node)
    {
        if(_adjacencyList.TryGetValue(node, out var neighbours))
        {
            var maxLocalPathLen = 0;
            var secondMaxLocalPathLen = 0;
            
            foreach(var neighbour in neighbours)
            {
                var localPathLen = DepthFirstTraversal(neighbour)+1;
                
                if (localPathLen > maxLocalPathLen)
                {
                    secondMaxLocalPathLen = maxLocalPathLen;
                    maxLocalPathLen = localPathLen;
                }
                else if (localPathLen > secondMaxLocalPathLen)
                {
                    secondMaxLocalPathLen = localPathLen;
                }
            }
            
            _diameter = Math.Max(_diameter, maxLocalPathLen + secondMaxLocalPathLen);
            
            return maxLocalPathLen;
        }
        
        return 0;
    }
    
    
    public int TreeDiameter(int[][] edges) 
    {
        if (edges.Length == 0) 
            return 0;
        
        InitializeTree(edges);
        _ = DepthFirstTraversal(_root);
        
        return _diameter;
    }
}