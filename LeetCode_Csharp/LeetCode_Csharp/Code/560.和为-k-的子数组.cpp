/*
 * @lc app=leetcode.cn id=560 lang=cpp
 *
 * [560] 和为 K 的子数组
 */

#include <iostream>
#include <unordered_map>

using namespace std;


// @lc code=start
class Solution {
public:
    int subarraySum(vector<int>& nums, int k) {
        unordered_map<int, int> map;
        map[0] = 1;

        int sum = 0, res = 0;
        for (int i = 0; i < nums.size(); i++) {
            sum += nums[i];
            if (map.count(sum - k))
            {
                res += map[sum - k];
            }
            map[sum]++;
        }
        return res;
    }
};
// @lc code=end

