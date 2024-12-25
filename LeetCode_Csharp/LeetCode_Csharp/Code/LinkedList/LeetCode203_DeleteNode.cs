using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.LinkedList
{
    public class LeetCode203_DeleteNode
    {
        //采用虚拟头结点的方法
        public ListNode RemoveElements(ListNode head, int val)
        {
            //创建一个虚拟头结点
            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;
            //创建一个指针指向虚拟头结点
            ListNode cur = dummyHead;
            while(cur.next != null)
            {
                if(cur.next.val == val)
                {
                    cur.next = cur.next.next;
                }
                else
                {
                    cur = cur.next;
                }
            }
            

            return dummyHead.next;
        }
    
        //不采用虚拟头结点的方法
        [return: MaybeNull]
        public ListNode RemoveElements2(ListNode head, int val)
        {
            while(head != null && head.val == val)
            {
                head = head.next;
            }

            if(head != null && head.next != null)
            {
                ListNode cur = head;
                while(cur.next != null)
                {
                    if(cur.next.val == val)
                    {
                        cur.next = cur.next.next;
                    }
                    else
                    {
                        cur = cur.next;
                    }
                }
            }
            
            return head;
        }
    }
}
