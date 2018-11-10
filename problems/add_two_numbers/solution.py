# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, x):
#         self.val = x
#         self.next = None

def get_int(l):
    l_head, l_tail = l.val, l.next
    return l_head + (10 * get_int(l_tail) if l_tail else 0)
        
def parse_int(n):
    n_str = str(n)[::-1]
    l = ListNode(None)
    current = l
    for i in range(len(n_str)):
        e = int(n_str[i])
        current.val = e
        if i != len(n_str)-1:
            current.next = ListNode(None)
            current = current.next    
    return l

class Solution:
    def addTwoNumbers(self, l1, l2):
        result = get_int(l1)+get_int(l2)
        return parse_int(result)
        

        
    

            
        