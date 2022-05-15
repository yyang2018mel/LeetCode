public class Solution 
{
    private bool DFS(Dictionary<int, List<int>> adjacencyList, int nodeIdx, int predecessor, HashSet<int> visited)
    {
        visited.Add(nodeIdx);
        if (adjacencyList.TryGetValue(nodeIdx, out var neighbors))
        {
            var neighbors_ = neighbors.Where(n => n != predecessor).ToList();
                
            if (neighbors_.Count == 0) 
                return true;
            
            if (neighbors_.Any(n => visited.Contains(n)))
                return false;
            
            var result = 
                neighbors_
                .Select(n => DFS(adjacencyList, n, nodeIdx, visited))
                .ToList();
            
            return result.All(r => r);
        }
        
        return true;
    }
    
    public bool ValidTree(int n, int[][] edges) 
    {
        var adjacencyList = new Dictionary<int, List<int>>();
        foreach(var edge in edges)
        {
            //bi-directional
            if (adjacencyList.TryGetValue(edge[0], out var n0))
                n0.Add(edge[1]);
            else
                adjacencyList[edge[0]] = new List<int> { edge[1] };
            
            if (adjacencyList.TryGetValue(edge[1], out var n1))
                n1.Add(edge[0]);
            else
                adjacencyList[edge[1]] = new List<int> { edge[0] };
        }
            
        var visited = new HashSet<int>();
        
        if (!DFS(adjacencyList, 0, -1, visited)) return false;  // has cycle
        
        if (visited.Count < n) return false; // has more than 1 connected component
        
        return true;
    }
}