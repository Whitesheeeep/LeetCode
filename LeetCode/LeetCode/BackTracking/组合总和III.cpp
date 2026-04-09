#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

void backTracking(vector<int> &path, vector<vector<int>> &res, int target,
                  int startIndex, int curSum, const vector<int>& candidates) {
  if (curSum > target) return;
  if (curSum == target) {
	res.push_back(path);
	return;
  }

  for (int i = startIndex; i < candidates.size(); i++) {
  if (candidates[i] > target)
	if (i > startIndex && candidates[i] == candidates[i-1]) continue;
	path.push_back(candidates[i]);
	backTracking(path, res, target, i + 1, curSum + candidates[i], candidates);
	path.pop_back();
  }
}

int main() {
  int n, s, target;
  cin >> n;
  vector<int> candidates;
  for (int i = 0; i < n; i++) {
    cin >> s;
    candidates.push_back(s);
  }
  cin >> target;

  sort(candidates.begin(), candidates.end());

  vector<vector<int>> res;
  vector<int> path;
  backTracking(path, res, target, 0, 0, candidates);
  
  // 输出
  for (auto vec : res) {
	for (auto item : vec) {
		cout << item << " ";
	}
	cout << endl;
  }
}
