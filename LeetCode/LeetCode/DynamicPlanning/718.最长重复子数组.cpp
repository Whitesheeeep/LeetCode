#include <algorithm>
#include <iostream>
#include <unordered_map>
#include <unordered_set>
#include <vector>

using namespace std;

int maxRepeataleLen(vector<int> &nums1, vector<int> &nums2) {
    // 用于装载元素相同的末尾位置
    unordered_set<int> sameIndex;
    int res = 0;
    vector<int> dp(nums2.size(), 0);
    for (int i = 0; i < nums1.size(); i++) {
        if (nums1[i] == nums2[0]) {
            sameIndex.insert(i);
            res = 1;
            dp[0] = 1;
        }
    }
    // for (auto a : sameIndex) {
    //     cout << "Index " <<  a << endl;
    // }

    // nums1 作为基准，nums2 作为比较对象
    for (int i = 1; i < nums2.size(); i++) {
        bool flag = false;
        for (auto index : sameIndex) {
            cout << "index check " << index << endl;
            if (index + 1 < nums1.size() && nums1[index + 1] == nums2[i]) {
                dp[i] = dp[i - 1] + 1;
                sameIndex.erase(index);
                sameIndex.insert(index + 1);
                flag = true;
            } else {
                sameIndex.erase(index);
            }
            cout << "index check over" << index << endl;
        }

        for (auto a : sameIndex) {
            cout << "Index " <<  a << endl;
        }

        // 没有继承相同点，将该点当做单独位置进行处理
        if (!flag) {
            sameIndex.clear();
            for (int j = 0; j < nums1.size(); j++) {
                if (nums1[j] == nums2[i]) {
                    sameIndex.insert(i);
                    dp[i] = 1;
                }
            }
        }
        res = max(res, dp[i]);
    }
    return res;
}

int testCount = 1;
void test(vector<int> nums1, vector<int> nums2) {
    cout << "test " << testCount << endl;
    cout << maxRepeataleLen(nums1, nums2) << endl;
    cout << "test over " << testCount << endl;
    cout << endl;
    testCount++;
}

int main() { test(vector<int>{0,0,0,0,1}, vector<int>{1,0,0,0,0}); }
