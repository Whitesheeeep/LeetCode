#include "MyLinkedList.h"

class MyLinkedList
{
public:
	struct ListNode
	{
		int val;
		ListNode* next;
		ListNode() : val(0), next(nullptr) {}
		ListNode(int x) : val(x), next(nullptr) {}
		ListNode(int x, ListNode* next) : val(x), next(next) {}
	};

	MyLinkedList()
	{
		dummyHead = new ListNode(0);
		size = 0;
	}

	int get(int index)
	{
		if (index < 0 || index >= size) return -1;
		
		//先找到index的前一个节点
		ListNode* cur = dummyHead;
		while (index)
		{
			cur = cur->next;
			index--;
		}

		return cur->next->val;
	}

	void addAtHead(int val)
	{
		addAtIndex(0, val);
	}
	void addAtTail(int val)
	{
		addAtIndex(size, val);
	}

	void addAtIndex(int index, int val)
	{
		if (index < 0 || index > size) return;
		ListNode* cur = dummyHead;
		
		//找到index的前一个节点
		while(index)
		{
			cur = cur->next;
			index--;
		}
		
		ListNode* newNode = new ListNode(val);

		//插入节点
		//注意：这里的顺序不能颠倒，因为我们现在知道cur是index的前一个节点
		//而我们要插入新节点的 next 指针指向 cur->next
		//如果我们先将cur->next赋值给newNode->next，那么cur->next就会指向newNode
		//这样就会丢失cur->next的指向
		newNode->next = cur->next;
		cur->next = newNode;
		size++;
	}
	void deleteAtIndex(int index)
	{
		if (index < 0 || index >= size) return;
		
		//找到index的前一个节点
		ListNode* cur = dummyHead;
		while (index)
		{
			cur = cur->next;
			index--;
		}
		cur->next = cur->next->next;
		size--;
	}

private:
	ListNode* dummyHead;
public:
	int size;
};