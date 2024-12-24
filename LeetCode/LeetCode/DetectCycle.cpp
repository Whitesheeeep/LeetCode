#include "LinkedListSolution.h"
#include <unordered_set> // 添加此行

using namespace std;

ListNode* LinkedListSolution::DetectCycle(ListNode* head)
{
	unordered_set<ListNode*> visited;
	// 其他代码
	ListNode* cur = head;
	while (cur)
	{
		if (visited.count(cur))
		{
			return cur;
		}
		visited.insert(cur);
		cur = cur->next;
	}
    return nullptr;
}

ListNode* LinkedListSolution::DetectCycle2(ListNode* head)
{
	if (head == nullptr || head->next == nullptr) return nullptr;
	
	ListNode* slow = head, *fast = head;
	while (fast != nullptr && fast->next != nullptr)
	{
		slow = slow->next;
		fast = fast->next->next;
		if (fast == slow)
		{
			ListNode* ptr = head;
			while (ptr != slow)
			{
				ptr = ptr->next;
				slow = slow->next;
			}
			return ptr;
		}
	}

	return nullptr;
}