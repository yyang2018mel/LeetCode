/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public record TreeRepr(
    List<int> InOrder, 
    List<int> PostOrder,
    Dictionary<int, int> Indexing);

public class Codec {

    private Dictionary<int, int> _index2Value = new Dictionary<int, int>();
    
    private void PreOrderIndexing(TreeNode node)
    {
        if (node is null) return;
        
        var index = _index2Value.Count; 
        _index2Value[index] = node.val;
        node.val = index;
        
        PreOrderIndexing(node.left);
        PreOrderIndexing(node.right);
    }
    
    private void PreOrderDeIndexing(TreeNode node)
    {
        if (node is null) return;
        
        var index = node.val;
        var val = _index2Value[node.val];
        node.val = val;
        
        PreOrderDeIndexing(node.left);
        PreOrderDeIndexing(node.right);
    }
    
    private List<int> InOrder(TreeNode node)
    {
        if (node is null) return new List<int>();
        var left   = InOrder(node.left);
        var right  = InOrder(node.right);
        var result = left;
        result.Add(node.val);
        result.AddRange(right);
        return result;
    }
    
    private List<int> PostOrder(TreeNode node)
    {
        if (node is null) return new List<int>();
        
        var left   = PostOrder(node.left);
        var right  = PostOrder(node.right);
        var result = left;
        result.AddRange(right);
        result.Add(node.val);
        return result;
    }
    
    public TreeNode BuildTree(List<int> inorder, List<int> postorder) 
    {
        if (inorder.Count == 0 && postorder.Count == 0)
            return null;
        
        var rootVal = postorder[postorder.Count-1];
        var rootIdx = inorder.FindIndex(e => e == rootVal);
        var leftNodesInOrder = new List<int>();
        var rightNodesInOrder = new List<int>();
        for(var i = 0; i < inorder.Count; i++)
        {
            if (i < rootIdx)
                leftNodesInOrder.Add(inorder[i]);
            else if (i > rootIdx)
                rightNodesInOrder.Add(inorder[i]);
        }
        
        var leftNodesPostOrder = new List<int>();
        var rightNodesPostOrder = new List<int>();
        for(var i = 0; i < postorder.Count-1; i++)
        {
            if (leftNodesPostOrder.Count < leftNodesInOrder.Count)
                leftNodesPostOrder.Add(postorder[i]);
            else
                rightNodesPostOrder.Add(postorder[i]);
        }
        
        return new TreeNode(rootVal,
                            BuildTree(leftNodesInOrder, leftNodesPostOrder),
                            BuildTree(rightNodesInOrder, rightNodesPostOrder));
    }
    
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) 
    {
        PreOrderIndexing(root);
        
        var inorder = InOrder(root);
        var postorder = PostOrder(root);
        var repr = new TreeRepr(inorder, postorder, _index2Value);
        var reprStr = System.Text.Json.JsonSerializer.Serialize(repr);
        
        Console.WriteLine(reprStr);
        return reprStr;
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) 
    {
        var repr = System.Text.Json.JsonSerializer.Deserialize<TreeRepr>(data); 
        var inorder = repr.InOrder;
        var postorder = repr.PostOrder;
        _index2Value = repr.Indexing;
        var tree = BuildTree(inorder, postorder);
        
        PreOrderDeIndexing(tree);
        return tree;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));