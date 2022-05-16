public class DisjointSet
{
    private int[] root;
    private int[] rank;
    private HashSet<int> visited;
    public DisjointSet(int n)
    {
        root = Enumerable.Range(0,n).Select(i => i).ToArray();
        rank = Enumerable.Range(0,n).Select(_ => 1).ToArray();
        visited = new HashSet<int>();
    }
    
    public void Union(int lhs, int rhs)
    {
        if (!visited.Contains(lhs) && visited.Contains(rhs))
            Union(rhs, lhs);
        
        if (rank[lhs] >= rank[rhs])
        {
            root[FindRoot(rhs)] = FindRoot(lhs);
            rank[lhs] += 1;
        }
        else
        {
            root[FindRoot(lhs)] = FindRoot(rhs);
            rank[rhs] += 1;
        }
        visited.Add(lhs);
        visited.Add(rhs);
    }
    
    public int FindRoot(int person)
    {
        int p = person;
        while(root[p] != p)
            p = root[p];
        
        root[person] = p;
        return root[person];
    }
}


public class Solution 
{
    public int EarliestAcq(int[][] logs, int n) 
    {
        // the logs are not sorted!
        Array.Sort(logs, Comparer<int[]>.Create((lhs,rhs) => lhs[0]-rhs[0]));
        
        var disjointSet = new DisjointSet(n);
        foreach(var log in logs)
        {
            var time = log[0];
            var p1 = log[1];
            var p2 = log[2];
            disjointSet.Union(p1, p2);
            
            var roots =
                Enumerable.Range(0,n)
                .Select(p => disjointSet.FindRoot(p))
                .ToHashSet();
            if (roots.Count == 1)
                return time;
        }
        
        return -1;
    }
}