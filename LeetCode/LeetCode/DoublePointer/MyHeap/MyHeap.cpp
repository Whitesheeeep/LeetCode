#include <climits>
#include "MyHeap.H"

MyHeap::MyHeap(int maxSize)
{
    size = 0;
    capacity = maxSize;
    nums[0] = INT_MAX;
}

void MyHeap::push(int x)
{
    int i;
    if (size == capacity)
    {
        cout << "最大堆已满" << endl;
        return;
    }

    i = ++size; // 指向堆的最后一个位置
    for(; nums[i/2] < x; i/=2)
        nums[i] = nums[i/2];
    nums[i] = x;
}

int MyHeap::top()
{
    return nums[1];
}

int MyHeap::pop()
{
    if(size == 0)
    {
        cout << "最大堆已经空" << endl;
        return;
    }

    int res = nums[1];
    int temp = nums[size--];
    int parent = 1, chlid = parent * 2;
    for(parent = 1; parent * 2 <= size; i *= 2)
    {
        int child = parent * 2;
        if (child < size && nums[child] < nums[child+1])
            child++;
        if (temp >= nums[child]) break;
        else
            nums[i] = nums[child];
    }
}

int MyHeap::find(int x)
{
    return 0;
}

void MyHeap::remove(int x)
{
}

void MyHeap::print()
{
}
