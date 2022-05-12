public class Solution 
{
    
    private int _source;
    private int _target;
    
    private List<IList<int>> _result = new List<IList<int>>();
    
    private void Traverse(int[][] adjacencyList, int node, List<int> pathPending, HashSet<int> visited)
    {
        if (node == _target)
        {
            var path = pathPending;
            _result.Add(path as IList<int>);
            
            foreach(var n in path)
                visited.Remove(n);
            
            return;
        }
        
        foreach(var neighbor in adjacencyList[node])
        {
            if (visited.Contains(neighbor)) continue;
            
            var newPathPending = new List<int>(pathPending);
            newPathPending.Add(neighbor);
            visited.Add(neighbor);
            Traverse(adjacencyList, neighbor, newPathPending, visited);
        }
    }
    
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) 
    {
        _source = 0;
        _target = graph.Length-1;
        var initPath = new List<int> { _source };
        // var initVisited = new HashSet<int>();
        // initVisited.Add(_source);
        
        Traverse(graph, _source, new List<int>{ _source }, new HashSet<int>{ _source });
        
        return _result as IList<IList<int>>;
    }
}