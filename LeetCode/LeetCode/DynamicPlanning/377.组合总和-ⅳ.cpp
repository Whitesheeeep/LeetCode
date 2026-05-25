#include <iostream>
#include <vector>

using namespace std;

int partitionCount(vector<int> &nums, int target) {
    int n = nums.size();
    vector<vector<int>> dp(n, vector<int>(target + 1, 0));

    for (int i = nums[0]; i <= target; i++) {
        if (i % nums[0] == 0) {
            dp[0][i] = 1;
        }
    }
    for (int i = 0; i < nums.size(); i++) {
        dp[i][0] = 1;
    }

    for (int i = 0; i <= target; i++) {
        cout << dp[0][i] << " ";
    }
    cout << endl;

    for (int i = 1; i < nums.size(); i++) {
        for (int j = 1; j <= target; j++) {
            if (j < nums[i]) {
                dp[i][j] = dp[i - 1][j];
            } else {
                dp[i][j] = dp[i - 1][j] + dp[i][j - nums[i]];
            }
            cout << "dp" << nums[i] << i << " " << j << endl;
            cout << dp[i][j] << endl;
        }
    }

    return dp[n - 1][target];
}

//  回溯超时
int res = 0;

void backTracking(vector<int> &nums, int target,  int sum) {
    if (sum == target) {
        res++;
        return;
    }
    else if (sum > target) {
        return;
    }

    for (int i = 0; i < nums.size(); i++) {
        backTracking(nums, target, sum + nums[i]);
    }
}

int main() {
    vector<int> test1{6};
    int t1 = 4;
    // int res1 = partitionCount(test1, t1);
    // cout << res1 << " " << (res1 == 0) << endl;

    vector<vector<int>> res{};
    vector<int> path{};
    backTracking(test1, t1, 0);
    int a=res.size();
    cout << res.empty() << " " << a << " "<< (a  == 0)<< endl;

    // int n, k, target;
    // cin >> n;
    // vector<int> nums;
    // while (n--) {
    //     cin >> k;
    //     nums.push_back(k);
    // }
}
