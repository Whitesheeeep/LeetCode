#include "LinkedListSolution.h"

//ʱ�临�Ӷȣ�O(n)���ռ临�Ӷȣ�O(1)
ListNode* LinkedListSolution::removeNthFromEnd(ListNode* head, int n)
{
	if (head == nullptr) return nullptr;
	ListNode* dummyHead = new ListNode(0, head);
	ListNode* slow = dummyHead;
	ListNode* fast = dummyHead;

	//��ָ������n��
	while (n)
	{
		fast = fast->next;
		n--;
	}

	//����ָ��ͬʱ�ߣ�ֱ����ָ���ߵ����һ���ڵ�
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