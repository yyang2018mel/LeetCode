public class Solution 
{
    private List<(int,int)> GetValidDirections(int[][] grid, (int,int) coordinate, HashSet<(int,int)> visited)
    {
        var n = grid.Length;
        var (i,j) = coordinate;
        var result = new List<(int,int)>();
        
        bool IsValidMove((int,int) proposal)
        {
            var (pi,pj) = proposal;
            return 
                pi >= 0 &&
                pj >= 0 &&
                pi < n  &&
                pj < n  &&
                !visited.Contains(proposal) &&
                grid[pi][pj] == 0;
        };
        
        // 1. up
        if (IsValidMove((i-1,j)))
            result.Add((i-1,j));
        // 2. up-right
        if (IsValidMove((i-1,j+1)))
            result.Add((i-1,j+1));
        // 3. right
        if (IsValidMove((i,j+1)))
            result.Add((i,j+1));
        // 4. down-right
        if (IsValidMove((i+1,j+1)))
            result.Add((i+1,j+1));
        // 5. down
        if (IsValidMove((i+1,j)))
            result.Add((i+1,j));
        // 6. down-left
        if (IsValidMove((i+1,j-1)))
            result.Add((i+1,j-1));
        // 7. left
        if (IsValidMove((i,j-1)))
            result.Add((i,j-1));
        // 8.up-left
        if (IsValidMove((i-1,j-1)))
            result.Add((i-1,j-1));
        
        return result;
    }
    
    private int BFSGetLength(int[][] grid, (int,int) source, (int,int) target)
    {
        if (grid[source.Item1][source.Item2] != 0)
            return -1;
        
        var pathLenState = 1;
        var queue = new Queue<((int,int), int)>();
        var visited = new HashSet<(int,int)> { source };
        queue.Enqueue((source, pathLenState));
        
        while(queue.Count > 0)
        {
            var (head, pathLenSoFar) = queue.Dequeue();
            
            pathLenState = pathLenSoFar;
            
            if (head == target)
                return pathLenState;
            
            var potentialNexts = GetValidDirections(grid, head, visited);
            foreach(var next in potentialNexts)
            {
                queue.Enqueue((next, pathLenState+1));
                visited.Add(next);
            }
        }
        
        return -1;
    }
    
    public int ShortestPathBinaryMatrix(int[][] grid) 
    {
        var n = grid.Length;
        var visited = new HashSet<(int,int)>();
        var cleanPathLen = BFSGetLength(grid, (0,0), (n-1,n-1));
        
        return cleanPathLen;
    }
}