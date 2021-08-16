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
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var t = 0;
            var tFromTail = head;
            var tail = head;
            ListNode tFromTailPrev = null;

            while (tail.next != null)
            {
                if (t == n - 1)
                {
                    tFromTailPrev = tFromTail;
                    tFromTail = tFromTail.next;
                    tail = tail.next;
                }
                else
                {
                    tail = tail.next;
                    t++;
                }
            }

            if (tFromTailPrev == null)
            {
                head = tFromTail.next;
            }
            else if(tFromTail == null)
            {
                tFromTailPrev.next = null;
            }
            else
            {
                tFromTailPrev.next = tFromTail.next;
            }
            
            return head;
        }
    }