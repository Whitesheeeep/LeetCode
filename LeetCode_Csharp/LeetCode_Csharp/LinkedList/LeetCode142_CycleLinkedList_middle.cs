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
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 33a82977e8241ab95b408c08604140b55f33d991

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
<<<<<<< HEAD
=======
=======
            //第一次相遇，同时判断是否有环
>>>>>>> cde8c89791c0ff35f8bbdec52c060d8272902335
>>>>>>> 33a82977e8241ab95b408c08604140b55f33d991
            return null;
        }
    }

}
