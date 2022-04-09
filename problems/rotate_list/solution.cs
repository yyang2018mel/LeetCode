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
    private (ListNode last, int oneBasedIdx) GetLast(ListNode head)
    {
        int oneBasedIdx = 0;
        ListNode last = head;

        while(last?.next != null)
        {
            last = last.next;
            oneBasedIdx++;
        }

        return (last, oneBasedIdx+1);
    }

    private (ListNode preCut, ListNode postCut) GetCutOff(ListNode head, int oneBasedIdx)
    {
        int count = 0;
        ListNode preCut = head;
        ListNode postCut = null;

        while(count < oneBasedIdx)
        {
            preCut = head;		
            head = head.next;
            count++;
        }

        postCut = head;

        return (preCut, postCut);
    }

    public ListNode RotateRight(ListNode head, int k)
    {
        if (head is null || head.next is null || k == 0) return head;
        
        var (last, length) = GetLast(head);
        var effectiveK = k % length;
        var cutoff = length - effectiveK;
        
        if(effectiveK == 0) return head;

        var (preCut, postCut) = GetCutOff(head, cutoff);

        preCut.next = null;
        last.next = head;
        return postCut;
    }
}