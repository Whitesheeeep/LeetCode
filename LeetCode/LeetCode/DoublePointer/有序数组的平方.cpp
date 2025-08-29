#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

vector<int> sortedSquares(vector<int> &nums);

int main()
{
    vector<int> nums;
    int a;
    while (cin >> a)
    {
        nums.push_back(a);
    }

    for (auto item : sortedSquares(nums))
        cout << item << endl;
    return 0;
}

vector<int> sortedSquares(vector<int> &nums)
{
    // sort(nums.begin(), nums.end());
    vector<int> res;
    int left = 0, right = nums.size() - 1;
    while (left <= right)
    {
        if (abs(nums[left]) > abs(nums[right]))
        {
            res.insert(nums.begin(), nums[left] * nums[left]);
            left++;
        }
        else
        {
            res.insert(res.begin(), nums[right] * nums[right]);
            right--;
        }
    }
    return res;
}
