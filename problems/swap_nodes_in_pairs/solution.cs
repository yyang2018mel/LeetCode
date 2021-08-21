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

    private ListNode Swap(ListNode current)
    {
        if (current == null) return null;

        if (current.next == null) return current;

        // current <-> current.next
        var next2Pointer = current.next.next;
        var head = current.next;
        var tail = current;
        head.next = tail;
        tail.next = Swap(next2Pointer);

        return head;
    }


    public ListNode SwapPairs(ListNode head)
    {
        return Swap(head);
    }
}