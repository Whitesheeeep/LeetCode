#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

int maxMoney(const vector<int> &nums) {
    if (nums.empty() || nums.size() == 0) {
        return 0;
    }
    if (nums.size() == 1) {
        return nums[0];
    } else if (nums.size() == 2) {
        return max(nums[0], nums[1]);
    }

    vector<int> dp(nums.size(), 0);
    dp[0] = nums[0];
    dp[1] = max(nums[0], nums[1]);
    for (int i = 2; i < nums.size(); i++) {
        dp[i] = max(dp[i - 1], dp[i - 2] + nums[i]);
    }
    return dp[nums.size() - 1];
}

int maxStoleMoney(const vector<int> &nums) {
    // 头尾可以直接看成两个状态：偷头不偷尾，偷尾不偷头
    if (nums.size() <= 2) {
        return max(nums[0], nums[nums.size() - 1]);
    }
    // 1. 偷头: 2~i-2
    cout << "head" << endl;

    vector<int> temp(nums.begin() + 2, nums.end() - 1);
    cout << "temp debug: " << endl;
    for (int i = 0; i < temp.size(); i++) {
        cout << temp[i] << endl;
    }
    cout << "temp debug over" << endl;
    int headStole = maxMoney(temp) + nums[0];

    cout << headStole << endl;

    // 2. 偷尾
    cout << "tail" << endl;
    temp = vector<int>(nums.begin() + 1, nums.end() - 2);
    int tailStole = maxMoney(temp) + nums[nums.size() - 1];

    cout << tailStole << endl;

    // 3. 头尾都不偷
    cout << "No " << endl;
    temp = vector<int>(nums.begin() + 1, nums.end() - 1);
    int middle = maxMoney(temp);
    cout << middle << endl;
    cout << "No over." << endl;

    return max(headStole, max(tailStole, middle));
}

int main() {
    vector<int> test1{1, 1};
    cout << "res: " << endl << maxStoleMoney(test1) << " right: 1" << endl;

    vector<int> test2{1, 2};
    cout << "res: " << endl << maxStoleMoney(test2) << " right: 2" << endl;

    vector<int> test3{3, 3, 1};
    cout << "res: " << endl << maxStoleMoney(test3) << " right: 3" << endl;

    vector<int> test4{1, 3,2,3};
    cout << "res: " << endl << maxStoleMoney(test4) << " right: 6" << endl;

    vector<int> test5{3, 3,1,3};
    cout << "res: " << endl << maxStoleMoney(test5) << " right: 6" << endl;

    // int n;
    // cin >> n;
    // vector<int> nums(n, 0);
    // for (int i = 0; i < n; i++) {
    //     cin >> nums[i];
    // }
}
