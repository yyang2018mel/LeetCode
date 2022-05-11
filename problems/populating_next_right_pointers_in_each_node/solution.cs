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
    public Node Connect(Node root) 
    {
        if (root is null) return null;
        
        if (root.left is null && root.right is null) return root;
        
        root.left.next = root.right;
        
        var startOfLevel = root.left;   
        while(startOfLevel.left is not null)
        {
            var cursorOfLevel = startOfLevel;
            while(cursorOfLevel is not null)
            {
                cursorOfLevel.left.next = cursorOfLevel.right;
                
                if (cursorOfLevel.next is not null)
                    cursorOfLevel.right.next = cursorOfLevel.next.left;
                
                cursorOfLevel = cursorOfLevel.next;
            }
            
            // go to the next level
            startOfLevel = startOfLevel.left;
        }
        
        return root;
    }
}