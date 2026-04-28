/*
 * @lc app=leetcode.cn id=90 lang=cpp
 *
 * [90] 子集 II
 */
#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

// @lc code=start
vector<vector<int>> res;
class Solution {

public:
    void backTracking(const vector<int>& nums, int k, int startIndex, vector<int>& path)
    {
        if (path.size() == k)
        {
            res.push_back(path);
            return;
        }

        for (int i = startIndex; i < nums.size(); i++) {
            if (i > startIndex && nums[i] == nums[i - 1]) {
                continue;
            }
            
            path.push_back(nums[i]);
            backTracking(nums, k, i + 1, path);
            path.pop_back();
        }
    }

    vector<vector<int>> subsetsWithDup(vector<int>& nums) {
        return res;
    }
};

int main(){
    Solution* sln = new Solution();
    int n,a;
    cin >> n;
    vector<int> nums;
    while (n--) {
        cin >> a;
        nums.push_back(a);
    }

    sort(nums.begin(), nums.end());
    for (int i =0; i <= nums.size(); i++) {
        vector<int> path;
        sln->backTracking(nums, i, 0, path);
    }

    for (auto l : res) {
        for (int s : l) {
            cout << s << " ";
        }
        cout << endl;
    }
}
// @lc code=end

