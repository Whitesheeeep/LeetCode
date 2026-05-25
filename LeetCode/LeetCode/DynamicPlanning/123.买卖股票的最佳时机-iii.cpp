#include <algorithm>
#include <climits>
#include <iostream>
#include <vector>

using namespace std;

// 单只
int maxProfit(const vector<int> &nums) {
    // 状态分析：
    // 1. 第一次交易的持有状态：0
    // 1.1 前一天的持有，
    // 1.2 当天买入
    // 2. 第一次交易的未持有状态
    // 2.1 前一天的持有卖出
    // 2.2 前一天的未持有状态维持
    // 第二次交易和第一次差不多
    vector<vector<int>> dp(nums.size(), vector<int>(5, 0));
    // 未进行任何交易
    dp[0][0] = 0;
    // 第一次交易持有
    dp[0][1] = -nums[0];
    // 第一次交易不持有
    dp[0][2] = 0;
    // 第二次交易持有
    dp[0][3] = -nums[0];
    // 第二次交易不持有
    dp[0][4] = 0;

    for (int i = 1; i < nums.size(); i++) {
        dp[i][1] = max(dp[i-1][1], dp[i-1][0] - nums[i]);
        dp[i][2] = max(dp[i-1][2], dp[i-1][1] + nums[i]);
        dp[i][3] = max(dp[i-1][3], dp[i-1][2] - nums[i]);
        dp[i][4] = max(dp[i-1][4], dp[i-1][3] + nums[i]);
    }

    return dp[nums.size() - 1][4];
}

int testCount = 0;
void test(vector<int> nums) {
    cout << "test" << testCount << endl;
    cout << "res: " << endl;
    cout << maxProfit(nums) << endl;
    cout << "test" << testCount << " over." << endl;
    cout << endl;
    testCount++;
}

int main() {

    vector<int> test1{1, 2};
    test(test1);

    test(vector<int>{2, 1});
    test(vector<int>{3, 2, 4, 5});

    // int n;
    // cin >> n;
    // vector<int> nums(n, 0);
    // for (int i = 0; i < n; i++) {
    //     cin >> nums[i];
    // }
}
