#include <algorithm>
#include <climits>
#include <iostream>
#include <vector>

using namespace std;

int minCoinsNeeded(vector<int>& coins, int amount){
    vector<int> dp(amount + 1, INT_MAX);
    dp[0] = 0;

    for (int j = 0; j <= amount; j++) {
        for (int i = 0; i < coins.size(); i++) {
            if (j >= coins[i] && dp[j - coins[i]] != INT_MAX) dp[j] = min(dp[j], 1 + dp[j - coins[i]]);
        }
        cout << "turn" << j << endl;
        for (int k = 0; k <= amount; k++) {
            cout << dp[k] << " ";
        }
        cout << endl;
    }

    return dp[amount] == INT_MAX ? -1 : dp[amount];
}

int main(){
    vector<int> test1{1,2, 3};
    int t1 = 3;
    int res1 = minCoinsNeeded(test1, t1);
    cout << res1 << " " << (res1 == 1) << endl;


    int n, k, amount;
    cin >> n;
    vector<int> coins;
    while (n--) {
        cin >> k;
        coins.push_back(k);

    }
    cin >> amount;

    cout  << minCoinsNeeded(coins, amount) << endl;
}
