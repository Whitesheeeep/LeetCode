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


ListNode* removeNthFromEnd(ListNode* head, int n)
{
	ListNode* dummyHead = new ListNode(0,head);
	ListNode* slow = dummyHead, *fast = dummyHead;
	while (n--)
	{
		fast = fast->next;
	}

	while (fast != nullptr)
	{
		fast = fast->next;
		slow = slow->next;
	}
	slow->next = slow->next->next;
	return dummyHead->next;
}