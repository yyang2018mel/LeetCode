/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution 
{
    private Dictionary<int, (Node N, IEnumerable<Node> L)> _copiedNodes = 
        new Dictionary<int, (Node, IEnumerable<Node>)>();
    
    private void DFSForCopyingValueOnly(Node node)
    {
        var key = node.val;
        var val = (new Node(node.val), node.neighbors);
        _copiedNodes.Add(key, val);
        
        foreach(var neighbor in node.neighbors)
            if(!_copiedNodes.ContainsKey(neighbor.val))
                DFSForCopyingValueOnly(neighbor);
    }
    
    private void CopyNeighbors()
    {
        foreach(var dv in _copiedNodes.Values)
        {
            var valueCopiedNode = dv.N;
            valueCopiedNode.neighbors = dv.L
                                        .Select(i => _copiedNodes[i.val].N)
                                        .ToList();
        }
    }
    
    
    public Node CloneGraph(Node node) 
    {
        if (node is null) return null;
        
        DFSForCopyingValueOnly(node);
        CopyNeighbors();
        
        return _copiedNodes[node.val].N;
    }
}