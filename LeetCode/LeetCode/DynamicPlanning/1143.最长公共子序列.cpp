#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

int maxCommonLen(string text1, string text2){

    // dp[i][j] 表示 text[i-1] 和 text[j-1] 公共子序列的最长公共子序列长度
    vector<vector<int>> dp(text1.size() + 1, vector<int>(text2.size() + 1, 0));

    int result = 0;
    for (int i = 1; i <= text1.size(); i++) {
        for (int j = 1; j < text2.size(); j++) {
            if (text1[i-1] == text2[j-1]) {
                dp[i][j] = dp[i-1][j-1] + 1;
            }
            
            result = max(result, dp[i][j]);
        }
    }
    return result;
}


int testCount = 1;
void test(string text1, string text2){
    cout << "testCount: " << testCount << endl;
    cout << "res" << endl;

    cout << "testCount over: " << testCount << endl << endl;
}


int main(){

}
