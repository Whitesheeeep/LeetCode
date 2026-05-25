#include <algorithm>
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

vector<int> sumVec(vector<int>& nums)
{
    vector<int> res(nums.size(), 0);
    int sum = 0;
    for (int i = 0; i < nums.size(); i++) {
        sum += nums[i];
        res[i] = sum;
    }
    return res;
}

int rain(vector<int>& height){
    if (height.size() < 1) {
        return 0;
    }
    
    stack<int> waterStack;
    waterStack.push(0);
    int water = 0;

    for (int i = 1; i < height.size(); i++) {
        if (height[i] < height[waterStack.top()]) {
            waterStack.push(i);
        }
        else if (height[i] == height[waterStack.top()]) {
            // 相等则更新，保持宽度更新
            waterStack.pop();
            waterStack.push(i);
        }
        else {
            while (!waterStack.empty() && height[i] > height[waterStack.top()]) {
                int mid = height[waterStack.top()];
                waterStack.pop();
                if (!waterStack.empty()) {
                    int h = min(height[i], height[waterStack.top()]) - mid;
                    int w = i - waterStack.top() - 1;
                    water += h * w;
                }
                
            }
            waterStack.push(i);
        }
    }
    return water;
}

int testCount = 1;
void test(vector<int> height){
    cout << "Test Start: " << testCount << endl;
    cout << rain(height) << endl;
    cout << "Test End: " << testCount << endl << endl;
    testCount++;
}

int main(){
    test(vector<int>{0,1,0,2,1,0,1,3,2,1,2,1}); // 1
    test(vector<int>{1,2,1}); // 1
}
