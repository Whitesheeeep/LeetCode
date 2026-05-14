#include <cmath>
#include <iostream>
#include <numeric>
#include <vector>

using namespace std;

int getResultMethods(vector<int>& nums, int target){
    int sum = accumulate(nums.begin(), nums.end(), 0);
    if ((sum - target) % 2 == 1) {
        return 0;
    }
    int bag = (sum + target) / 2;

    // dp[i][j] 表示从 0 - i , 背包为 j 时所能得到种数
    vector<vector<int>> dp(nums.size(), vector<int>(bag + 1, 0));
    for (int i = 0; i < nums.size(); i++) {
        for (int j = 0; j <= bag ; j++) {
            
        }
    }


    int zeroCount = 0;
    for (int i = 0; i < nums.size(); i++) {
        for (int j = bag; j >= nums[i]; j--) {
            if (j == 0 && nums[i] == 0) {
                dp[i][0] == (int) pow(2, zeroCount);
                zeroCount++;
            }
            else
                dp[i][j] = dp[i-1][j] + dp[i-1][j - nums[i]];
        }
    }

    return dp[nums.size()][bag];
}

// 回溯

int main(){


    int n, k, target;
    cin >> n;
    vector<int> nums;
    while (n--) {
        cin >> k;
        nums.push_back(k);
    }

    cin >> target;
    cout << getResultMethods(nums, target) << endl;
}
