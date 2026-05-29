/*
 * @lc app=leetcode.cn id=239 lang=cpp
 *
 * [239] 滑动窗口最大值
 */

#include <algorithm>
#include <climits>
#include <iostream>
#include <vector>

using namespace std;

template <typename T>
void printVec(vector<T> vec)
{
    for (T a : vec) {
        cout << a << " ";
    }
    cout << endl;
}
// @lc code=start
class Solution {
public:
    vector<int> maxSlidingWindow(vector<int>& nums, int k) {
        vector<int> l2rMax(nums.size(), INT_MIN);
        vector<int> r2lMax(nums.size(), INT_MIN);

        for (int i = 0; i < nums.size(); i = i + k) {
            int m = INT_MIN;
            for (int j = 0; j < k; j++) {
                if (i + j < nums.size()) {
                    l2rMax[i + j] = m = max(m, nums[i + j]);
                }
                else break;
            }
        }
        // printVec(l2rMax);
        
        for (int i = 0; i < nums.size(); i = i + k) {
            int m = INT_MIN;
            for (int j = k - 1; j >= 0; j--) {
                if (i + j < nums.size()) {
                    r2lMax[i + j] = m = max(m, nums[i + j]);
                }
            }
        }
        // printVec(r2lMax);

        vector<int> res;
        for (int i = 0; i <= nums.size() - k; i++) {
            // start = i, end = i + k - 1;
            res.push_back(max(r2lMax[i], l2rMax[i + k - 1]));
        }

        return res;
    }
};



void test(vector<int> nums, int k)
{
    Solution* sln = new Solution();
    cout << "TEST START ============" << endl;
    printVec(sln->maxSlidingWindow(nums, k));
    cout << "TEST END ===========" << endl << endl;
}

int main(){
    test(vector<int>{1,2,3,2,1}, 3);
}
// @lc code=end

