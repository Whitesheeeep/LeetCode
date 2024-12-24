#include <iostream>
#include "MyLinkedList.h"

int main()
{
	using namespace std;
	MyLinkedList* myLinkedList = new MyLinkedList();
	myLinkedList->addAtHead(1);
	myLinkedList->addAtTail(3);
	cout << myLinkedList->size << endl;
	myLinkedList->addAtIndex(1, 2);    // �����Ϊ 1->2->3
	cout << myLinkedList->get(1) << endl;              // ���� 2
	myLinkedList->deleteAtIndex(1);    // ���ڣ������Ϊ 1->3
	cout << myLinkedList->get(1) << endl;              // ���� 3
	delete myLinkedList;
	return 0;
}