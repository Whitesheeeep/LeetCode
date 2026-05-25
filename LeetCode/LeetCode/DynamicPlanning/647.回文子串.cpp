#include <algorithm>
#include <climits>
#include <iostream>
#include <vector>

using namespace std;

int huiWenCount(string s){
    if (s.empty()) {
        return 0;
    }
    // dp[i] 表示以 s[i] 结尾的回文串
    int res = 1;
    vector<int> dp(s.size(), 0);
    dp[0] = 1;

    for (int i = 1; i < s.size(); i++) {
        
    }
}

int testCount = 1;
void test(string s){
    cout << "test start " << testCount <<endl;
    cout << "res : " << endl;
    cout << huiWenCount(s) << endl;
    cout << "test end " << testCount <<endl << endl;
    testCount++;
}

int main(){
    
}
