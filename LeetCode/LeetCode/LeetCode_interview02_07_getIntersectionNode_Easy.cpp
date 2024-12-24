#include "LinkedListSolution.h"


//ʱ�临�Ӷȣ�O(m+n)���ռ临�Ӷȣ�O(1)
ListNode* LinkedListSolution::getIntersectionNode(ListNode* headA, ListNode* headB) {
	if (headA == nullptr || headB == nullptr) return nullptr;
	
	ListNode* pA = headA, * pB = headB;
	while (pA != pB)
	{
		pA = pA == nullptr ? headB : pA->next;
		pB = pB == nullptr ? headA : pB->next;
	}
	//���õ������ pA �� pB ���� nullptr ���������Ϊ�����������û�н��㣬��� pA �� pB ����ָ�� nullptr���˳�ѭ��
	return pA;
	
}

#include <utility>
ListNode* LinkedListSolution::getIntersectionNode2(ListNode* headA, ListNode* headB)
{
	using namespace std;

	if (headA == nullptr || headB == nullptr) return nullptr;

	ListNode* pA = headA, * pB = headB;
	int lenA = 0, lenB = 0;
	while (pA)
	{
		lenA++;
		pA = pA->next;
	}
	while (pB)
	{
		lenB++;
		pB = pB->next;
	}
	pA = headA;
	pB = headB;
	if (lenA < lenB)
	{
		swap (lenA, lenB);
		swap(pA, pB);
	}

	int diff = lenA - lenB;
	while (diff--) pA = pA->next;
	while (pA != pB)
	{
		pA = pA->next;
		pB = pB->next;
	}

	return pA;
}
