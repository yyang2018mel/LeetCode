public class Solution 
{
    private bool BFSFindPath(
        List<int>[] adjacencyList, 
        int source, 
        int destination)
    {
        var queue = new Queue<int>();
        var visited = new HashSet<int>();
        queue.Enqueue(source);
        visited.Add(source);
        
        while(queue.Count > 0)
        {
            var node = queue.Dequeue();
            
            if (node == destination) 
                return true;
            
            var neighbors = adjacencyList[node];
            foreach(var neighbor in neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);    
                    visited.Add(neighbor);
                }
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
        
        var found = BFSFindPath(adjacencyList, source, destination);
        
        return found;
    }
}