#include <algorithm>
#include <iostream>
#include <vector>

using namespace	 std;

int maxValue(vector<int>& weight, vector<int>& values, int n, int v){
	vector<vector<int>> dp(n, vector<int>(v + 1, 0));
	for (int i = weight[0]; i <= v; i++) {
		dp[0][i] = (i / weight[0]) * values[i];
	}

	for (int i = 0; i < n; i++) {
		for (int j = 1; j <= v; j++) {
			if (j < weight[i]) {
				dp[i][j] = dp[i-1][j];
			}
			else {
				dp[i][j] = max(dp[i-1][j], dp[i][j - weight[i]] + values[i]);
			}
		}
	}
	return dp[n- 1][v];
}


int main(){
	int n = 1, v = 1;
	vector<int> weight{1};
	vector<int> values{1};
	cout << maxValue(weight, values, n, v);

	// int n, v, wi, vi;
	// vector<int> weight;
	// vector<int> values;

	// cin >> n >> v;
	// for (int i = 0; i < n; i++) {
	// 	cin >> wi >> vi;
	// 	weight.push_back(wi);
	// 	values.push_back(vi);
	// }

	

	// cout << maxValue(weight, values, n, v) << endl;
}
