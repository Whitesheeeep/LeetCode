#include "LeetCode24_SwapPairs_Middle.h"

//LeetCode24: 两两交换链表中的节点：https://leetcode-cn.com/problems/swap-nodes-in-pairs/

ListNode* LeetCode24_SwapPairs_Middle::swapPairs(ListNode* head)
{
	if (head == nullptr || head->next == nullptr) return head;
	ListNode* dummyHead = new ListNode(0, head);
	ListNode* cur = dummyHead;

	//注意题目条件是相邻的两个节点交换，所以这里的判断条件是 cur->next != nullptr && cur->next->next != nullptr
	//如果节点数目是偶数，则最后 cur 指针正好移动到最后的节点，cur->next == nullptr，因此可以通过这个判断条件来判断是否到达最后一个节点
	//如果节点数目是奇数，则最后 cur 指针正好移动到倒数第二个节点，后面还有一个节点，但这个节点不用交换
	// cur->next->next == nullptr，因此可以通过这个判断条件来判断是否到达倒数第二个节点
	while (cur->next != nullptr && cur->next->next != nullptr )
	{
		ListNode* temp = cur->next;
		cur->next = cur->next->next;
		temp->next = cur->next->next;
		cur->next->next = temp;
		//移动指针
		cur = temp;//其实就是 cur = cur->next->next;
	}

	return dummyHead->next;
}

ListNode* LeetCode24_SwapPairs_Middle::swapPairs2(ListNode* head)
{
	if (head == nullptr || head->next == nullptr) return head;
	
	ListNode* temp = head->next;
	head->next = swapPairs2(head->next->next);
	temp->next = head;
	return temp;
	
}