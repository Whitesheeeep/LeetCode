using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.LinkedList
{
    public class LeetCode19_RemoveNthFromEnd_middle
    {
        public ListNode  RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummyHead = new ListNode(-1, head);
            ListNode fast = dummyHead;
            ListNode slow = dummyHead;
            
            //快指针先走n步，也可以先走 n+1 步，那下面的 while 判断就不一样了
            while(n-- > 0)
            {
                fast = fast.next;
            }
            while(fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            slow.next = slow.next.next;
            return dummyHead.next;
        }
    }
}
