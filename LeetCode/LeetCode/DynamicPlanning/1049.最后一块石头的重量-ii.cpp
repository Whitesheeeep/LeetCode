#include <iostream>
#include <vector>

using namespace std;

int minStoneWeight(vector<int> &stones) {
    if (stones.size() == 1) {
        return stones[0];
    }

    // dp[i][j] 表示 0 - i 个 stone 粉碎 j 次后最小可能重量
    // dp[i][j] = min(dp[i-1][j], dp[i - 1][j - 1])
}

int main() {

    vector<int> test1{2,1};
    cout << (minStoneWeight(test1) == 1) << endl;

    while (true) 
    {
        int n, k;
        cin >> n;
        vector<int> stones;
        while (n--) {
            cin >> k;
            stones.push_back(k);
        }

        cout << minStoneWeight(stones) << endl;
    }
}
