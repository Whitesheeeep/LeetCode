#include <iostream>
#include <stack>
#include <vector>

using namespace std;

vector<int> greaterElement(vector<int>& nums){
    if (nums.size() < 1) {
        return {-1};
    }
    vector<int> res(nums.size(), -1);
    stack<int> monoLowOfIndex_stack;
    monoLowOfIndex_stack.push(0);

    for (int i = 1; i < nums.size(); i++) {
        if(!monoLowOfIndex_stack.empty()&&i == monoLowOfIndex_stack.top()) break;
        if (nums[i] <= nums[monoLowOfIndex_stack.top()]) {
            if(res[i] == -1) monoLowOfIndex_stack.push(i);
        }
        else {
            while (!monoLowOfIndex_stack.empty() && nums[i] > nums[monoLowOfIndex_stack.top()]) {
                res[monoLowOfIndex_stack.top()] = nums[i];
                cout << "i " << i << " stackIndex " << monoLowOfIndex_stack.top() << endl;
                monoLowOfIndex_stack.pop();
            }
            
            if (!monoLowOfIndex_stack.empty() && monoLowOfIndex_stack.top() == i) {
                return res;
            }
            if(res[i] == -1) monoLowOfIndex_stack.push(i);
            if (!monoLowOfIndex_stack.empty()) {
                cout << "i " <<i << " " << monoLowOfIndex_stack.top() << endl;
            }
        }

        if (!monoLowOfIndex_stack.empty() && i == nums.size() - 1) {
            i = -1;
        }
    }
    return res;
}


int  testCount = 1;
void test(vector<int> nums){
    cout << "Test Start: " << testCount << endl;
    vector<int> res = greaterElement(nums);
    for (int i = 0; i < res.size(); i++) {
        cout << res[i] << " ";
    }
    cout << endl;
    cout << "Test End: " << testCount << endl << endl;;
}

int main(){
    test(vector<int>{1,1,1});
}
