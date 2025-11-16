#pragma once
#ifndef MYHEAP_H
#define MYHEAP_H

#include <vector>
using namespace std;
class MyHeap
{
private:
    vector<int> nums;
    int size;
    int capacity;
public:
    MyHeap(int maxSize);
    void push(int);
    int top();
    int pop();
    int find(int);
    void remove(int);
    void print();
};
#endif
