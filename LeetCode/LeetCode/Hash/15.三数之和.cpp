#include <algorithm>
#include <iostream>
#include <unordered_map>
#include <unordered_set>
#include <utility>
#include <vector>

using namespace std;

template <typename T> void debugVec(vector<T> vec) {
    for (T a : vec) {
        cout << a << " ";
    }
    cout << endl;
}

template <typename T1, typename T2> void debugMap(unordered_map<T1, T2> map) {
    for (pair<T1, T2> p : map) {
        cout << p.first << "  " << p.second << " ";
    }
    cout << endl;
}

vector<vector<int>> threeSum(vector<int> &nums) {
    vector<vector<int>> res;
    sort(nums.begin(), nums.end());
    for (int i = 0; i < nums.size() - 2 && nums[i] <= 0; i++) {
        if (i > 0 && nums[i] == nums[i - 1]) {
            continue;
        }
        
        int left = i  + 1, right = nums.size() - 1;
        if (nums[i] + nums[left] + nums[right] == 0)
            res.push_back({nums[i], nums[left], nums[right]});
        else
        {
            while (left < right) {
                while (nums[i] + nums[left] + nums[right] < 0 && nums[left] == nums[left + 1]) {
                    left++;
                }
                while (nums[i] + nums[left] + nums[right] > 0 && nums[right] == nums[right - 1]) {
                    right--;
                }
            }
        }
    }

    return res;
}


int testCount = 1;
void test(vector<int> vec)
{
    cout << "test Start " << testCount << endl;
    threeSum(vec);
    cout << "test End " << testCount << "==============" <<endl << endl;
}

int main() {
    test(vector<int>{1,1,-2});
    test(vector<int>{0,0,0,0});
}
