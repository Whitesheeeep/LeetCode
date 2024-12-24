
#include "ListNode.h"

class Solution {
public:
	ListNode* removeElements(ListNode* head, int val)
	{
		//创建一个虚拟头节点
		ListNode* dummyHead = new ListNode(0);
		dummyHead->next = head;
		//创建一个指针指向虚拟头节点
		ListNode* cur = dummyHead;
		while (cur->next != nullptr)
		{
			if (cur->next->val == val)
			{
				cur->next = cur->next->next;
				
				break;
			}
			else
				cur = cur->next;
		}
		delete dummyHead;
		return dummyHead->next;
	}
};