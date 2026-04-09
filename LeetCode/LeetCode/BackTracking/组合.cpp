#include <iostream>
#include <vector>

using namespace std;

vector<vector<int>> res;

void backTracking(int n, int k, int start, vector<int>& path)
{
	if (path.size() == k)
		res.push_back(path);

	for (int i = start; i <= n - (k - path.size()); i++)
	{
		path.push_back(i);
		backTracking(n, k, i + 1, path);
		path.pop_back();
	}
}

int main()
{
	int n,k;

	cin >> n >> k;
	vector<int> path;
	backTracking(n, k, 1, path);

	// 输出
	for (auto r : res) {
		for (auto a : r) {
			cout << a << " ";
		}
		cout << endl;
	}
}
