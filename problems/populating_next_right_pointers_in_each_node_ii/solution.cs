/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution 
{
    
    private Node GetLeftMostChild(Node node)
    {
        if (node.left is not null) 
            return node.left;
        else if (node.right is not null)
            return node.right;
        
        return null;
    }
    
    private Node ConnectSubtreeAndReturnRightMost(Node node)
    {
        if (node.left is not null && node.right is not null)
        {
            node.left.next = node.right;
            return node.right;
        }
        return node.left ?? node.right;
    }
    
    public Node Connect(Node root) 
    {
        if (root is null) 
            return null;
        
        if (root.left is null && root.right is null) 
            return root;
        
        // normal cases
        if(root.left is not null && root.right is not null)
            root.left.next = root.right;
        
        var crossLevelPointer = GetLeftMostChild(root);
        
        while(crossLevelPointer is not null)
        {
            var inLevelPointer = crossLevelPointer;
            while(inLevelPointer is not null)
            {
                var rightMost = ConnectSubtreeAndReturnRightMost(inLevelPointer);
                if (rightMost is not null && inLevelPointer.next is not null)
                {
                    var inLevelPointer2 = inLevelPointer.next;
                    var leftMostChild = GetLeftMostChild(inLevelPointer2);
                    while(leftMostChild is null && inLevelPointer2.next is not null)
                    {
                        inLevelPointer2 = inLevelPointer2.next;
                        leftMostChild = GetLeftMostChild(inLevelPointer2);
                    }
                    
                    rightMost.next = leftMostChild;
                }
                inLevelPointer = inLevelPointer.next;
            }
            
            var inLevelPointer3 = crossLevelPointer;
            var nextLevel = GetLeftMostChild(inLevelPointer3);
            while(nextLevel is null && inLevelPointer3.next is not null)
            {
                inLevelPointer3 = inLevelPointer3.next;
                nextLevel = GetLeftMostChild(inLevelPointer3);
            }
            crossLevelPointer = nextLevel;
        }
        
        return root;
    }
}