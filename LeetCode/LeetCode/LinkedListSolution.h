#pragma once
#ifndef LINKEDLISTSOLUTION_H
#define LINKEDLISTSOLUTION_H
#include "ListNode.h"

class LinkedListSolution
{
public:
	ListNode* removeNthFromEnd(ListNode* head, int n);
	ListNode* getIntersectionNode(ListNode* headA, ListNode* headB);
	ListNode* getIntersectionNode2(ListNode* headA, ListNode* headB);
};
#endif // !LINKEDLISTSOLUTION_H

