#include "LeetCode206_ReverseLinkedList.h"

//采用迭代的方式
//时间复杂度：O(n)，空间复杂度：O(1)
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

//采用递归的方式
//时间复杂度：O(n)，空间复杂度：O(n)
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

