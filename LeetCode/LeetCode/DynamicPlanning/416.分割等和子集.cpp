#include <algorithm>
#include <iostream>
#include <numeric>
#include <vector>

using namespace std;

bool canPartition(vector<int>& nums){
    // 背包大小
    int sum = accumulate(nums.begin(), nums.end(), 0);
    if (sum%2 == 1) {
        return false;
    }

    // 初始化
    vector<int> dp(sum/2 + 1, 0);
    for (int i = nums[0]; i <= sum/2; i++) {
        dp[i] = nums[0];
    }

    for (int i = 1; i < nums.size(); i++) {
        for (int j = sum/2; j >= nums[i]; j--) {
            dp[j] = max(dp[j], dp[j - nums[i]] + nums[i]);
        }
    }

    return dp[sum/2] == sum/2;
}

int main(){
    // 测试
    vector<int> test1{1,1};
    cout << canPartition(test1) << endl;


    int n,k;
    cin >> n;
    vector<int> nums;
    while (n--) {
        cin >> k;
        nums.push_back(k);
    }

    cout << canPartition(nums);
}
