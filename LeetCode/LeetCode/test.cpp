#include <unordered_set>
#include <vector>
#include <iostream>
#include "ListNode.h"

using namespace std;

int main()
{
	cout << "main Ö´ÐÐ" << endl;
	return 0;
}


ListNode* GerIntersectionNode(ListNode* headA, ListNode* headB)
{
	ListNode* curA = headA, * curB = headB;

	while (curA != curB)
	{
		curA = curA == NULL ? headB : curA->next;
		curB = curB == NULL ? headA : curB->next;
	}
	return curA;
}