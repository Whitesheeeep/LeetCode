
#include "ListNode.h"

class Solution {
public:
	ListNode* removeElements(ListNode* head, int val)
	{
		//����һ������ͷ�ڵ�
		ListNode* dummyHead = new ListNode(0);
		dummyHead->next = head;
		//����һ��ָ��ָ������ͷ�ڵ�
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