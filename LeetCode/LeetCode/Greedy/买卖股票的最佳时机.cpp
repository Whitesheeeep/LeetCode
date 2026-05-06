#include <iostream>
#include <random>
#include <vector>

using namespace std;

int maxProfit(vector<int>& nums)
{
    if (nums.size() <= 1) return 0;
    int res = 0;

    for (int i = 1; i < nums.size(); i++) {
        if (nums[i] - nums[i - 1] > 0)
            res += nums[i] - nums[i - 1];  
    }

    return res;
}

int main()
{
    random_device rd;
    mt19937 gen(rd());

    uniform_int_distribution<> dis(1, 100);

    int n,k;
    cin >> n;
    vector<int> nums;

    while (n--) {
        cin >> k;
        nums.push_back(k);
    }

    cout << maxProfit(nums);
}
