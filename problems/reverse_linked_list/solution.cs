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
public class Solution {
    public ListNode ReverseList(ListNode head) {
        
        if(head == null || head.next == null) return head;
        
        var newTail = ReverseList(head.next);
        var newTailEnd = head.next;
        
        var newEnd = head;
        newEnd.next = null;
        newTailEnd.next = newEnd;
        return newTail;
            
        
    }
}