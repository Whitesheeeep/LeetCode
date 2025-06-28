ListNode GetIntersectionNode(ListNode headA, ListNode headB)
{
    ListNode curA = headA, curB = headB;
    ListNode res = null;


    // 问题：判断没有交点
    while (curA != curB)
    {
        curA = curA.next;
        curB = curB.next;
        if (curA == null) curA = headB;
        if (curB == null) curB = headA;
    }

    return curA;
}
