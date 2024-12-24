#include <iostream>
#include "MyLinkedList.h"

int main()
{
	using namespace std;
	MyLinkedList* myLinkedList = new MyLinkedList();
	myLinkedList->addAtHead(1);
	myLinkedList->addAtTail(3);
	cout << myLinkedList->size << endl;
	myLinkedList->addAtIndex(1, 2);    // 链表变为 1->2->3
	cout << myLinkedList->get(1) << endl;              // 返回 2
	myLinkedList->deleteAtIndex(1);    // 现在，链表变为 1->3
	cout << myLinkedList->get(1) << endl;              // 返回 3
	delete myLinkedList;
	return 0;
}