public class DisjointSet
{
    private (int,int)[,] root;
    private int[,] rank;
    
    
    private void DFS(char[][] grid, int m, int n, (int,int) coordinate, HashSet<(int,int)> visited)
    {
        var (i,j) = coordinate;
        if (grid[i][j] == '1' && !visited.Contains(coordinate))
        {
            visited.Add(coordinate);
            if (i-1 >= 0 && grid[i-1][j] == '1') // check up
            {
                Union(coordinate, (i-1,j));
                DFS(grid, m, n, (i-1,j), visited);
            }
            if (j-1 >= 0 && grid[i][j-1] == '1') // check left
            {
                Union(coordinate, (i,j-1));
                DFS(grid, m, n, (i,j-1), visited);
            }
            if (i+1 < m && grid[i+1][j] == '1') // check down
            {
                Union(coordinate, (i+1,j));
                DFS(grid, m, n, (i+1,j), visited);
            }
            if (j+1 < n && grid[i][j+1] == '1') // check right
            {
                Union(coordinate, (i,j+1));  
                DFS(grid, m, n, (i,j+1), visited);
            }
        }
    }
    
    
    public DisjointSet(int m, int n, char[][] grid)
    {
        root = new (int,int)[m,n];
        rank = new int[m,n];
        var visited = new HashSet<(int,int)>();
        
        for(var i = 0; i < m; i++)
        {
            for(var j = 0; j < n; j++)
            {
                if (grid[i][j] == '1' && !visited.Contains((i,j)))
                {
                    rank[i,j] = 1; // just initialize
                    root[i,j] = (i,j); // just initialize
                    DFS(grid, m, n, (i,j), visited); // update rank and root
                }
                else
                {
                    root[i,j] = (-1,-1);
                }
            }
        }
    }
    
    public void Union((int, int) lhs, (int, int) rhs)
    {
        var (i,j) = lhs;
        var (t,s) = rhs;
        
        var lrank = rank[i,j];
        var rrank = rank[t,s];
        
        if (lrank >= rrank)
        {
            // put right under left
            root[t,s] = root[i,j];
            // left rank increases by 1
            rank[i,j] += 1;
        }
        else
        {
            // put left under right
            root[i,j] = root[t,s];
            // right rank increases by 1
            rank[t,s] += 1;
        }
    }
    
    public (int, int) FindRoot((int,int) node)
    {
        var (i,j) = node;
        var (t,s) = node;
        while(root[t,s] != (t,s))
            (t,s) = root[t,s];
            
        root[i,j] = (t,s);
        return root[i,j];
    }
    
    public (int,int)[,] Root => root;
}


public class Solution 
{
    public int NumIslands(char[][] grid) 
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var disjointSet = new DisjointSet(m, n, grid);
        
        var count = 0;
        for(var i = 0; i < m; i++)
        {
            for(var j = 0; j < n; j++)
            {
                if (disjointSet.Root[i,j] == (i,j))
                    count += 1;
            }
        }
        
        return count;
    }
}