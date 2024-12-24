#include "LinkedListSolution.h"


//时间复杂度：O(m+n)，空间复杂度：O(1)
ListNode* LinkedListSolution::getIntersectionNode(ListNode* headA, ListNode* headB) {
	if (headA == nullptr || headB == nullptr) return nullptr;
	
	ListNode* pA = headA, * pB = headB;
	while (pA != pB)
	{
		pA = pA == nullptr ? headB : pA->next;
		pB = pB == nullptr ? headA : pB->next;
	}
	//不用担心最后 pA 和 pB 都是 nullptr 的情况，因为如果两个链表没有交点，最后 pA 和 pB 都会指向 nullptr，退出循环
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
