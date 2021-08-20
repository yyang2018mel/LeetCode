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
    public ListNode Merge2Lists(ListNode l1, ListNode l2)
    {
        if (l1 == null) return l2;
        if (l2 == null) return l1;
        ListNode lead = l1.val < l2.val ? l1 : l2;
        ListNode lag = lead == l1 ? l2 : l1;
        ListNode toReturn = lead;

        while(lead != null && lag != null)
        {
            if(lead.next == null)
            {
                lead.next = lag;
                break;
            }
            else if (lead.next.val < lag.val)
            {
                lead = lead.next;
            }
            else if (lead.next.val >= lag.val)
            {
                var originalLeadNext = lead.next;
                var originalLagNext = lag.next;
                lead.next = lag;
                lead.next.next = originalLeadNext;
                lead = lead.next;
                lag = originalLagNext;
            }
        }

        return toReturn;
    }

    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.Length == 0) return null;
        if (lists.Length == 1) return lists[0];

        var newListArray = new ListNode[lists.Length / 2 + (lists.Length % 2 == 0 ? 0 : 1)];

        for (var i = 0; i < newListArray.Length; i++)
        {
            if (i == newListArray.Length - 1 && lists.Length % 2 != 0)
            {
                newListArray[i] = lists[2 * i];
                break;
            }
            newListArray[i] = Merge2Lists(lists[2 * i], lists[2 * i + 1]);
        }

        return MergeKLists(newListArray);
    }
}