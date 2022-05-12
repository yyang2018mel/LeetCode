public class Solution
{
    
    private bool DFS(List<int>[] adjacencyList, int source, int destination, HashSet<int> visited)
    {
        if(source == destination)
        {
            visited.Remove(destination);
            return adjacencyList[destination] is null;
        }
        
        var allTries = new List<bool>();
        for(var i = 0; i < adjacencyList[source]?.Count; i++)
        {
            var neighbor = adjacencyList[source][i];
            
            // detecy cycle
            var neighborSqr = adjacencyList[neighbor];
            if (neighborSqr is not null)
            {
                if (neighborSqr.Contains(source) || neighborSqr.Contains(neighbor))
                    return false;
            }
            
            visited.Add(neighbor);
            var tryPath = DFS(adjacencyList, neighbor, destination, visited);
            if (!tryPath)
                return false;
            allTries.Add(tryPath);            
        }
        
        return allTries.Count > 0;
    }
    
    
    public bool LeadsToDestination(int n, int[][] edges, int source, int destination) 
    {
        var adjacencyList = new List<int>[n];
        foreach(var edge in edges)
        {
            var start = edge[0];
            var end = edge[1];

            if (adjacencyList[start] is null)
            {
                adjacencyList[start] = new List<int> { end };
            }
            else
            {
                adjacencyList[start].Add(end);
            }
        }
        
        var result = DFS(adjacencyList, source, destination, new HashSet<int>{ source });
        
        return result;
    }
}