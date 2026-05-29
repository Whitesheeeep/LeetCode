#include <iostream>
#include <vector>

using namespace std;

int coinSumtoAmount(vector<int>& coins, int amount){


    // dp[i][j] 表示 0 - i 的 coin，凑到 j 的种类数
    vector<vector<int>> dp(coins.size(), vector<int>(amount + 1, 0));

    // 初始化
    for (int i = coins[0]; i <= amount; i++) {
        dp[0][i] = dp[0][i - coins[0]] + 1;
    }

    for (int i = 1; i < coins.size(); i++) {
        for (int j = 1; j <= amount; j++) {
            if (j < coins[i]) {
                dp[i][j] = dp[i-1][j];
            }
            else {
                dp[i][j] = dp[i - 1][j] + dp[i][j - coins[i]];
            }
        }
    }

    return dp[coins.size() - 1][amount];
}

int main(){

    // vector<int> test1{1,2};
    // int t1 = 1;
    // cout << (coinSumtoAmount(test1, t1) == 1) << endl;

    vector<int> test2{1,1};
    int t2 = 1;
    int res = coinSumtoAmount(test2, t2);
    cout << res << " " <<  (res == 2) << endl;

    vector<int> test3{1,2,1,2};
    int t3 = 3;
    cout << coinSumtoAmount(test3, t3) << endl;


    int n, k, amount;
    cin >> n;
    vector<int> coins;

    while (n--) {
        cin >> k;
        coins.push_back(k);
    }
}
