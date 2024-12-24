using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.LinkedList
{
    public class LeetCode24_SwapPairs_middle
    {
        //迭代写法
        //时间复杂度：O(n)；空间复杂度：O(1)
        public ListNode SwapPairs(ListNode head)
        {
            if(head == null || head.next == null) return head;

            ListNode dummyHead = new ListNode(-1);
            dummyHead.next = head;
            ListNode cur = dummyHead;
            while(cur.next != null && cur.next.next != null)
            {
                ListNode temp = cur.next;
                cur.next = cur.next.next;
                temp.next = temp.next.next;
                cur.next.next = temp;
                cur = temp;
            }

            return dummyHead.next;
        }

        //递归写法
        //时间复杂度：O(n)；空间复杂度：O(n)
        public ListNode SwapPairs2(ListNode head)
        {
            if(head == null || head.next == null) return head;

            ListNode temp = head.next;
            head.next = SwapPairs2(temp.next);
            temp.next = head;
            return temp;
        }
    }
}
