#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

int maxProfit(vector<int>&  prices){
    // 几种状态：
    // 未进行交易，持有，卖出，冷冻期
    vector<vector<int>> dp(prices.size(), vector<int>(4,0));
    dp[0][0] = 0;
    dp[0][1] =-prices[0];
    dp[0][2] = 0;
    dp[0][3] = 0;

    for (int i = 1; i < prices.size(); i++) {
        dp[i][0] = 0;
        dp[i][1] = max(dp[i-1][1], max(dp[i][0] - prices[i], dp[i-1][3]- prices[i]));
        dp[i][2] = max(dp[i-1][2], dp[i-1][1] + prices[i]);
        dp[i][3] = max(dp[i-1][3], dp[i-1][2]);
    }
    return max(dp[prices.size() - 1][2], dp[prices.size() - 1][3]);
}

int testCount = 0;
void test(vector<int> nums){
    cout << "testCount " << testCount << endl;
    cout << "res: "  << endl;
    cout << maxProfit(nums) << endl;

    cout << "testCount over: " << testCount << endl;
}


int main(){
    
    test(vector<int>{1,2});
    test(vector<int>{1,4,2,3});
    
    // int n;
    // cin >> n;
    // vector<int> prices(n, 0);
    // for (int i = 0; i < n; i++) {
    //     cin >> prices[i];
    // }    

}
