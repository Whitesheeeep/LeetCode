#include <stack>
#include <queue>

using namespace std;

class MyStack
{
private:
	queue<int> queue;

public:
    MyStack() {

    }

    void push(int x) {
		queue.push(x);
    }

    int pop() {
        for (int i = 0; i < queue.size() - 1; i++)
        {
            int temp = queue.front();
			queue.pop();
			queue.push(temp);
        }
		int temp = queue.front();
		queue.pop();
		return temp;
    }

    int top() {
        int temp = this->pop();
		queue.push(temp);
		return temp;
    }

    bool empty() {
        return queue.empty();
    }
};