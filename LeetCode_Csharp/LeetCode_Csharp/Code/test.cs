ListNode RemoveNthFromEnd(ListNode head, int n)
{
    ListNode dummyHead = new ListNode() { next = head };
    ListNode slow = dummyHead, fast = dummyHead;

    while (n-- >= 0)
    {
        fast = fast.next;
    }

    while (true)
    {
        if (fast != null)
        {
            fast = fast.next;
            slow = slow.next;
        }
        else
        {
            slow.next = slow.next.next;
            break;
        }
    }
    return dummyHead.next;

}
