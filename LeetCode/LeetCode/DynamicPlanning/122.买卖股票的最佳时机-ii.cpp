#include <algorithm>
#include <climits>
#include <iostream>
#include <vector>

using namespace std;

// 单只
int maxProfit(const vector<int> &nums) {

}

int testCount = 0;
void test(vector<int> nums) {
    cout << "test" << testCount << endl;
    cout << "res: " << endl;
    cout << maxProfit(nums) << endl;
    cout << "test" << testCount << " over." << endl;
    cout << endl;
    testCount++;
}

int main() {

    vector<int> test1{1, 2};
    test(test1);
    test(vector<int>{2, 1});
    test(vector<int>{3, 2, 4, 5});

    // int n;
    // cin >> n;
    // vector<int> nums(n, 0);
    // for (int i = 0; i < n; i++) {
    //     cin >> nums[i];
    // }
}
