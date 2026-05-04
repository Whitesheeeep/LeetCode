#include <iostream>
#include <vector>

using namespace std;

class Solution {
public:
	void backTracking(const vector<int>& nums, vector<vector<int>>& res, vector<int>& path, vector<bool>& used){
		if (path.size() == nums.size())
		{
			res.push_back(path);
			return;
		}

		for (int i = 0; i < nums.size(); i++) {
			if (used[i]) continue;

			used[i] = true;
			path.push_back(nums[i]);
			backTracking(nums, res, path, used);
			used[i] = false;
			path.pop_back();
		}
	}

    vector<vector<int>> permute(vector<int>& nums) {
        vector<vector<int>> res;
		vector<int> path;
		vector<bool> used(nums.size(), false);

		backTracking(nums, res, path, used);
		return res;
    }
};

int main()
{
	Solution* sln = new Solution();

	int n,k;
	cin >> n;
	vector<int> nums;
	while (n--) {
		cin >> k;
		nums.push_back(k);
	}

	auto res = sln->permute(nums);

	for (auto vec : res) {
		for (int a : vec) {
			cout << a << " ";
		}
		cout << endl;
	}
}
