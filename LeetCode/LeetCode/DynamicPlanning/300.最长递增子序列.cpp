#include <algorithm>
#include <iostream>
#include <queue>
#include <vector>

using namespace std;



int maxLengthUp(vector<int>& nums){
    // dp[i] 表示到索引 i 的最大递增子序列
    vector<int> dp(nums.size(), 0);
    dp[0] = 1; 
    int bigIndex = 0;
    int big = 1;

    for (int i = 1; i < nums.size(); i++) {
        // 找到最大的 dp[i] 进行比较
        if (nums[i] > nums[bigIndex]) {
            dp[i] = big + 1;
            big = dp[i];
            bigIndex = i;
        }
        else {
            dp[i] = dp[bigIndex];
        }
        cout << nums[i] << " " << dp[i] << endl;
    }
    return dp[nums.size() - 1];
}


int testCount = 1;
void test(vector<int> testVec){
    cout << "test " << testCount << endl;
    cout << "res: " << endl;
    cout << maxLengthUp(testVec) << endl;
    cout << "test over" << testCount << endl;
    cout << endl;
}


int main(){
    test(vector<int>{1,2}); // 2
    test(vector<int>{2,1}); // 1
    test(vector<int>{4,10,4,3,8,9}); // 3
}
