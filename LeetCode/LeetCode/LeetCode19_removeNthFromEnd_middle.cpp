#include "LinkedListSolution.h"

//时间复杂度：O(n)，空间复杂度：O(1)
ListNode* LinkedListSolution::removeNthFromEnd(ListNode* head, int n)
{
	if (head == nullptr) return nullptr;
	ListNode* dummyHead = new ListNode(0, head);
	ListNode* slow = dummyHead;
	ListNode* fast = dummyHead;

	//快指针先走n步
	while (n)
	{
		fast = fast->next;
		n--;
	}

	//快慢指针同时走，直到快指针走到最后一个节点
	while (fast->next != nullptr)
	{
		slow = slow->next;
		fast = fast->next;
	}

	slow->next = slow->next->next;
	delete dummyHead;
	delete slow;
	delete fast;
	return dummyHead->next;

}