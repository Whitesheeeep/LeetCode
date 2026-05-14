#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

int maxValue(vector<vector<int>>& weight, int bag){
	int itemsCount = weight[0].size();
	// res[i][j] 表示 从 0 - i 物品中拿取所能获取的最大价值，背包大小为 j
	vector<vector<int>> res(itemsCount  + 1, vector<int>(bag + 1, 0));
	
	for (int i = 0; i <= bag; i++) {
		if (weight[0][0] <= i) {
			res[0][i] = weight[1][0];
		}
	}

	for (int i = 1; i <= itemsCount; i++) {
		for (int j = 1; j <= bag; j++) {
			res[i][j] = max(res[i-1][j], res[i - j][j] + weight[1][i]);
		}
	}

	for (int i = 0; i <= itemsCount; i++) {
		for (int j = 0;  j <= bag; j++) {
			cout << res[i][j] << endl;
		}
	}
	return res[itemsCount][bag];
}

int main(){
	int m,n;
	cin >> m >> n;
	// 第一行：所占空间
	// 第二行：最大价值
	vector<vector<int>> weight(2,vector<int>(m));

	int k;
	for (int i = 0; i < 2; i++) {
		for (int j = 0; j < m; j++) {
			cin >> k;
			weight[i][j] = k;
		}
	}

	cout << maxValue(weight, n) << endl;
}
