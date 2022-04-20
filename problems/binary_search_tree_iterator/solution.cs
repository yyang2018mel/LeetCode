/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class BSTIterator {

    private List<int> _listVal;
    
    private int _pointer;
    
    private List<int> InorderTraversal(TreeNode node)
    {
        var valList = new List<int>();
        
        if (node.left is not null)
            valList.AddRange(InorderTraversal(node.left));
        
        valList.Add(node.val);
        
        if (node.right is not null)
            valList.AddRange(InorderTraversal(node.right));
        
        return valList;
    }
    
    public BSTIterator(TreeNode root) 
    {
        _listVal = InorderTraversal(root);
        _pointer = -1;
    }
    
    public int Next() 
    {
        return _listVal[++_pointer];
    }
    
    public bool HasNext() 
    {
        return (_pointer + 1) < _listVal.Count;
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */