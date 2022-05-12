public class Solution 
{
    private bool DFSFindPath(
        List<int>[] adjacencyList, 
        int source, 
        int destination, 
        HashSet<int> visited)
    {
        if (source == destination) return true;
        
        for(var i = 0; i < adjacencyList[source]?.Count; i++)
        {
            var neighbori= adjacencyList[source][i];
            
            if (visited.Contains(neighbori)) 
                continue;
            else
            {
                visited.Add(neighbori);
                if(DFSFindPath(adjacencyList, neighbori, destination, visited))
                    return true;
            }
        }

        return false;
    }
    
    public bool ValidPath(int n, int[][] edges, int source, int destination) 
    {
        var adjacencyList = new List<int>[n];
        
        void UpdateAdjacencyList(int start, int end)
        {
            if(adjacencyList[start] is null)
                adjacencyList[start] = new List<int> { end };
            else
                adjacencyList[start].Add(end);
        }
        
        foreach(var edge in edges)
        {
            // edges are bi-directional
            UpdateAdjacencyList(edge[0], edge[1]);
            UpdateAdjacencyList(edge[1], edge[0]);
        }
        
        var visited = new HashSet<int> { source };
        
        var found = DFSFindPath(adjacencyList, source, destination, visited);
        
        return found;
    }
}