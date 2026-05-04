#include <iostream>
#include <unordered_set>
#include <vector>

using namespace std;

class Solution {
public:
	void backTracking(const vector<int>& nums, vector<vector<int>>& res, vector<int>& path, vector<bool>& used, int startIndex)
	{
		if (path.size() > 1)
			res.push_back(path);

		unordered_set<int> usedNum;
		for (int i = startIndex; i < nums.size(); i++)
		{
			if (usedNum.find(nums[i]) != usedNum.end()) continue;
			usedNum.insert(nums[i]);
			if (i > startIndex && nums[i] == nums[i-1] && used[i - 1] == false) continue;
			if (!path.empty() && path.back() > nums[i]) continue;
			path.push_back(nums[i]);
			used[i] = true;
			backTracking(nums, res, path, used, i + 1);	
			path.pop_back();
			used[i] = false;
		}
	}

    vector<vector<int>> findSubsequences(vector<int>& nums) {
        vector<vector<int>> res;
		vector<int> path;
		vector<bool> used(nums.size(), false);
		backTracking(nums, res, path, used, 0);
		return res;
    }
};

int main()
{
	Solution* sln = new Solution();

	int n, k;
	cin >> n;
	vector<int> nums;

	while (n--) {
		cin >> k;
		nums.push_back(k);
	}

	auto res = sln->findSubsequences(nums);

	// 输出
	for (auto vec : res) {
		for (auto item : vec) {
			cout << item << " ";
		}
		cout << endl;
	}
}
