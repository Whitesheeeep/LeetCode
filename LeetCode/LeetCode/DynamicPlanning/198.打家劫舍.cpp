#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

int maxStoleMoney(const vector<int>& nums){
    // 类似于 01 背包
    // dp[i] 表示：到第 i 家时能偷到的最大金额
    vector<int> dp(nums.size(), 0);
    
    dp[0] = nums[0];

    for (int i = 1; i < nums.size(); i++) {
        if (i >= 2) dp[i] = max(dp[i-1], dp[i-2] + nums[i]);
        else dp[i] = max(dp[i-1], nums[i]);
    }

    return dp[nums.size()-1];
}


int main(){
    vector<int> test1{2,2,2};
    cout << maxStoleMoney(test1) << endl;

    // int n;
    // vector<int> nums(n, 0);
    // for (int i = 0; i < n; i++) {
    //     cin >> nums[i];
    // }

    // cout  << maxStoleMoney(nums) << endl;
}
