public class DisjointSet
{
    private int[] root;
    private int[] rank;
    
    public DisjointSet(List<int>[] adjacencyList, int n)
    {
        root = new int[n];
        rank = new int[n];
        var visited = new HashSet<int>();
        for(var nodeIdx = 0; nodeIdx < n; nodeIdx++)
            if (!visited.Contains(nodeIdx))
            {
                root[nodeIdx] = nodeIdx;
                rank[nodeIdx] = 1;
                DFS(adjacencyList, nodeIdx, visited);
            }
    }
    
    private void DFS(List<int>[] adjacencyList, int nodeIdx, HashSet<int> visited)
    {
        visited.Add(nodeIdx);
        foreach(var neighbor in adjacencyList[nodeIdx] ?? new List<int>())
            if (!visited.Contains(neighbor))
            {
                Union(nodeIdx, neighbor);
                DFS(adjacencyList, neighbor, visited);
            }
    }
    
    public void Union(int lhs, int rhs)
    {
        if (rank[lhs] >= rank[rhs])
        {
            root[rhs] = FindRoot(lhs);
            rank[lhs] += 1;
        }
        else
        {
            root[lhs] = FindRoot(rhs);
            rank[rhs] += 1;
        }
    }
    
    public int FindRoot(int nodeIdx)
    {
        var nodePointer = nodeIdx;
        while(root[nodePointer] != nodePointer)
            nodePointer = root[nodePointer];
            
        root[nodeIdx] = nodePointer;
        return root[nodeIdx];
    }
}


public class Solution 
{
    public int CountComponents(int n, int[][] edges) 
    {
        var adjacencyList = new List<int>[n];
        foreach(var edge in edges)
        {
            if (adjacencyList[edge[0]] is null)
                adjacencyList[edge[0]] = new List<int> { edge[1] };
            else 
                adjacencyList[edge[0]].Add(edge[1]);
            
            if (adjacencyList[edge[1]] is null)
                adjacencyList[edge[1]] = new List<int> { edge[0] };
            else 
                adjacencyList[edge[1]].Add(edge[0]);   
        }
        
        var disjointSet = new DisjointSet(adjacencyList, n);
        
        var components = new HashSet<int>();
        for(var i = 0; i < n; i++)
            components.Add(disjointSet.FindRoot(i));
        
        return components.Count;
    }
}