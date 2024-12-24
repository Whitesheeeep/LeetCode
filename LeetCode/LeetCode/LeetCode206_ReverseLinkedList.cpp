#include "LeetCode206_ReverseLinkedList.h"

//���õ����ķ�ʽ
//ʱ�临�Ӷȣ�O(n)���ռ临�Ӷȣ�O(1)
ListNode* LeetCode206_ReverseLinkedList::ReverseList(ListNode* head)
{
	ListNode* prev = nullptr;
	ListNode* cur = head;
	while (cur)
	{
		ListNode* temp = cur->next;
		cur->next = prev;

		prev = cur;
		cur = temp;
	}
	return prev;
}

//���õݹ�ķ�ʽ
//ʱ�临�Ӷȣ�O(n)���ռ临�Ӷȣ�O(n)
ListNode* LeetCode206_ReverseLinkedList::ReverseList2(ListNode* head)
{
	return reverse(nullptr, head);
}

ListNode* reverse(ListNode* pre, ListNode* cur)
{
	if (cur == nullptr) return pre;
	ListNode* temp = cur->next;
	cur->next = pre;
	return reverse(cur, temp);
}

