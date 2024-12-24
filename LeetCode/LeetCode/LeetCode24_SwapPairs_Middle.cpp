#include "LeetCode24_SwapPairs_Middle.h"

//LeetCode24: �������������еĽڵ㣺https://leetcode-cn.com/problems/swap-nodes-in-pairs/

ListNode* LeetCode24_SwapPairs_Middle::swapPairs(ListNode* head)
{
	if (head == nullptr || head->next == nullptr) return head;
	ListNode* dummyHead = new ListNode(0, head);
	ListNode* cur = dummyHead;

	//ע����Ŀ���������ڵ������ڵ㽻��������������ж������� cur->next != nullptr && cur->next->next != nullptr
	//����ڵ���Ŀ��ż��������� cur ָ�������ƶ������Ľڵ㣬cur->next == nullptr����˿���ͨ������ж��������ж��Ƿ񵽴����һ���ڵ�
	//����ڵ���Ŀ������������� cur ָ�������ƶ��������ڶ����ڵ㣬���滹��һ���ڵ㣬������ڵ㲻�ý���
	// cur->next->next == nullptr����˿���ͨ������ж��������ж��Ƿ񵽴ﵹ���ڶ����ڵ�
	while (cur->next != nullptr && cur->next->next != nullptr )
	{
		ListNode* temp = cur->next;
		cur->next = cur->next->next;
		temp->next = cur->next->next;
		cur->next->next = temp;
		//�ƶ�ָ��
		cur = temp;//��ʵ���� cur = cur->next->next;
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