#include <algorithm>
#include <iostream>
#include <numeric>
#include <vector>

using namespace std;

int maxSumAfterKTimes(vector<int>& nums, int k){
    sort(nums.begin(), nums.end());
    if (nums[0] >= 0) {
        nums[0] =  k % 2 == 0? nums[0] : -nums[0];
    }
    else {
        for (int i = 0; i < k; i++) {
            if (i > nums.size()) {
                nums[nums.size() - 1] = (k - 1) % 2 == 0? nums[nums.size() - 1] : -nums[nums.size() - 1];
                break;
            }
            if (nums[i] < 0)
                nums[i] = - nums[i];
            else{
                int temp = min(nums[i-1], nums[i]);
                nums[i] = (k - 1) % 2 == 0? nums[i] : nums[i] - 2 * temp;
            }
        }
    }

    return accumulate(nums.begin(), nums.end(), 0);
}

int main(){
    int a, b, k;
    cin >> a;
    vector<int> nums;
    while (a--) {
        cin >> b;
        nums.push_back(b);
    }

    cin >> k;

    
    cout << maxSumAfterKTimes(nums, k);
}
