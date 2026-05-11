#include <algorithm>
#include <climits>
#include <iostream>
#include <string>
#include <vector>

using namespace std;

int monotoneIncreasingDigits(int n){
    // 首个子母的 1 需要特别处理
    vector<int> nums; // 从个位到最高位 0 ~ ...
    int temp = n;
    while (temp) {
        nums.push_back(temp % 10);
        temp /= 10;
    }
    reverse(nums.begin(), nums.end());
    // for (int a : nums) {
    //     cout << "NUm: " << a << endl;
    // }
    
    int index2Nine = INT_MAX;
    for (int i = 0; i < nums.size() - 1; i++) {
        bool flag = false;
        if (nums[i + 1] < nums[i]) {
            // cout << i << endl;
            nums[i]--;
            index2Nine = min(index2Nine, i + 1);
            flag = true;
            // cout << flag << endl;
        }
        while (i > 0 && nums[i - 1] > nums[i]) {
            nums[i - 1]--;
            index2Nine = i;
            i--;
            flag = true;
        }
        if (flag) {
            // cout << "flag true" << endl;
            break;
        }
    }

    if (index2Nine == INT_MAX) return n;
    for (int i = index2Nine; i < nums.size(); i++) {
        nums[i] = 9;
    }

    int res = 0, m = 1;
    for (int i = nums.size() - 1; i >= 0; i--) {
        res += nums[i] * m;
        m *= 10;
    }
    return res;
}

int main(){
    while (true) {
        int n;
        // string a;
        // getline(cin, a);
        // cout << a;
        cin >> n;
        cout << monotoneIncreasingDigits(n) << endl;
    }
}
