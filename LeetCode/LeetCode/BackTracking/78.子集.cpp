/*
 * @lc app=leetcode.cn id=78 lang=cpp
 *
 * [78] 子集
 */
#include <iostream>
#include <vector>

using namespace std;

vector<vector<int>> res;
// @lc code=start
class Solution {
public:
  void backTracking(int k, vector<int> &path, int startIndex,
                    const vector<int> &nums) {
    if (path.size() == k) {
      res.push_back(path);
      return;
    }

    for (int i = startIndex; i < nums.size(); i++) {
      path.push_back(nums[i]);
      backTracking(k, path, i + 1, nums);
      path.pop_back();
    }
  }

  vector<vector<int>> subsets(vector<int> &nums) {}
};

int main() {
  Solution *sln = new Solution();
  while (true) {
    int n, a;
    cin >> n;
    vector<int> nums;
    while (n--) {
      cin >> a;
      nums.push_back(a);
    }

    for (int k = 0; k <= nums.size(); k++) {
      vector<int> path;
      sln->backTracking(k, path, 0, nums);
    }

    for (auto p : res) {
        for (auto b : p) {
            cout << b << " ";
        }
        cout << endl;
    }
  }
}
// @lc code=end
