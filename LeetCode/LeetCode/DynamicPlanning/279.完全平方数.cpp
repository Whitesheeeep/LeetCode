#include <climits>
#include <iostream>
#include <vector>

using namespace std;

int minPfCount(int n){
    vector<int> dp(n  +1 , INT_MAX);
    // dp[i] 表示为 i 时的最小完全平方数数量
    // dp[i] = min(dp[i-j] + dp[j], dp[i])
    dp[0] = 0;
    dp[1] = 1;
    for (int i = 2; i <= n; i++) {
        for (int j = 1; j * j <= i; j++) {
            dp[i] = min(dp[i - j*j]+1, dp[i]);
            // cout << "i, j: " << i << " " << j << endl;
            // cout << dp[i] << endl;
        }
    }
    return dp[n];
}

int main() {
    int n;
    cin >> n;

    cout << minPfCount(n) << endl;
}
