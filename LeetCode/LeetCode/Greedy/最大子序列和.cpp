#include <climits>
#include <cstdlib>
#include <iostream>
#include <random>
#include <vector>

using namespace std;

class Solution{
public:
    int maxSubArray(vector<int>& nums){
        int res = INT_MIN;
        int sum =0;
        for (int i = 0; i < nums.size(); i++) {
            sum += nums[i];

            res = max(res, sum);
            if (sum <= 0){
                sum = 0;
            }
        }

        return res;
    }
};


int main()
{
    int n,k;
    cin >> n;
    vector<int> nums;
    while (n--) {
        cin >> k;
        nums.push_back(k);
    }
    
    Solution* sln = new Solution();
    cout << sln->maxSubArray(nums);
}
