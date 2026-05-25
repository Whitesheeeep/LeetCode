#include <iostream>
#include <stack>
#include <vector>

using namespace std;

template <typename T1>
void debugVec(vector<T1> vec)
{
    for (T1 a : vec) {
        cout << a << " ";
    }
    cout << endl;
}

int maxRectangle(vector<int>& heights)
{
    vector<int> leftMin(heights.size(), -1);
    vector<int> rightMin(heights.size(), -1);
    stack<int> stack_Left;
    stack<int> stack_right;
    stack_Left.push(heights.size() - 1);
    stack_right.push(0);

    for (int i = 1; i < heights.size(); i++) {
        while (!stack_right.empty() && heights[i] < heights[stack_right.top()]) {
            rightMin[stack_right.top()] = i;
            stack_right.pop();
        }
        stack_right.push(i);
    }

    debugVec(rightMin);

    for (int i = heights.size() - 2; i >= 0; i--) {
        while (!stack_Left.empty() && heights[i] < heights[stack_Left.top()]) {
            leftMin[stack_Left.top()] = i;
            stack_Left.pop();
        }
        stack_Left.push(i);
    }

    debugVec(leftMin);

    int maxRect = 0;
    for (int i = 0; i < heights.size(); i++) {
        int temp = 0;
        if (leftMin[i] == -1 && rightMin[i] == -1) {
            temp = heights[i] * heights.size();
        }
        else if (leftMin[i] == -1) {
            temp = heights[i] * rightMin[i];
        }
        else if (rightMin[i] == -1) {
            temp = heights[i] * (heights.size() - leftMin[i] - 1);
        }
        else {
            temp = heights[i] * (rightMin[i] - leftMin[i] - 1);
        }
        maxRect = max(maxRect, temp);
    }
    return maxRect;
}

int maxRectangle2(vector<int>& heights)
{
    heights.insert(heights.begin(), 0);
    heights.insert(heights.end(), 0);

    vector<int> maxLeft(heights.size(), 0);
    int res = 0;
    stack<int> monoSmallStack;
    monoSmallStack.push(0);

    for (int i = 1; i < heights.size(); i++) {
        if (heights[monoSmallStack.top()] < heights[i]) {
            monoSmallStack.push(i);
        }
        else if (heights[monoSmallStack.top()] == heights[i]) {
            continue;
        }
        else{
            while (!monoSmallStack.empty() && heights[monoSmallStack.top()] > heights[i]) {
                int mid = heights[monoSmallStack.top()];
                monoSmallStack.pop();
                if (!monoSmallStack.empty()) {
                    int left = monoSmallStack.top(), right = i;
                    res = max(res, mid *(right - left - 1));
                }
            }
            monoSmallStack.push(i);
        }
        
    }

    return res;
}

void test(vector<int> nums)
{
    cout << maxRectangle2(nums) << endl;
    cout << "=========================" << endl;
    cout << endl;
}


int main(){
    test(vector<int>{1,2,3});
    test(vector<int>{3,2,1});
    test(vector<int>{1,2,3,2,1});
}
