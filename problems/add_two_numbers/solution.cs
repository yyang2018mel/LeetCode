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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
    {
        var promotion = 0;
        ListNode summation = new ListNode(-1); // mark as dummy node
        ListNode p = summation;
        
        while(l1 is not null || l2 is not null)
        {
            
            var l1Value = l1 is null ? 0 : l1.val;
            var l2Value = l2 is null ? 0 : l2.val;
            var rawSum = (int)(l1Value + l2Value + promotion);
            var newPromotion = rawSum / 10;
            var newNodeVal = rawSum % 10;            
            
            
            
            // update state
            p.next= new ListNode(newNodeVal);
            p = p.next;
            promotion = newPromotion;
            
            // move cursor
            if (l1 is not null)
                l1 = l1.next;
            if (l2 is not null)
                l2 = l2.next;
        }
        
        if (promotion != 0)
        {
            p.next = new ListNode(promotion);
        }
        
        return summation.next;
    }
}






