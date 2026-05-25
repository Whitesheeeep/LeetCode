#include <iostream>
#include <vector>

using namespace std;

int methods(int n, int m)
{
	// dp[i][j] 表示 爬到第 i 节
	vector<int> dp(n + 1, 0);
	dp[0] = 1;

	for (int i = 1; i <= n; i++) {
		for (int j = 1; j <= m; j++) {
			if(i >= j) dp[i] += dp[i - j];
		}
	}
	return dp[n];
}

int main(){
	while (true)
	{int n, m;
	cin >> n >> m;

	cout << methods(n, m);}
}
