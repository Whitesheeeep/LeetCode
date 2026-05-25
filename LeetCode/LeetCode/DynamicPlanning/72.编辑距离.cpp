#include <algorithm>
#include <climits>
#include <iostream>
#include <vector>

using namespace std;

int minDeleteSteps(string word1, string word2){
    vector<vector<int>> dp(word1.size() +  1, vector<int>(word2.size() + 1, INT_MAX));

    // dp[i][j] 表示 word1 0-i-1 与 word2 0-i-1 相同所需要的最小步数
    // if (word1[i-1] == word2[j-1]) 不需要删除
    // else 
    for (int i = 0; i <= word1.size(); i++) {
        dp[i][0] = i;
    }
    for (int i = 0; i <= word2.size(); i++) {
        dp[0][i] = i;
    }
    
    for (int i = 1; i <= word1.size(); i++) {
        for (int j = 1; j <= word2.size(); j++) {
            if (word1[i-1] == word2[j-1]) {
                dp[i][j] = dp[i-1][j-1];
            }
            else {
                dp[i][j] = min(dp[i-1][j] , min(dp[i][j-1], dp[i-1][j-1])) + 1;
            }
        }
    }
    return dp[word1.size()][word2.size()];
}

int testCount = 1;
void test(string word1, string word2){
    cout << "test start " << testCount <<endl;
    cout << "res : " << endl;
    cout << minDeleteSteps(word1, word2) << endl;
    cout << "test end " << testCount <<endl << endl;
    testCount++;
}

int main(){
    test("a", "a"); //0
    test("a", "b"); // 2
    test("abcd", "ab"); // 2
}
