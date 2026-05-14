
#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;


int main(){
	int m,n;
	cin >> m >> n;
	// 第一行：所占空间
	// 第二行：最大价值
	vector<int> weight(m, 0);
	vector<int> values(m, 0);

	int k;
	for (int i = 0; i < 2; i++) {
		for (int j = 0; j < m; j++) {
			cin >> k;
			if(i == 0) weight[j] = k;
			else values[j] = k;
		}
	}

	vector<vector<int>> dp(m, vector<int>(n + 1, 0));

	for (int i = weight[0]; i <= n; i++) {
		dp[0][i] = values[0];
	}

	for (int i = 1; i < m; i++) {
		for (int j = 1; j <= n; j++) {
			if (j < weight[i]) {
				dp[i][j] = dp[i-1][j];
			}
			else {
			dp[i][j] = max(dp[i-1][j], dp[i- 1][j - weight[i]] + values[i]);
			}
		}
	}
	cout << dp[m - 1][n];
}
