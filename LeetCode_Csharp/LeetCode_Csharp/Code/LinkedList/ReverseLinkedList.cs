using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.LinkedList
{
    public class ReverseLinkedList
    {
        //迭代写法
        //时间复杂度：O(n)；空间复杂度：O(1)
        [return: MaybeNull]
        public ListNode ReverseList(ListNode head)
        {
            //定义两个指针
            ListNode pre = null;
            ListNode cur = head;
            while (cur != null)
            {
                ListNode temp = cur.next;
                cur.next = pre;
                pre = cur;
                cur = temp;
            }
            return pre;
        }
    }

    //递归写法
    //时间复杂度：O(n)；空间复杂度：O(n)
    public class ReverseLinkedList2
    {
        [return: MaybeNull]
        public ListNode ReverseList(ListNode head)
        {
            return Reverse(null, head);
        }

        private ListNode Reverse(ListNode pre, ListNode cur)
        {
            if (cur == null) return pre;
            ListNode temp = cur.next;
            cur.next = pre;
            return Reverse(cur, temp);
        }

        public ListNode ReverseList2(ListNode head)
        {
            if(head == null) return null;
            if(head.next == null) return head;

            ListNode last = ReverseList2(head.next);
            head.next.next = head;
            head.next = null;
            return last;
        }
    }
}
