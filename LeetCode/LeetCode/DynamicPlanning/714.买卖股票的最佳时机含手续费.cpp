#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

int maxProfit(vector<int>&  prices, int fee){
    // 状态：未持有，持有
    vector<vector<int>> dp(prices.size(), vector<int>(3));
    dp[0][1] = 0;
    dp[0][2] = -prices[0];

    for (int i = 1; i < prices.size(); i++) {
        dp[i][1] = max(dp[i-1][1], dp[i-1][2] + prices[i] - fee);
        dp[i][2] = max(dp[i-1][2], dp[i-1][1] - prices[i]);
    }

    return dp[prices.size() - 1][1];
}

int testCount = 0;
void test(vector<int> nums, int fee){
    cout << "testCount " << testCount << endl;
    cout << "res: "  << endl;
    cout << maxProfit(nums, fee) << endl;
    cout << "testCount over: " << testCount << endl;
    cout << endl;
}


int main(){
    
    test(vector<int>{1,2}, 0);
    test(vector<int>{1,4,2,3},2);
    
    // int n;
    // cin >> n;
    // vector<int> prices(n, 0);
    // for (int i = 0; i < n; i++) {
    //     cin >> prices[i];
    // }    

}
