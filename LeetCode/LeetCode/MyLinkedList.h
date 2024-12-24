#pragma once
#ifndef MYLINKEDLIST_H
#define MYLINKEDLIST_H

class MyLinkedList
{
public:
    struct ListNode;

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
