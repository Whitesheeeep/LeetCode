#ifndef MYLINKEDLIST_H
#define MYLINKEDLIST_H

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

    MyLinkedList();
    int get(int index);
    void addAtHead(int val);
    void addAtTail(int val);
    void addAtIndex(int index, int val);
    void deleteAtIndex(int index);

private:
    ListNode* dummyHead;
public:
    int size;
};

#endif // MYLINKEDLIST_H
