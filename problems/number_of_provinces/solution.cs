public class DisjointSet
{
    private int[] root;
    private int[] rank;
    
    private void DFSTraverse(int[][] adjacencyMatrix, int n, int nodeIdx, bool[] visited)
    {
        visited[nodeIdx] = true;
        for(var i = 0; i < n; i++)
        {
            if (!visited[i] && adjacencyMatrix[nodeIdx][i] == 1)
            {
                Union(nodeIdx, i);
                DFSTraverse(adjacencyMatrix, n, i, visited);
            }
        }
    }
    
    public DisjointSet(int[][] adjacencyMatrix, int n)
    {
        root = new int[n];
        rank = new int[n];
        
        var visited = new bool[n];
        for(var nodeIdx = 0; nodeIdx < n; nodeIdx++)
        {
            if(!visited[nodeIdx])
            {
                root[nodeIdx] = nodeIdx;
                rank[nodeIdx] = 1;
                DFSTraverse(adjacencyMatrix, n, nodeIdx, visited);
            }
        }
    }
    
    public void Union(int lhs, int rhs)
    {
        if (rank[lhs] >= rank[rhs])
        {
            root[rhs] = root[lhs];
            rank[lhs] += 1;
        }
        else 
        {
            root[lhs] = root[rhs];
            rank[rhs] += 1;
        }
    }
    
    public int FindRoot(int nodeIdx)
    {
        var node = nodeIdx;
        while(node != root[node])
            node = root[node];
        
        // path compression
        root[nodeIdx] = node;
        return root[nodeIdx];
    }
}



public class Solution 
{
    public int FindCircleNum(int[][] isConnected) 
    {
        var n = isConnected.Length;
        var disjointSet = new DisjointSet(isConnected, n);
        
        var provinces = new HashSet<int>();
        for(var i = 0; i < n; i++)
            provinces.Add(disjointSet.FindRoot(i));
        
        return provinces.Count;
    }
}