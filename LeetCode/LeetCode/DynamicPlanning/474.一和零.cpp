#include <algorithm>
#include <iostream>
#include <string>
#include <vector>

using namespace std;

struct countFor01
{
public:
    int zero, one;
    countFor01(): zero(0), one(0){}
};

int maxSetLength(vector<string>& strs, int m, int n){
    vector<countFor01> o_1_count(strs.size(), countFor01());

    for (int i = 0; i < strs.size(); i++) {
        for (char a : strs[i]) {
            if (a == '1') {
                o_1_count[i].one++;
            }
            else
                o_1_count[i].zero++;
        }
    }
    // cout << "01 count over" << endl;
    // for (int i= 0; i < o_1_count.size(); i++) {
    //     cout << o_1_count[i].zero << " "  << o_1_count[i].one << endl;
    // }

    vector<vector<vector<int>>> dp(strs.size(), vector<vector<int>>(m + 1, vector<int>(n + 1, 0)));

    // dp[i][j][k] 表示 0 - i 的 strs 满足 j 个 0， k 个 1 的最长子集长度
    // dp[i][j][k] = max(dp[i - 1][j][k], dp[i][j - o_1_count[i].zero][k - o_1_count[i].one]
    // 初始化
    if (o_1_count[0].one <= n && o_1_count[0].zero <= m) {
        dp[0][o_1_count[0].zero][o_1_count[0].one] = 1;
    }
    // cout << dp[0][o_1_count[0].zero][o_1_count[0].one] << endl;

    for (int i= 1; i < strs.size(); i++) {
        for (int j = 1; j <= m; j++) {
            for (int k = 1; k <= n; k++) {
                // cout << i << j << k << endl;
                if (o_1_count[i].one > k || o_1_count[i].zero > j) {
                    dp[i][j][k] = dp[i - 1][j][k];
                }
                else {
                    dp[i][j][k] = max(dp[i - 1][j][k], dp[i - 1][j - o_1_count[i].zero][k - o_1_count[i].one] + 1);
                }
            }
        }
    }

    // cout << dp[strs.size() - 1][m][n] << endl;
    return dp[strs.size() - 1][m][n];
}

int main(){
    vector<string> test1{"111", "000", "111000", "11000"};
    int m1 = 3, n1 = 3;
    cout << (maxSetLength(test1, m1, n1) == 2) << endl;
    
    int strNum, m, n;
    string str;
    cin >> strNum;
    vector<string> strs;
    while (strNum--) {
        cin >> str;
        strs.push_back(str);
    }

    cin >> m >> n;

}
