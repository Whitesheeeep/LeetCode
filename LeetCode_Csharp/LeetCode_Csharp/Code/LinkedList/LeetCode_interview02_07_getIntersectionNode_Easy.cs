using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.LinkedList
{
    public class LeetCode_interview02_07_getIntersectionNode_Easy
    {
        //Solution1: 合并链表实现同步移动：时间复杂度O(m+n)，空间复杂度O(1)
        //如果 A 、B 链表长度相同，那么它们始终同步移动
        //如果 A 、B 链表长度不同，那么它们会在第二次遍历时同步移动
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if(headA == null || headB == null) return null;
            ListNode pA = headA;
            ListNode pB = headB;
            while(pA != pB)
            {
                pA = pA == null ? headB : pA.next;
                pB = pB == null ? headA : pB.next;
            }

            return pA;
        }

        //Solution2: 哈希表实现：时间复杂度O(m+n)，空间复杂度O(m)或O(n)
        public ListNode GetIntersectionNode2(ListNode headA, ListNode headB)
        {
            if(headA == null || headB == null) return null;
            HashSet<ListNode> set = new HashSet<ListNode>();
            ListNode pA = headA;
            ListNode pB = headB;
            while(pA != null)
            {
                set.Add(pA);
                pA = pA.next;
            }
            while(pB != null)
            {
                if(set.Contains(pB)) return pB;
                pB = pB.next;
            }

            return null;
        }

        //Solution3: 先算出每个链表的长度，然后让长的链表先走差值步，然后两个链表同时走，直到相遇
        //时间复杂度O(m+n)，空间复杂度O(1)
        public ListNode GetIntersectionNode3(ListNode headA, ListNode headB)
        {
            if(headA == null || headB == null) return null;
            
            ListNode pA = headA, pB = headB;
            int lenA = 0, lenB = 0;
            while(pA != null)
            {
                lenA++;
                pA = pA.next;
            }
            while(pB != null)
            {
                lenB++;
                pB = pB.next;
            }

            //pA 指向长链表头结点，pB 指向短链表头结点
            //重置指针
            (pA , pB) = lenA > lenB ? (headA, headB) : (headB, headA);
            (lenA, lenB) = lenA > lenB ? (lenA, lenB) : (lenB, lenA);
            //以 lenA 为长链表长度，pA 为长链表指针头结点
            int diff = Math.Abs(lenA - lenB);

            while(diff-- > 0)
            {
                pA = pA.next;
            }

            while(pA != pB)
            {
                pA = pA.next;
                pB = pB.next;
            }
            return pA;


        }



    }
}
