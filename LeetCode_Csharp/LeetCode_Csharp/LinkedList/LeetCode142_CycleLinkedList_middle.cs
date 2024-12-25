using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.LinkedList
{
    public class LeetCode142_CycleLinkedList_middle
    {
        public ListNode DetectCycle(ListNode head)
        {
            if(head == null || head.next == null) return null;
            HashSet<ListNode> hashSet = new HashSet<ListNode>();
            ListNode current = head;
            while(current != null && hashSet.Contains(current) == false)
            {
                hashSet.Add(current);
                if(current.next == null) return null;
                current = current.next;
            }
            return current;
        }
        public ListNode DetectCycle2(ListNode head)
        {
            if(head == null || head.next == null) return null;
            ListNode slow = head, fast = head;

            //第一次相遇，同时判断是否有环
            while(fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if(fast == slow)
                {
                    ListNode newP = head;
                    while(slow != newP)
                    {
                        slow = slow.next;
                        newP = newP.next;
                    }
                    return newP;
                }
            }
            return null;
        }
    }

}
