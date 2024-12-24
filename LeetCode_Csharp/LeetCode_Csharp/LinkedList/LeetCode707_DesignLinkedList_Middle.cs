using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.LinkedList
{
    public class LeetCode707_DesignLinkedList_Middle
    {
        public class MyLinkedList 
        {
            private int size;
            private ListNode dummyHead;


            public MyLinkedList() {
                size = 0;
                dummyHead = new ListNode(0);
            }
            
            public int Get(int index) {
                if(index < 0 || index >= size)
                {
                    return -1;
                }

                ListNode cur = dummyHead;
                while(index > 0)
                {
                    cur = cur.next;
                    index--;
                }

                return cur.next.val;
            }
            
            public void AddAtHead(int val) {
                AddAtIndex(0, val);
            }
            
            public void AddAtTail(int val) {
                AddAtIndex(size, val);
            }
            
            public void AddAtIndex(int index, int val) {
                if(index < 0 || index > size) return;
                ListNode cur = dummyHead;
                while(index > 0)
                {
                    cur = cur.next;
                    index--;
                }

                //插入节点
                //注意：这里的顺序不能颠倒，因为我们现在知道cur是index的前一个节点
                //而我们要插入新节点的 next 指针指向 cur->next
                //如果我们先将cur->next赋值给newNode->next，那么cur->next就会指向newNode
                //这样就会丢失cur->next的指向
                ListNode newNode = new ListNode(val);
                newNode.next = cur.next;
                cur.next = newNode;

                size++;
            }
            
            public void DeleteAtIndex(int index) {
                if(index < 0 || index >= size) return;
                ListNode cur = dummyHead;
                while(index > 0)
                {
                    cur = cur.next;
                    index--;
                }

                cur.next = cur.next.next;
                size--;
            }
        }

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */
    }
    
}
