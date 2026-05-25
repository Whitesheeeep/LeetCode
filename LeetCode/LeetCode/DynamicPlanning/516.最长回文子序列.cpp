#include <iostream>
#include <vector>

using namespace std;

int maxHuiWenSequence(string s) {
    // dp[i][j] 表示 i 到 j 最长回文子序列大小
    vector<vector<int>> dp(s.size(), vector<int>(s.size(), 0));

    int res = 0;
    for (int i = s.size() - 1; i >= 0; i--) {
        for (int j = i; j < s.size(); j++) {
            if (s[i] == s[j]) {
                if (j - i <= 1) {
                    dp[i][j] = j - i + 1;
                } else {
                    dp[i][j] = dp[i + 1][j - 1] + 2;
                }
            } else {
                dp[i][j] = max(dp[i+1][j],max(dp[i+1][j-1], dp[i][j-1]));
            }
            res = max(res, dp[i][j]);
        }
    }

    // cout << "dp " << endl;
    // for (int i = 0; i < s.size(); i++) {
    //     for (int j = 0; j < s.size(); j++) {
    //         cout << dp[i][j] << " ";
    //         if (j == s.size()-1) {
    //             cout << endl;
    //         }
    //     }
    // }
    return res;
}

int testCount = 1;
void test(string s) {
    cout << "Test Start " << testCount << endl;
    cout << maxHuiWenSequence(s) << endl;
    cout << "Test End " << testCount << endl << endl;
    testCount++;
}
// 
int main() {
    // test("a");
    // test("aaa");
    test("aaaba");
    // test("a");

}
