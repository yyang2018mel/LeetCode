/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution 
{
    public ListNode RemoveElements(ListNode head, int val) 
    {
        if (head is null) return head;
        
        ListNode predecessor = null;
        ListNode pointer = head;
        
        while(pointer is not null)
        {
            var nextPointer = pointer.next;
            
            if (pointer.val == val)
            {
                if (predecessor is not null)
                    predecessor.next = nextPointer;
                else
                    head = nextPointer;
            }
            else
            {
                predecessor = pointer;    
            }
            
            pointer = nextPointer;
        }
            
        return head;
    }
}







