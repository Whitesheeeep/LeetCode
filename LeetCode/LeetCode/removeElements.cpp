#include "ListNode.h"

class Solution
{
public:
	ListNode* removeElements(ListNode* head, int val)
	{
		ListNode* dummyHead = new ListNode();
		dummyHead->next = head;

		ListNode* cur = dummyHead;
		while (cur->next != nullptr)
		{
			if (cur->next->val != val)
			{
				cur->next = cur->next->next;
			}
			else
			{
				cur = cur->next;
			}
		}
		return dummyHead->next;
	}
};