public class Solution 
{
    // [[2,1,1],[1,1,0],[0,1,1]]
    // [[2,1,1],[0,1,1],[1,0,1]]
    // [[0,2]]
    // [[0,1,0],[0,2,2],[0,1,1]]
    // [[1]]
    // [[0]]
    // [[2,1,1,0],[0,1,1,1],[2,1,0,1]]
    // [[2,1,1,0],[0,1,1,1],[2,1,0,1],[0,0,1,0],[0,1,1,1],[1,1,2,1]]
    // [[2,1,1,1],[0,0,0,1],[2,1,0,1],[0,0,1,0],[0,1,1,1],[1,1,2,1]]
    // [[2,1,1],[1,1,1],[0,1,2]]
    // [[2,0,2],[1,1,1],[1,1,2]]
    // [[2,0,2],[0,0,0],[1,0,2]]
    private int BFS(int[][] grid, HashSet<(int,int)> visited)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        
        var queue = new Queue<((int,int), int)>();
        foreach(var start in visited)
            queue.Enqueue((start,0));
        
        bool IsValidCoord((int,int) coord)
        {
            var (x,y) = coord;
            return 
                x >= 0 && y >= 0 &&
                x < m  && y < n &&
                grid[x][y] != 0 &&
                !visited.Contains((x,y));
        }
        
        int GetValueAtCoord((int,int) coord)
        {
            var (x,y) = coord;
            return grid[x][y];
        }
        
        var time = 0;
        while(queue.Count > 0)
        {
            var ((headx, heady), t) = queue.Dequeue();
            time = t;
            
            var left = (headx-1, heady);
            var up = (headx, heady-1);
            var right = (headx+1, heady);
            var down = (headx, heady+1);
            
            var neighbors = 
                new List<(int,int)> { left, up, right, down }
                .Where(c => IsValidCoord(c))
                .OrderByDescending(c => GetValueAtCoord(c));
            
            foreach(var nb in neighbors)
            {
                var (x,y) = nb;
                visited.Add(nb);
                queue.Enqueue((nb, GetValueAtCoord(nb) != 2 ? time+1 : time));
                grid[x][y] = 2;
            }
        }
               
        return time;
    }
    
    public int OrangesRotting(int[][] grid) 
    {
        var m = grid.Length;
        var n = grid[0].Length;
        
        var orangeCount = 0;
        var initialRottens = new List<(int,int)> ();
        
        for(var i = 0; i < m; i++)
            for(var j = 0; j < n; j++)
            {
                if (grid[i][j] != 0)
                    orangeCount += 1;
                
                if (grid[i][j] == 2)
                    initialRottens.Add((i,j));
            }
        
        if (orangeCount == 0) return 0;
        
        if (initialRottens.Count == 0) return -1;
        
        var visited = new HashSet<(int,int)>(initialRottens);
        var timeCost = BFS(grid, visited);
        
        return
            visited.Count == orangeCount
            ? timeCost
            : -1;
    }
}