#include <unordered_set>

using namespace std;

class Solution {
public:
	vector<vector<int>> threeSum(vector<int>& nums) {
		vector<vector<int>> res;
		for (int i = 2; i < nums.size(); i++)
		{
			int left = 0, right = i - 1;
			while (left != right)
			{
				if (nums[left] + nums[right] + nums[i] == 0) res.push_back(vector<int>{left, right, i});
			}
		}
		return res;
		
	}
};