#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

int jump(vector<int>& nums){
    if (nums.size() <= 1) {
        return 0;
    }
    int res = 0;
    int left = 0, right = 0;
    while (true) {
        int temp = right;
        for (int i = left; i <= right; i++) {
            // cout << i + nums[i] << " " << right << endl;
            temp = max(i + nums[i], temp);
        }

        if (temp > right) {
            res++;
            // cout << temp << " ";
            if (temp >= nums.size() - 1) {
                return res;
            }
        }
        else if (temp <= right) {
            return -1;
        }

        left = right + 1;
        right = temp;
        // cout << endl;
        // cout << "left: " << left << " right: " << right << endl;
    }
    return res;
}

int jump_2(vector<int>& nums)
{
    if (nums.size() <= 1) return 0;

    int res = 0;
    int right = 0; 
    int temp = right;
    for (int i = 0; i <= right; i++) {
        right = max(right, i + nums[i]);
        if (right >= nums.size() - 1) {
            return res + 1;
        }
        if (i >= temp){ 
            // cout << temp << " ";
            res++;
            temp = right;
        }
    }
    return -1;
}


int main(){
    int n, k;
    cin >> n;
    vector<int> nums;
    while (n--) {
        cin >> k;
        nums.push_back(k);
    }

    cout << jump_2(nums);
}
