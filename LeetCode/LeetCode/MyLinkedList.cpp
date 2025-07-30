// #include "MyLinkedList.h"
//
// class MyLinkedList
// {
// public:
// 	struct ListNode
// 	{
// 		int val;
// 		ListNode* next;
// 		ListNode() : val(0), next(nullptr) {}
// 		ListNode(int x) : val(x), next(nullptr) {}
// 		ListNode(int x, ListNode* next) : val(x), next(next) {}
// 	};
//
// 	MyLinkedList()
// 	{
// 		dummyHead = new ListNode(0);
// 		size = 0;
// 	}
//
// 	int get(int index)
// 	{
// 		if (index < 0 || index >= size) return -1;
// 		
// 		//���ҵ�index��ǰһ���ڵ�
// 		ListNode* cur = dummyHead;
// 		while (index)
// 		{
// 			cur = cur->next;
// 			index--;
// 		}
//
// 		return cur->next->val;
// 	}
//
// 	void addAtHead(int val)
// 	{
// 		addAtIndex(0, val);
// 	}
// 	void addAtTail(int val)
// 	{
// 		addAtIndex(size, val);
// 	}
//
// 	void addAtIndex(int index, int val)
// 	{
// 		if (index < 0 || index > size) return;
// 		ListNode* cur = dummyHead;
// 		
// 		//�ҵ�index��ǰһ���ڵ�
// 		while(index)
// 		{
// 			cur = cur->next;
// 			index--;
// 		}
// 		
// 		ListNode* newNode = new ListNode(val);
//
// 		//����ڵ�
// 		//ע�⣺�����˳���ܵߵ�����Ϊ��������֪��cur��index��ǰһ���ڵ�
// 		//������Ҫ�����½ڵ�� next ָ��ָ�� cur->next
// 		//��������Ƚ�cur->next��ֵ��newNode->next����ôcur->next�ͻ�ָ��newNode
// 		//�����ͻᶪʧcur->next��ָ��
// 		newNode->next = cur->next;
// 		cur->next = newNode;
// 		size++;
// 	}
// 	void deleteAtIndex(int index)
// 	{
// 		if (index < 0 || index >= size) return;
// 		
// 		//�ҵ�index��ǰһ���ڵ�
// 		ListNode* cur = dummyHead;
// 		while (index)
// 		{
// 			cur = cur->next;
// 			index--;
// 		}
// 		cur->next = cur->next->next;
// 		size--;
// 	}
//
// private:
// 	ListNode* dummyHead;
// public:
// 	int size;
// };
//
